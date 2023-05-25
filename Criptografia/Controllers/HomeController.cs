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

namespace Criptografia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/crypt")]
        public IActionResult Crypt(string type, string clientName, List<IFormFile> files)
        {
            if (type == "crip")
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
                    return Json(response);
                }
            }
            else if (type == "decrip")
            {
                Decrip();
            }
            else
            {
                // Tipo inválido
                return BadRequest("Tipo inválido");
            }

            return Ok();
        }




        [HttpPost]
        [Route("/crip")]
        public FileResult Crip(string clientName, List<IFormFile> files)
        {
            Dictionary<string, string[]> chavesClientes = new Dictionary<string, string[]>
            {
                { "JSC", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\JSC\MAG.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\JSC\RobertoGuisasolaPinachoJSC.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\JSC\Virginia Raluca Croitoru.asc"
                } },
                { "VALID", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\VALID\proceso.ficheros.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\VALID\VALID_TCs.asc"
                } },
                { "1OT", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\1OT\1oT_Ken-Tristan_Peterson.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\1OT\1oT_Marcin_Kulczycki.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\1OT\proceso.ficheros.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\1OT\VALID_TCs.asc"
                } },
                { "GEMALTO", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\GEMALTO\DGC_CVA_V2.asc",
                } },
                { "LinksField", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\LinksField\linksfield_pk_brasil.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\JSC\MAG.asc"
                } },
                { "PARETEUM", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\PARETEUM\PTSecure.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\PARETEUM\Ramy Sayed.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\PARETEUM\Ramy.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\PARETEUM\Teumpub.asc"
                } },
                { "GD", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\G&D\GSM_Datagen_Brazil.asc"
                } },
                { "WATCHDATA", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\WatchData\AdH_Watchdata.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Criptografia\Public Keys\WatchData\lu meng.asc",
                } },
                { "TELIA", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\TELIA\DGC_CVA_V3.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\TELIA\PublicKeyNicolasR.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\TELIA\Teumpub.asc",
                } },
                { "WORKZ", new string[] {
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\WORKZ\Workz_SIMDATA.asc",
                    @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Public Keys\WORKZ\Workz_SIMDATA (739E7C87) – Public.asc",
                } },
            };

            foreach (var file in files)
            {
                string fileName = file.FileName;
                string filePath = Path.Combine(@"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Arquivos\Arquivos CRIP", fileName);
                string encryptedFilePath = Path.Combine(@"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Arquivos\Criptografados", fileName + ".pgp");

                // Salva o arquivo enviado pelo front-end no servidor
                int maxRetries = 3;
                int retryDelayMilliseconds = 500;

                for (int retry = 0; retry < maxRetries; retry++)
                {
                    try
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        // O arquivo foi copiado com sucesso, então podemos sair do loop
                        break;
                    }
                    catch (IOException ex)
                    {
                        // O arquivo está sendo usado por outro processo, vamos esperar um pouco e tentar novamente
                        if (retry < maxRetries - 1)
                        {
                            Thread.Sleep(retryDelayMilliseconds);
                        }
                        else
                        {
                            // Se já tentamos o número máximo de vezes, lançamos a exceção novamente
                            throw;
                        }
                    }
                }

                string extensaoArquivo = Path.GetExtension(filePath);

                // Verifica se o arquivo deve ser criptografado
                if (extensaoArquivo == ".out" || extensaoArquivo == ".ota")
                {
                    // Verifica se a empresa está no dicionário de chaves
                    if (chavesClientes.ContainsKey(clientName))
                    {
                        string[] chavesCliente = chavesClientes[clientName];

                        using (PGP pgpInstance = new PGP())
                        {
                            // Criptografa e assina o arquivo
                            pgpInstance.EncryptFileAndSign(filePath, encryptedFilePath, chavesCliente, @"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Old\20200110\TCK.asc", "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%");


                            byte[] fileBytes = System.IO.File.ReadAllBytes(encryptedFilePath);

                            // Define o tipo MIME do arquivo
                            string mimeType = "application/pgp"; // Define o tipo MIME como application/pgp para arquivos .pgp

                            // Retorna o arquivo criptografado para download
                            return File(fileBytes, mimeType, fileName + ".pgp");

                        }
                    }
                    else
                    {
                        // Cliente não encontrado no dicionário de chaves
                        Console.WriteLine("Cliente não encontrado: " + clientName);
                    }
                }
            }

            // Retorna null caso nenhum arquivo seja criptografado
            return null;
        }


        [HttpGet]
        [Route("/download")]
        public FileResult Download(string fileName)
        {
            // Verificar se o nome do arquivo é válido


            string filePath = Path.Combine(@"C:\Users\patrick.oliveira\Desktop\Criptografia\Criptografia\Arquivos\Criptografados", fileName);

            // Verificar se o arquivo existe


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



        public void Decrip()
        {
            // Seu código para o método DEcrip aqui
        }

    }
}


