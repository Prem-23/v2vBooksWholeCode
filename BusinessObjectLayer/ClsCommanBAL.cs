using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using DataAccessLayer;
using Logger;

namespace BusinessObjectLayer
{
    public class ClsCommanBAL
    {
        ClsCommanDAL objClsCommanDAL = new ClsCommanDAL();
        ClsLogWriter objClsLogWriter = ClsLogWriter.GetObjLogger;
        public DataTable fun_Load_ddlByContent()
        {
            try 
            { 
                return objClsCommanDAL.fun_Load_ddlByContent();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_LoadDataSource()
        {
            try
            {
                return objClsCommanDAL.fun_LoadDataSource();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_LoadDescDetails(int valueID)
        {
            try
            {
                return objClsCommanDAL.fun_LoadDescDetails(valueID);
            }
            catch(Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_GetINISetting()
        {
            try
            {
                return objClsCommanDAL.fun_GetINISetting();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }
        public DataSet fun_InserCustDetails(CommonDto objCommonDto)
        {
            try
            {
                return objClsCommanDAL.fun_InserCustDetails(objCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_TextBoxValidation(CommonDto objCommonDto)
        {
            try
            {
                return objClsCommanDAL.fun_TextBoxValidation(objCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_GetMailDetails(CommonDto objCommonDto)
        {
            try
            {
                return objClsCommanDAL.fun_GetMailDetails(objCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_UpdateSentStatus(CommonDto objCommonDto)
        {
            try
            {
                return objClsCommanDAL.fun_UpdateSentStatus(objCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_UpdateOSentStatus(CommonDto objCommonDto)
        {
            try
            {
                return objClsCommanDAL.fun_UpdateOSentStatus(objCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public DataTable fun_GetMinValid(CommonDto objCommonDto)
        {
            try
            {
                return objClsCommanDAL.fun_GetMinValid(objCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return null;
            }
        }

        public string fun_UpdateValidStatus(CommonDto objCommonDto)
        {
            try
            {
                return objClsCommanDAL.fun_UpdateValidStatus(objCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsCommanBAL.cs");
                return string.Empty;
            }
        }
    }
}
