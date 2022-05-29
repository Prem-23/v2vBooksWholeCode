using System;
using System.Web.UI.WebControls;
using Logger;
using BusinessObjectLayer;
using System.Data;
using DataTransferObject;

namespace v2vDashboard.Flow_Process
{
    public class ClsFlowAddDetails
    {
        ClsLogWriter objClsLogWriter = ClsLogWriter.GetObjLogger;
        ClsDashCommanBAL objClsDashCommanBAL = ClsDashCommanBAL.GetobjClsDashCommanBAL;
        private ClsFlowAddDetails()
        {

        }

        private readonly static Lazy<ClsFlowAddDetails> objClsFlowAddDetails = new Lazy<ClsFlowAddDetails>(() => new ClsFlowAddDetails());

        public static ClsFlowAddDetails GetobjClsFlowAddDetails
        {
            get
            {
                return objClsFlowAddDetails.Value;
            }
        }

        public void fun_Get_BookNameforDDL(DropDownList objDropDownList)
        {
            DataTable dtDdlBooksName = null;
            dtDdlBooksName = new DataTable();
            try
            {
                objDropDownList.Items.Clear();
                dtDdlBooksName = objClsDashCommanBAL.fun_Get_BookNameforDDL();
                if(dtDdlBooksName.Rows[0][0].ToString() == "0")
                {
                    objClsLogWriter.fun_LogWirter("DDl Book Load is failed, Please Check in Sql Log - " + dtDdlBooksName.Rows[0][0].ToString());
                    return;
                }

                if (dtDdlBooksName.Rows.Count > 0)
                {
                    objDropDownList.DataSource = dtDdlBooksName;
                    objDropDownList.DataValueField = dtDdlBooksName.Columns["Book ID"].ToString();
                    objDropDownList.DataTextField = dtDdlBooksName.Columns["Book Names"].ToString();
                    objDropDownList.DataBind();
                }
                objDropDownList.Items.Insert(0, "[ SELECT ]");
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsFlowAddDetails.cs");
            }
        }

        public string fun_ValidateTextBoxes(ClsDashCommonDto objClsDashCommonDto)
        {
            try
            {
                return objClsDashCommanBAL.fun_ValidateTextBoxes(objClsDashCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "ClsFlowAddDetails.cs");
                return string.Empty;
            }
        }
    }
}