using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;

namespace MailConsoleServ
{
    class Program
    {
        public static string[] sEmp = new string[] { "CRONOS", "LYCATELCOM", "TESTETELECALL", "CRONOS_ESPECIAL" };
        public static string[] AEmail = new string[] { "RATES@CRONOSTELECOM.COM", "RATES@LYCATEL.COM;r.nowicki@lycatel.com", "rafael.alves@telecall.com", "RATES@CRONOSTELECOM.COM;CFERRARI@CRONOSTELECOM.COM" };
        public static string[] AFormat = new string[] { "1", "2", "2", "1" };
        public static string[] Subject = new string[] { "CLI TRUNK", "Telecall Standard Trunk", "TesteTelecall", "ESPECIAL TRUNK" };

        //public static string[] sEmp = new string[] { "TELEXPERTTESTE" };
        //public static string[] AEmail = new string[] { "rafael.alves@telecall.com" };
        //public static string[] AFormat = new string[] { "2"};
        //public static string[] Subject = new string[] { "CLI TRUNK", "Telecall Standard Trunk", "TesteTelecall", "ESPECIAL TRUNK" };
        static void Main(string[] args)
        {
            //Cliente[] aCli = new Cliente[] {
            //    new Cliente("CRONOS", "RATES@CRONOSTELECOM.COM;CFERRARI@CRONOSTELECOM.COM", "1", "")
            //    ,new Cliente("LYCATELCOM", "RATES@LYCATEL.COM;r.nowicki@lycatel.com", "2", "Telecall Standard Trunk")
            //};

            EscreverLog("Iniciando  MailConsole v2");
            Thread.Sleep((5 * 60 * 1000));
            Inicio:
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < sEmp.Length; i++)
                {
                    EnviaRate(sEmp[i], AEmail[i], AFormat[i], Subject[i]);
                }



