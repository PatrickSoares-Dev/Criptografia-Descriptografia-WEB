using Criptografia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PgpCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Criptografia.Controllers
{
    public class CriptografiaController : Controller
    {
        public IActionResult Criptografia()
        {
            return View();
        }

        [HttpPost]
        [Route("/crypt")]
        public IActionResult Crypt(string clientName, List<IFormFile> files)
        {
            var result = Crip(clientName, files);
            if (result != null)
            {
                var fileName = Path.GetFileName(result.FileDownloadName);
                var response = new
                {
                    fileName,
                    file = result
                };
                TempData["SuccessMessage"] = "Arquivo criptografado com sucesso!";
                return Json(response);
            }

            return Json(TempData["ErrorMessage"]);
        }


        [HttpPost]
        [Route("/crip")]
        public FileResult Crip(string clientName, List<IFormFile> files)
        {
            Dictionary<string, string[]> chavesClientes = new Dictionary<string, string[]>
            {
                { "JSC", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\JSC\MAG.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\JSC\RobertoGuisasolaPinachoJSC.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\JSC\Virginia Raluca Croitoru.asc"
                } },
                { "VALID", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\VALID\ABnote GSM.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\VALID\proceso.ficheros.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\VALID\VALID_TCs.asc"
                } },
                { "1OT", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\1OT\1oT_Ken-Tristan_Peterson.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\1OT\1oT_Marcin_Kulczycki.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\1OT\proceso.ficheros.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\1OT\VALID_TCs.asc"
                } },
                { "GEMALTO", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\GEMALTO\DGC_CVA_V2.asc",
                } },
                { "LinksField", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\LinksField\linksfield_pk_brasil.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\LinksField\linksfield_publickey.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\LinksField\datagroup.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\LinksField\Adriaan_De_Haan_Watchdata_0x6DFEEF28_public.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\LinksField\IntelCav_MCPI (MCPI)_0x4F5DD20A_public.asc"
                } },
                { "PARETEUM", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\PARETEUM\PTSecure.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\PARETEUM\Ramy Sayed.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\PARETEUM\Ramy.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\PARETEUM\Teumpub.asc"
                } },
                { "GD", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\G&D\GSM_Datagen_Brazil - Copia.asc"
                } },
                { "WATCHDATA", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\WatchData\AdH_Watchdata.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\WatchData\lu meng.asc"
                } },
                { "TELIA", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\TELIA\DGC_CVA_V3.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\TELIA\PublicKeyNicolasR.asc",
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\TELIA\Teumpub.asc",
                } },
                { "WORKZ", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Public Keys\WORKZ\Workz_SIMDATA (739E7C87) – Public.asc"
                } },
                { "TELECALL", new string[] {
                    @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Telecall Keys\Telecallpublic.asc"
                } }
            };

            foreach (var file in files)
            {
                string fileName = file.FileName;
                string filePath = Path.Combine(@"\\177.67.24.103\inetpub\Criptografia\Criptografia\Arquivos\Arquivos CRIP", fileName);
                string encryptedFilePath = Path.Combine(@"\\177.67.24.103\inetpub\Criptografia\Criptografia\Arquivos\Criptografados", fileName + ".pgp");

                // Salva o arquivo enviado pelo front-end no servidor
                int maxRetries = 3;
                int retryDelayMilliseconds = 500;

                for (int retry = 0; retry < maxRetries; retry++)
                {
                    try
                    {
                        ExcluirTodosArquivosArquivosCrip(filePath);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        break;
                    }
                    catch (IOException ex)
                    {
                        if (retry < maxRetries - 1)
                        {
                            Thread.Sleep(retryDelayMilliseconds);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                string extensaoArquivo = Path.GetExtension(filePath);

                if (chavesClientes.ContainsKey(clientName))
                {
                    string[] chavesCliente = chavesClientes[clientName];

                    using (PGP pgpInstance = new PGP())
                    {
                        try
                        {
                            pgpInstance.EncryptFileAndSign(filePath, encryptedFilePath, chavesCliente, @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Old\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");
                            Thread.Sleep(500);

                            byte[] fileBytes = System.IO.File.ReadAllBytes(encryptedFilePath);
                            string mimeType = "application/pgp";

                            TempData["SuccessMessage"] = "Arquivo criptografado com sucesso!";
                            return File(fileBytes, mimeType, fileName + ".pgp");
                        }
                        catch (Exception ex)
                        {
                            TempData["ErrorMessage"] = $"Erro ao criptografar o arquivo: {ex.Message}";                            
                            throw;
                        }
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = $"Cliente não encontrado: {clientName}";
                }
            }

            return null;
        }


        [HttpGet]
        [Route("/downloadcrip")]
        public FileResult DownloadCrip(string fileName)
        {

            string filePath = Path.Combine(@"\\177.67.24.103\inetpub\Criptografia\Criptografia\Arquivos\Criptografados", fileName);

            // Ler o arquivo em bytes
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Definir o tipo MIME do arquivo
            string mimeType = "application/pgp"; // Define o tipo MIME como application/pgp para arquivos .pgp

            // Retornar o arquivo para download
            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = fileName,
                Inline = false // Define como false para forçar o download
            };

            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            return File(fileBytes, mimeType);
        }

        private void ExcluirTodosArquivosArquivosCrip(string pastaArquivosCrip)
        {
            try
            {
                string[] arquivosCrip = Directory.GetFiles(pastaArquivosCrip);
                if (arquivosCrip.Any())
                {
                    foreach (var arquivo in arquivosCrip)
                    {
                        System.IO.File.Delete(arquivo);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir arquivos na pasta Arquivos Crip: {ex.Message}";
            }
        }

    }
}
