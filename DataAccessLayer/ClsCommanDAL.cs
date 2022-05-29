using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using Logger;

namespace DataAccessLayer
{
    public class ClsCommanDAL : Utilites
    {
        ClsLogWriter objClsLogWriter = ClsLogWriter.GetObjLogger;
        public DataTable fun_Load_ddlByContent()
        {
            DataTable dt_load_dll = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dt_load_dll = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_GET_SEARCHDDLHOME";
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dt_load_dll);
                return dt_load_dll;
            }
            catch(Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_Load_ddlByContent in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_LoadDataSource()
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
                objSqlCommand.CommandText = "USP_GET_DETAILBOOKS";
                //objSqlCommand.Parameters.AddWithValue("@DDLSelectName", "All");
                //objSqlCommand.Parameters.AddWithValue("@NAME", "TNPSC");
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dt_load_dataSource);
                return dt_load_dataSource;
            }
            catch (SqlException sqlMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(sqlMsg, "ClsCommanDAL.cs");
                return null;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_Load_ddlByContent in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_LoadDescDetails(int valueID)
        {
            DataTable dtLoadDesc = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dtLoadDesc = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_GET_DESCRIPTIONRECORDS";
                objSqlCommand.Parameters.AddWithValue("@MBDID", valueID);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dtLoadDesc);
                return dtLoadDesc;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_LoadDescDetails in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_GetINISetting()
        {
            DataTable dtLoadINISetting = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dtLoadINISetting = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_GETINISETTING";
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dtLoadINISetting);
                return dtLoadINISetting;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_GetINISetting in ClsCommanDAL.cs");
            }
        }

        public DataSet fun_InserCustDetails(CommonDto objCommonDto)
        {
            DataSet dsInserCustDetails = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dsInserCustDetails = new DataSet();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_INSERT_CARTSUBMITION";
                objSqlCommand.Parameters.AddWithValue("@CUST_FIRSTNAME", objCommonDto.fstName);
                objSqlCommand.Parameters.AddWithValue("@CUST_MIDDLENAME", objCommonDto.mdlName);
                objSqlCommand.Parameters.AddWithValue("@CUST_LASTNAME", objCommonDto.lstName);
                objSqlCommand.Parameters.AddWithValue("@MOBILE_NO", objCommonDto.mobNum);
                objSqlCommand.Parameters.AddWithValue("@ALTERMOBILE_NO", objCommonDto.alternateMobNum);
                objSqlCommand.Parameters.AddWithValue("@UD_EMAILID", objCommonDto.mailID);
                objSqlCommand.Parameters.AddWithValue("@CITY", objCommonDto.city);
                objSqlCommand.Parameters.AddWithValue("@STATE", objCommonDto.state);
                objSqlCommand.Parameters.AddWithValue("@COUNTRY", objCommonDto.country);
                objSqlCommand.Parameters.AddWithValue("@PINCODE", objCommonDto.pin);
                objSqlCommand.Parameters.AddWithValue("@ADD_LINE1", objCommonDto.addOne);
                objSqlCommand.Parameters.AddWithValue("@ADD_LINE2", objCommonDto.addTwo);
                objSqlCommand.Parameters.AddWithValue("@DISTRICT", objCommonDto.Dist);
                objSqlCommand.Parameters.AddWithValue("@QUAN", Convert.ToInt32(objCommonDto.quan));
                objSqlCommand.Parameters.AddWithValue("@BOOKID", objCommonDto.BookID);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dsInserCustDetails);
                return dsInserCustDetails;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_InserCustDetails in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_TextBoxValidation(CommonDto objCommonDto)
        {
            DataTable dttxtBox_validations = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dttxtBox_validations = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_VALIDATE_TEXTBOXES";
                objSqlCommand.Parameters.AddWithValue("@CUST_FIRSTNAME", objCommonDto.fstName);
                objSqlCommand.Parameters.AddWithValue("@CUST_MIDDLENAME", objCommonDto.mdlName);
                objSqlCommand.Parameters.AddWithValue("@CUST_LASTNAME", objCommonDto.lstName);
                objSqlCommand.Parameters.AddWithValue("@MOBILE_NO", objCommonDto.mobNum);
                objSqlCommand.Parameters.AddWithValue("@ALTERMOBILE_NO", objCommonDto.alternateMobNum);
                objSqlCommand.Parameters.AddWithValue("@UD_EMAILID", objCommonDto.mailID);
                objSqlCommand.Parameters.AddWithValue("@CITY", objCommonDto.city);
                objSqlCommand.Parameters.AddWithValue("@STATE", objCommonDto.state);
                objSqlCommand.Parameters.AddWithValue("@COUNTRY", objCommonDto.country);
                objSqlCommand.Parameters.AddWithValue("@PINCODE", objCommonDto.pin);
                objSqlCommand.Parameters.AddWithValue("@ADD_LINE1", objCommonDto.addOne);
                objSqlCommand.Parameters.AddWithValue("@ADD_LINE2", objCommonDto.addTwo);
                objSqlCommand.Parameters.AddWithValue("@DISTRICT", objCommonDto.Dist);
                objSqlCommand.Parameters.AddWithValue("@QUAN", objCommonDto.quan);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dttxtBox_validations);
                return dttxtBox_validations;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_TextBoxValidation in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_GetMailDetails(CommonDto objCommonDto)
        {
            DataTable dtGetMailDetails = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dtGetMailDetails = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_GET_USERADDRESS";
                objSqlCommand.Parameters.AddWithValue("@USERINSERTID", objCommonDto.userInsertID);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dtGetMailDetails);
                return dtGetMailDetails;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_GetMailDetails in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_UpdateSentStatus(CommonDto objCommonDto)
        {
            DataTable dtGetMailDetails = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dtGetMailDetails = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_UPDATE_MSGRECEIVEDSTATUS";
                objSqlCommand.Parameters.AddWithValue("@STATUS", objCommonDto.sentStatus);
                objSqlCommand.Parameters.AddWithValue("@MSGHROUGH", objCommonDto.sentThrough);
                objSqlCommand.Parameters.AddWithValue("@USERINSERTID", objCommonDto.userInsertID);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dtGetMailDetails);
                return dtGetMailDetails;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_UpdateSentStatus in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_UpdateOSentStatus(CommonDto objCommonDto)
        {
            DataTable dtGetMailDetails = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dtGetMailDetails = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_UPDATE_OSENTSTATUS";
                objSqlCommand.Parameters.AddWithValue("@STATUS", objCommonDto.sentStatus);
                objSqlCommand.Parameters.AddWithValue("@SENTTHROUGH", objCommonDto.sentThrough);
                objSqlCommand.Parameters.AddWithValue("@USERINSERTID", objCommonDto.userInsertID);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dtGetMailDetails);
                return dtGetMailDetails;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_UpdateOSentStatus in ClsCommanDAL.cs");
            }
        }

        public DataTable fun_GetMinValid(CommonDto objCommonDto)
        {
            DataTable dtGetMailDetails = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dtGetMailDetails = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_GET_MIN";
                objSqlCommand.Parameters.AddWithValue("@USERINSERTID", objCommonDto.userInsertID);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dtGetMailDetails);
                return dtGetMailDetails;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return null;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_GetMinValid in ClsCommanDAL.cs");
            }
        }

        public string fun_UpdateValidStatus(CommonDto objCommonDto)
        {
            DataTable dtGetMailDetails = null;
            SqlCommand objSqlCommand = null;
            SqlDataAdapter objSqlDataAdapter = null;
            dtGetMailDetails = new DataTable();
            objSqlCommand = new SqlCommand();
            objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objSqlCommand.Connection = ConnectDbNew();
                objSqlCommand.CommandText = "USP_UPDATE_ISOVALIDSTATUS";
                objSqlCommand.Parameters.AddWithValue("@USERINSERTID", objCommonDto.userInsertID);
                objSqlCommand.Parameters.AddWithValue("@ISOVALID", objCommonDto.isValidStatus);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(dtGetMailDetails);
                return dtGetMailDetails.Rows[0][0].ToString();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanDAL.cs");
                return string.Empty;
            }
            finally
            {
                DisconnectDbNew(objSqlCommand.Connection);
                objClsLogWriter.fun_LogWirter("Connection Close - fun_GetMinValid in ClsCommanDAL.cs");
            }
        }
    }
}
