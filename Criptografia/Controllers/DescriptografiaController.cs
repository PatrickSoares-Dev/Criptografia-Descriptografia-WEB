using Criptografia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PgpCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Criptografia.Controllers
{
    public class DescriptografiaController : Controller
    {
        [HttpPost]
        [Route("/decrypt")]
        public IActionResult Decrypt(List<IFormFile> files)
        {
            try
            {
                var result = Decrip(files);
                if (result != null)
                {
                    var fileName = Path.GetFileName(result.FileDownloadName);
                    var response = new
                    {
                        fileName,
                        file = result
                    };
                    TempData["SuccessMessage"] = "Arquivo descriptografado com sucesso!";
                    return Json(response);
                }

                return Json(TempData["ErrorMessage"]);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao processar a solicitação: {ex.Message}";
                return Json(TempData["ErrorMessage"]);
            }
        }

        [HttpPost]
        [Route("/decrip")]
        public FileResult Decrip(List<IFormFile> files)
        {
            string pastaArquivosDecrip = @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Arquivos\Arquivos DECRIP";
            string pastaDescriptografados = @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Arquivos\Descriptografados";
            string chavePrivada = @"\\177.67.24.103\inetpub\Criptografia\Criptografia\Telecall Keys\9E0F5632E05C7228F9256899D5085A8ABE69EFB4.asc";
            string senha = "Gi?6ae}a)14Cv&U%&!U#Qp5^j!n+SH@M9_<M7uJluM;s!&L<JkN!fC`#+{q*Wu%";

            try
            {
                ExcluirTodosArquivosDescriptografados(pastaDescriptografados);

                foreach (var file in files)
                {
                    string fileName = file.FileName;
                    string filePath = Path.Combine(pastaArquivosDecrip, fileName);

                    try
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                    catch (IOException ex)
                    {
                        TempData["ErrorMessage"] = $"Erro ao copiar o arquivo {fileName}: {ex.Message}";
                        Console.WriteLine(TempData["ErrorMessage"]);
                    }
                    finally
                    {
                        file.OpenReadStream().Close();
                    }

                    string caminhoArquivoCriptografado = Path.Combine(pastaArquivosDecrip, fileName);
                    string caminhoDescriptografado = Path.Combine(pastaDescriptografados, fileName);

                    using (PGP pgp = new PGP())
                    {
                        try
                        {
                            pgp.DecryptFile(caminhoArquivoCriptografado, caminhoDescriptografado, chavePrivada, senha);
                        }
                        catch (Exception ex)
                        {
                            TempData["ErrorMessage"] = $"Erro ao descriptografar o arquivo {fileName}: {ex.Message}";
                            throw;
                        }
                        finally
                        {
                            System.IO.File.Delete(caminhoArquivoCriptografado);
                        }
                    }
                }

                string[] arquivosDescriptografados = ObterNomesDosArquivosDescriptografados(pastaDescriptografados);
                string resultFileName = arquivosDescriptografados.FirstOrDefault();

                if (resultFileName != null)
                {
                    resultFileName = Path.GetFileNameWithoutExtension(resultFileName);

                    if (!resultFileName.EndsWith(".pgp", StringComparison.OrdinalIgnoreCase))
                    {
                        resultFileName += ".pgp";
                    }

                    string caminhoArquivoDescriptografado = Path.Combine(pastaDescriptografados, resultFileName);

                    if (System.IO.File.Exists(caminhoArquivoDescriptografado))
                    {
                        byte[] fileBytes = System.IO.File.ReadAllBytes(caminhoArquivoDescriptografado);
                        string mimeType = "application/pgp";

                        TempData["SuccessMessage"] = "Arquivo descriptografado com sucesso!";
                        return File(fileBytes, mimeType, resultFileName);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string[] ObterNomesDosArquivosDescriptografados(string pastaDescriptografados)
        {
            if (!Directory.Exists(pastaDescriptografados))
            {
                return new string[0];
            }

            string[] arquivosDescriptografados = Directory.GetFiles(pastaDescriptografados);
            return arquivosDescriptografados.Select(Path.GetFileName).ToArray();
        }

        [HttpGet]
        [Route("/downloaddecrip")]
        public FileResult DownloadDecrip(string fileName)
        {
            string filePath = Path.Combine(@"\\177.67.24.103\inetpub\Criptografia\Criptografia\Arquivos\Descriptografados", fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string mimeType = "application/pgp";

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = fileNameWithoutExtension,
                Inline = false
            };

            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            var result = File(fileBytes, mimeType);
            return result;
        }

        private void ExcluirTodosArquivosDescriptografados(string pastaDescriptografados)
        {
            try
            {
                string[] arquivosDescriptografados = Directory.GetFiles(pastaDescriptografados);

                if (arquivosDescriptografados.Any())
                {
                    foreach (var arquivo in arquivosDescriptografados)
                    {
                        System.IO.File.Delete(arquivo);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir arquivos na pasta Descriptografados: {ex.Message}";
                Console.WriteLine(TempData["ErrorMessage"]);
            }
        }
    }
}
