using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using Logger;

namespace DataAccessLayer
{
    public class Utilites
    {
        ClsLogWriter objLogWriter = ClsLogWriter.GetObjLogger;
        public SqlConnection ConnectDbNew()
        {
            try
            {
                SqlConnection objConnection;
                objConnection = null;
                objConnection = new SqlConnection(EDataToData(ConfigurationManager.AppSettings["SQLConnectionString"].ToString()));
                objConnection.Open();
                return objConnection;
            }
            catch (Exception exMessage)
            {
                objLogWriter.ErrorLogWithParameters(exMessage, "ConnectDbNew - Utilites.cs");
                return null;
            }
        }

        protected void DisconnectDbNew(DbConnection objSqlConnection)
        {
            try
            {
                if (objSqlConnection != null)
                {
                    if (objSqlConnection.State == ConnectionState.Open)
                    {
                        objSqlConnection.Close();
                        objSqlConnection.Dispose();
                    }
                }
            }
            catch (SqlException exMessage)
            {
                objLogWriter.ErrorLogWithParameters(exMessage, "DisconnectDbNew - Utilites.cs");
            }
        }

        public string DataToEData(string Message)
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
                byte[] bytes = uTF8Encoding.GetBytes(Message);
                byte[] inArray;
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                    inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                }
                finally
                {
                    tripleDESCryptoServiceProvider.Clear();
                    mD5CryptoServiceProvider.Clear();
                }
                return Convert.ToBase64String(inArray);
            }
            catch (Exception ex)
            {
                objLogWriter.ErrorLogWithParameters(ex, "DataToEData - Utilites.cs");
                return string.Empty;
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
                objLogWriter.ErrorLogWithParameters(ex, "EDataToData - Utilites.cs");
                return string.Empty;
            }
        }
    }
}
