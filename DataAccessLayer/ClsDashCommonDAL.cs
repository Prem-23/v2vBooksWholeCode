using Logger;
using System;
using DataTransferObject;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ClsDashCommonDAL : Utilites
    {
        ClsLogWriter objClsLogWriter = ClsLogWriter.GetObjLogger;

        private ClsDashCommonDAL()
        {

        }

        private readonly static Lazy<ClsDashCommonDAL> objClsDashCommonDAL = new Lazy<ClsDashCommonDAL>(() => new ClsDashCommonDAL());

        public static ClsDashCommonDAL GetobjClsDashCommonDAL
        {
            get
            {
                return objClsDashCommonDAL.Value;
            }
        }

        public DataTable fun_Get_BookNameforDDL()
        {
            DataTable dt_load_dataSource = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dt_load_dataSource = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_GET_BOOKNAMESFORDDL";
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dt_load_dataSource);
                return dt_load_dataSource;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsDashCommonDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_Get_BookNameforDDL in ClsDashCommonDAL.cs");
            }
        }

        public string fun_ValidateTextBoxes(ClsDashCommonDto objClsDashCommonDto)
        {
            DataTable dt_ValidateResult = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dt_ValidateResult = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_VALIDATE_BOOKADDINGTEXTBOXES";
                objSqlCommand.Parameters.AddWithValue("@BM_BOOKNAME", objClsDashCommonDto.BkName);
                objSqlCommand.Parameters.AddWithValue("@BM_AUTHORNAME", objClsDashCommonDto.AuthName);
                objSqlCommand.Parameters.AddWithValue("@BM_PUBLISHERNAME", objClsDashCommonDto.PubName);
                objSqlCommand.Parameters.AddWithValue("@BM_STATUS", objClsDashCommonDto.ddlBkStatus);
                objSqlCommand.Parameters.AddWithValue("@MBD_DESC", objClsDashCommonDto.BkDesc);
                objSqlCommand.Parameters.AddWithValue("@MBD_TYPE", objClsDashCommonDto.BkType);
                objSqlCommand.Parameters.AddWithValue("@MBD_PRICE", objClsDashCommonDto.BkPrice);
                objSqlCommand.Parameters.AddWithValue("@MBD_STATUS", objClsDashCommonDto.ddlBkStatusadd);
                objSqlCommand.Parameters.AddWithValue("@MBD_NUMOFSTOCK", objClsDashCommonDto.NumofStock);
                objSqlCommand.Parameters.AddWithValue("@MBD_DISCOUNTDESC", objClsDashCommonDto.BkDisDesc);
                objSqlCommand.Parameters.AddWithValue("@MBD_DISCOUNTEDPRICE", objClsDashCommonDto.BkDisPrice);
                objSqlCommand.Parameters.AddWithValue("@MBD_IMGNAME", objClsDashCommonDto.BkImgName);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dt_ValidateResult);
                return dt_ValidateResult.Rows[0][0].ToString();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsDashCommonDAL.cs");
                return string.Empty;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_Get_BookNameforDDL in ClsDashCommonDAL.cs");
            }
        }
    }
}
