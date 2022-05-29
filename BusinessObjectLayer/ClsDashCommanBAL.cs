using Logger;
using System;
using System.Data;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessObjectLayer
{
    public class ClsDashCommanBAL
    {
        ClsLogWriter objClsLogWriter = ClsLogWriter.GetObjLogger;
        ClsDashCommonDAL objClsDashCommonDAL = ClsDashCommonDAL.GetobjClsDashCommonDAL;

        private ClsDashCommanBAL()
        {

        }

        private readonly static Lazy<ClsDashCommanBAL> objClsDashCommanBAL = new Lazy<ClsDashCommanBAL>(() => new ClsDashCommanBAL());

        public static ClsDashCommanBAL GetobjClsDashCommanBAL
        {
            get
            {
                return objClsDashCommanBAL.Value;
            }
        }

        public DataTable fun_Get_BookNameforDDL()
        {
            try
            {
                return objClsDashCommonDAL.fun_Get_BookNameforDDL();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsDashCommanBAL.cs");
                return null;
            }
        }

        public string fun_ValidateTextBoxes(ClsDashCommonDto objClsDashCommonDto)
        {
            try
            {
                return objClsDashCommonDAL.fun_ValidateTextBoxes(objClsDashCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsDashCommanBAL.cs");
                return string.Empty;
            }
        }
    }
}