                EscreverLog("Fim" + " - " + sw.Elapsed);
                Thread.Sleep(300000);
            }
            catch (Exception ex)
            {

                EscreverLog(ex.Message);
            }
            goto Inicio;
        }

        public static void EnviaRate(string sTarg, string sEmail, string sFormato, string sSubject)
        {
            string sDir = "C:\\teste\\testeDir";
            string sUrl = "ftp://177.67.24.103/tlc_desenv/csv";
            string sUrl2 = "ftp://177.67.24.133/tlc_desenv/csv";
            NetworkCredential credentials = new NetworkCredential("Administrator", "T3l3c@ll2015WEB!@#");
            NetworkCredential credentials2 = new NetworkCredential("Administrator", "T3l3c@ll2016WEB!@#");
            DownloadFtpDirectory(sUrl, credentials, "C:\\teste\\testeDir", sTarg);
            DownloadFtpDirectory(sUrl2, credentials2, "C:\\teste\\testeDir", sTarg);


            List<string> lstArq = VerificaArquivoFaltantesBase();
            foreach (string item in lstArq)
            {

                //if (item.ToUpper().Contains(sTarg))
                if (FormataNome(item.ToUpper()) == (sTarg))
                {
                    EscreverLog(item);
                    Excel(item, sDir, sEmail, sFormato, sSubject);
                }
            }
        }

        public static void Excel(string SfileName, string sDir, string sEmail, string sFormat, string sSubject)
        {
            try
            {
                System.Data.DataTable dt = dtIn(sDir, SfileName);
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                EscreverLog("Iniciando Excel");
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                EscreverLog("Excel Iniciado");

                int iTotal = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                        xlWorkSheet.Cells[i + 1, j + 1] = dt.Rows[i].ItemArray[j].ToString();

                    if (i % 1000 == 0 && i > 0)
                    {
                        EscreverLog(string.Format("{0}/{1}", i, iTotal));
                        //if (i == 1000)
                        //goto sair;
                    }
                }
                sair:
                xlApp.DisplayAlerts = false;


                string sNomeArq = SfileName;
                EscreverLog(string.Format("Iniciando Salvando - {0}", sNomeArq));
                string sArqOut = "";
                #region Salvamentos
                switch (sFormat)
                {
                    case "1":
                        sArqOut = string.Format(@"C:\inetpub\Sistemas_Fontes\MailConsole\{0}", sNomeArq.Split('.')[0] + ".xls");
                        xlWorkBook.SaveAs(sArqOut, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        break;
                    case "2":
                        sArqOut = string.Format(@"C:\inetpub\Sistemas_Fontes\MailConsole\{0}", sNomeArq.Split('.')[0] + ".xlsx");
                        xlWorkBook.SaveAs(sArqOut, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLStrictWorkbook, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        break;
                }
                //xlWorkBook.SaveAs(sArqOut, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);   Funciona Xls antigo
                //xlWorkBook.SaveAs(sArqOut, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);  erro
                //xlWorkBook.SaveAs(sArqOut, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorks2FarEast, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);  erro
                //xlWorkBook.SaveAs(sArqOut, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //xlWorkBook.SaveAs(sArqOut, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLStrictWorkbook, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                #endregion

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                EscreverLog("finalizando Salvando");
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                Console.WriteLine(sArqOut + "-" + SfileName + "-" + sEmail);
                //string sUIn = Console.ReadLine();
                //if (sUIn == "YES")
                //{
                SendMailNew(sArqOut, SfileName, sEmail, sSubject);
                EscreverLog("Enviado:" + " " + sEmail);
                //}


            }
            catch (Exception ex)
            {
                EscreverLog(ex.Message);
            }
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private static System.Data.DataTable dtIn(string sDir, string Sfile)
        {
            System.Data.DataTable dtOut = new System.Data.DataTable();
            dtOut.Columns.Add("Destination");
            dtOut.Columns.Add("Code");
            dtOut.Columns.Add("Rate");
            dtOut.Columns.Add("StartDate");
            dtOut.Columns.Add("Status");
            dtOut.Columns.Add("MinimumDuration");
            dtOut.Columns.Add("BillingIncrement");
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jefferson\Desktop\Cronos_Excel\TesteFile\InTesteMin.csv");


            //string[] lines = System.IO.File.ReadAllLines(@"C:\teste\InTesteMin.csv");
            string[] lines = System.IO.File.ReadAllLines(sDir + "\\" + Sfile);
            foreach (string item in lines)
            {
                DataRow dr = dtOut.NewRow();
                for (int i = 0; i < dtOut.Columns.Count; i++)
                    dr[i] = item.Split(',')[i];

                dtOut.Rows.Add(dr);

            }
            return dtOut;


        }
        private System.Data.DataTable dtInArq(string sArqIn)
        {
            System.Data.DataTable dtOut = new System.Data.DataTable();
            dtOut.Columns.Add("Destination");
            dtOut.Columns.Add("Code");
            dtOut.Columns.Add("Rate");
            dtOut.Columns.Add("StartDate");
            dtOut.Columns.Add("Status");
            dtOut.Columns.Add("MinimumDuration");
            dtOut.Columns.Add("BillingIncrement");
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jefferson\Desktop\Cronos_Excel\TesteFile\InTesteMin.csv");


            string[] lines = System.IO.File.ReadAllLines(@"C:\teste\InTesteMin.csv");
            foreach (string item in lines)
            {
                DataRow dr = dtOut.NewRow();
                for (int i = 0; i < dtOut.Columns.Count; i++)
                    dr[i] = item.Split(',')[i];

                dtOut.Rows.Add(dr);

            }
            return dtOut;


        }
        private static void SendMailNew(string sFile, string SfileName, string sMail, string sSubject)
        {
            string from = "rates@telecall.com";
            //string[] to = new string[] { "rafael.alves@telecall.com", " leandro.maia@telecall.com", "edson.maeoca@telecall.com" }; //"cferrari@cronostelecom.com" ,RATES@CRONOSTELECOM.COM; CFERRARI@CRONOSTELECOM.COM
            //string[] to = new string[] { "RATES@CRONOSTELECOM.COM", "CFERRARI@CRONOSTELECOM.COM" }; //"cferrari@cronostelecom.com" ,RATES@CRONOSTELECOM.COM; CFERRARI@CRONOSTELECOM.COM
            string[] to = new string[sMail.Split(';').Length];

            for (int i = 0; i < sMail.Split(';').Length; i++)
                to[i] = sMail.Split(';')[i];

            //string[] bcc = new string[] { "rafael.alves@telecall.com", " leandro.maia@telecall.com", "edson.maeoca@telecall.com" };
            string[] bcc = new string[] { "rafael.alves@telecall.com", "rates@telecall.com" };
            //string[] cc = new string[] { "rafael.alves@telecall.com", " leandro.maia@telecall.com", "edson.maeoca@telecall.com" };
            string body = "Telecall is changing the attached rates. These rates are with the appropriate effective dates and are in USD.Routes not offered will be charged US$1.00 (One Dollar)." + Environment.NewLine + "Please confirm receipt by replying to this e-mail.";
            string subject = string.IsNullOrWhiteSpace(sSubject) ? SfileName.Split('.')[0] : sSubject;
            //if (SfileName.Contains("CRONOS_SPECIAL"))
            //subject = SfileName.Replace("CRONOS_SPECIAL", "CRONOS_SPC");
            //else if (SfileName.Contains("CRONOS"))
            //subject = SfileName.Replace("CRONOS", "CRONOS_CLI");
            //else
            //subject = string.IsNullOrWhiteSpace(sSubject) ? SfileName.Split('.')[0] : sSubject;

            MailMessage mMailMessage = new MailMessage();
            mMailMessage.From = new MailAddress(from);

            foreach (string item in to)
                mMailMessage.To.Add(new MailAddress(item));

            foreach (var item in bcc)
                if ((item != null) && (item != string.Empty))
                    mMailMessage.Bcc.Add(new MailAddress(item));



            //Lembrrar de Terirar Essa copia
            mMailMessage.CC.Add(new MailAddress("rates@telecall.com"));

            mMailMessage.Subject = subject;
            mMailMessage.Body = body;
            //mMailMessage.Priority = MailPriority.Normal;
            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.UseDefaultCredentials = false;
            #region Credenciais Traind
            //mSmtpClient.Host = "smtp.tradingvoip.com";
            //mSmtpClient.Port = 2525;
            //mSmtpClient.Credentials = new NetworkCredential("support@tradingvoip.com", "T3l3c@ll2016!@");
            #endregion
            #region CredenciaisAlternativas
            mSmtpClient.Host = "mail4.telecall.com";
            mSmtpClient.Port = 2525;
            mSmtpClient.Credentials = new NetworkCredential("rates@telecall.com", "R4t352014!@#");
            #endregion

            

            Attachment data = new Attachment(sFile, MediaTypeNames.Application.Octet);
            mMailMessage.Attachments.Add(data);
            try
            {
                mSmtpClient.Send(mMailMessage);
                AtualizarBase(SfileName);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Não é possível enviar a um destinatário"))
                {
                    AtualizarBase(SfileName);
                }
                System.Console.WriteLine(ex.Message);
            }
        }
        private static void EscreverLog(string sIn)
        {
            try
            {
                string sPath = "c:\\SendEmailLog\\";
                DateTime dAgora = DateTime.Now;
                if (!Directory.Exists(sPath))
                    Directory.CreateDirectory("c:\\SendEmailLog\\");

                using (StreamWriter sw = File.AppendText(sPath + "\\SendMail.log"))
                {
                    sw.WriteLine(string.Format("{0}-{1}", dAgora.ToString(), sIn));
                }
                Console.WriteLine(string.Format("{0}-{1}", dAgora.ToString(), sIn));
            }
            catch
            { }
        }
        private static List<string> VerificarArquivos(string sDir)
        {
            //DirectoryInfo dirInfo = new DirectoryInfo(sDir);
            //FileInfo[] Files = new DirectoryInfo(sDir).GetFiles("*", SearchOption.AllDirectories);
            List<string> lstOut = new List<string>();
            foreach (FileInfo item in new DirectoryInfo(sDir).GetFiles("*", SearchOption.AllDirectories))
                lstOut.Add(item.Name);

            return lstOut;
        }

        private static void EndGetStreamCallback(IAsyncResult ar)
        {
            FtpState state = (FtpState)ar.AsyncState;

            Stream requestStream = null;
            // End the asynchronous call to get the request stream.
            try
            {
                requestStream = state.Request.EndGetRequestStream(ar);
                // Copy the file contents to the request stream.
                const int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];
                int count = 0;
                int readBytes = 0;
                FileStream stream = File.OpenRead(state.FileName);
                do
                {
                    readBytes = stream.Read(buffer, 0, bufferLength);
                    requestStream.Write(buffer, 0, readBytes);
                    count += readBytes;
                }
                while (readBytes != 0);
                Console.WriteLine("Writing {0} bytes to the stream.", count);
                // IMPORTANT: Close the request stream before sending the request.
                requestStream.Close();
                // Asynchronously get the response to the upload request.
                state.Request.BeginGetResponse(
                    new AsyncCallback(EndGetResponseCallback),
                    state
                );
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine("Could not get the request stream.");
                state.OperationException = e;
                state.OperationComplete.Set();
                return;
            }

        }

        // The EndGetResponseCallback method  
        // completes a call to BeginGetResponse.
        private static void EndGetResponseCallback(IAsyncResult ar)
        {
            FtpState state = (FtpState)ar.AsyncState;
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)state.Request.EndGetResponse(ar);
                response.Close();
                state.StatusDescription = response.StatusDescription;
                // Signal the main application thread that 
                // the operation is complete.
                state.OperationComplete.Set();
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine("Error getting response.");
                state.OperationException = e;
                state.OperationComplete.Set();
            }
        }

        //Novo
        static void DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath, string sFileTarg)
        {
            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = credentials;

            List<string> lines = new List<string>();

            using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (StreamReader listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                    lines.Add(listReader.ReadLine());
            }

            foreach (string line in lines)
            {
                string[] tokens =
                    line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[3];
                string permissions = tokens[0];
                DateTime dt1 = new DateTime(int.Parse(tokens[0].Split('-')[2]) + 2000, int.Parse(tokens[0].Split('-')[0]), int.Parse(tokens[0].Split('-')[1]), int.Parse(tokens[1].Split(':')[0]), int.Parse(tokens[1].Split(':')[1].Replace("AM", "").Replace("PM", "")), 0);

                string localFilePath = Path.Combine(localPath, name);
                string fileUrl = url + "/" + name;

                if (name.ToUpper().Contains(sFileTarg) && VerificaArquivoBase(name))
                {
                    FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                    downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    downloadRequest.Credentials = credentials;

                    using (FtpWebResponse downloadResponse =
                              (FtpWebResponse)downloadRequest.GetResponse())
                    using (Stream sourceStream = downloadResponse.GetResponseStream())
                    using (Stream targetStream = File.Create(localFilePath))
                    {
                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                            targetStream.Write(buffer, 0, read);
                    }
                    InserirBase(name, dt1);
                }
            }
        }

        static void RetornarBase()
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=177.67.24.37;Initial Catalog=NEXTONE_NEW;User ID=email2db;Password=2DBemail162;Min Pool Size=0;Max Pool Size=30;Pooling=true;");
            DataTable dtReturn = new DataTable();
            try
            {
                string sSQL = string.Empty;
                sSQL = " select  *  from cronos_temp ";
                sqlCon.Open();
                SqlCommand sComm = new SqlCommand(sSQL, sqlCon);
                SqlDataReader sRead = sComm.ExecuteReader();
                dtReturn.Load(sRead);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlCon.Close();
            }

        }
        static void InserirBase(string sNome, DateTime dtInclu)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=177.67.24.37;Initial Catalog=NEXTONE_NEW;User ID=email2db;Password=2DBemail162;Min Pool Size=0;Max Pool Size=30;Pooling=true;");
            DataTable dtReturn = new DataTable();
            try
            {
                string sSQL = string.Empty;
                sSQL = string.Format(" insert into cronos_temp (FileName,dtInclusao,dtEnvio) values ('{0}','{1}',null)", sNome, dtInclu.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sqlCon.Open();
                SqlCommand sComm = new SqlCommand(sSQL, sqlCon);
                sComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlCon.Close();
            }
        }
        static void AtualizarBase(string sNome)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=177.67.24.37;Initial Catalog=NEXTONE_NEW;User ID=email2db;Password=2DBemail162;Min Pool Size=0;Max Pool Size=30;Pooling=true;");
            DataTable dtReturn = new DataTable();
            try
            {
                string sSQL = string.Empty;
                sSQL = string.Format(" update cronos_temp set dtEnvio='{1}' where FileName = '{0}'", sNome, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sqlCon.Open();
                SqlCommand sComm = new SqlCommand(sSQL, sqlCon);
                sComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlCon.Close();
            }
        }
        static bool VerificaArquivoBase(string sNome)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=177.67.24.37;Initial Catalog=NEXTONE_NEW;User ID=email2db;Password=2DBemail162;Min Pool Size=0;Max Pool Size=30;Pooling=true;");
            DataTable dtReturn = new DataTable();
            try
            {
                string sSQL = string.Empty;
                sSQL = string.Format(" select  *  from cronos_temp  where Filename like '{0}' ", sNome);
                sqlCon.Open();
                SqlCommand sComm = new SqlCommand(sSQL, sqlCon);
                SqlDataReader sRead = sComm.ExecuteReader();
                dtReturn.Load(sRead);
                return dtReturn.Rows.Count == 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlCon.Close();
            }
        }
        static string FormataNome(string sNome)
        {
            string sRetorno = "";
            for (int i = 0; i < sNome.Split('_').Length - 2; i++)
            {
                sRetorno += string.IsNullOrEmpty(sRetorno) ? sNome.Split('_')[i] : string.Format("_{0}", sNome.Split('_')[i]);
            }
            return sRetorno;
        }
        static List<string> VerificaArquivoFaltantesBase()
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=177.67.24.37;Initial Catalog=NEXTONE_NEW;User ID=email2db;Password=2DBemail162;Min Pool Size=0;Max Pool Size=30;Pooling=true;");
            DataTable dtReturn = new DataTable();
            try
            {
                string sSQL = string.Empty;
                sSQL = " select  *  from cronos_temp  where dtEnvio is null ";
                sqlCon.Open();
                SqlCommand sComm = new SqlCommand(sSQL, sqlCon);
                SqlDataReader sRead = sComm.ExecuteReader();
                dtReturn.Load(sRead);
                List<string> lstOut = new List<string>();
                foreach (DataRow item in dtReturn.Rows)
                    lstOut.Add(item["FileName"].ToString());

                return lstOut;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }

    public class FtpState
    {
        private ManualResetEvent wait;
        private FtpWebRequest request;
        private string fileName;
        private Exception operationException = null;
        string status;

        public FtpState()
        {
            wait = new ManualResetEvent(false);
        }

        public ManualResetEvent OperationComplete
        {
            get { return wait; }
        }

        public FtpWebRequest Request
        {
            get { return request; }
            set { request = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public Exception OperationException
        {
            get { return operationException; }
            set { operationException = value; }
        }
        public string StatusDescription
        {
            get { return status; }
            set { status = value; }
        }
    }

    public class Cliente
    {
        public string sNome { get; set; }
        public string sEmail { get; set; }
        public string sFormat { get; set; }
        public string sSubject { get; set; }
        public Cliente(string sInNome, string sInEmail, string sInFormat, string sInSubject)
        {
            sNome = sInNome;
            sEmail = sInEmail;
            sFormat = sInFormat;
            sSubject = sInSubject;
        }
    }
}

