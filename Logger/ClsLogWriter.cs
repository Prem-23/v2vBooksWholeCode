using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ClsLogWriter
    {
        private ClsLogWriter()
        {

        }
        private static readonly Lazy<ClsLogWriter> objLogWriter = new Lazy<ClsLogWriter>(() => new ClsLogWriter());

        public static ClsLogWriter GetObjLogger
        {
            get
            {
                return objLogWriter.Value;
            }
        }

        public void fun_LogWirter(string strMessage)
        {
            try
            {
                if (strMessage.ToLower().Contains("error") || strMessage.ToLower().Contains("not"))
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (strMessage.ToLower().Contains("successfully"))
                    Console.ForegroundColor = ConsoleColor.Green;


                Console.WriteLine(strMessage);

                Console.ForegroundColor = ConsoleColor.White;

                string LogPath = string.Empty;

                LogPath = string.Format(EDataToData(ConfigurationManager.AppSettings["LogPath"])) + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MMM") + "\\" + DateTime.Now.ToString("dd");

                DirectoryInfo dirLog = new DirectoryInfo(LogPath);


                if (!Directory.Exists(dirLog.ToString()))
                {
                    Directory.CreateDirectory(dirLog.ToString());
                }

                FileInfo fileLog = new FileInfo(dirLog.ToString() + "\\" + "V2VBooks_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt");


                strMessage = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss : ") + strMessage;

                lock (this)
                {
                    using (StreamWriter ErrorList = new StreamWriter(fileLog.FullName, true))
                    {
                        ErrorList.WriteLine(strMessage);
                        ErrorList.Close();
                    }
                }
            }
            catch (Exception exMsg)
            {
                throw exMsg;
            }

        }


        public void ErrorLogWithParameters(Exception ex, string parameters)
        {
            try
            {
                string file = "V2VBooks_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt";
                string LogPath = string.Empty, LogFilePath = string.Empty;

                LogPath = string.Format(EDataToData(ConfigurationManager.AppSettings["LogPath"])) + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MMM") + "\\" + DateTime.Now.ToString("dd");

                if (!Directory.Exists(LogPath))
                {
                    System.IO.Directory.CreateDirectory(LogPath);
                }

                StreamWriter stream;
                if (!File.Exists(LogPath + "\\" + file))
                {
                    stream = File.CreateText(LogPath + "\\" + file);
                    stream.Flush();
                    stream.Close();
                    stream = null;
                }

                LogFilePath = LogPath + "\\" + file;

                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine
                        + "Date :" + DateTime.Now.ToString() + Environment.NewLine + "Parameters :" + parameters.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.AutoFlush = true;
                    writer.Close();
                }

            }
            catch (Exception exMsg)
            {
                throw exMsg;
            }

        }

        public string EDataToData(string Message)
        {
            try
            {
                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes("v@V8oo>I$v1"));
                TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                tripleDESCryptoServiceProvider.Key = key;
                tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                byte[] array = Convert.FromBase64String(Message);
                byte[] bytes;
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                    bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
                }
                finally
                {
                    tripleDESCryptoServiceProvider.Clear();
                    mD5CryptoServiceProvider.Clear();
                }
                return uTF8Encoding.GetString(bytes);
            }
            catch (Exception ex)
            {
                ErrorLogWithParameters(ex, "EDataToData - Utilites.cs");
                return string.Empty;
            }
        }
    }
}
