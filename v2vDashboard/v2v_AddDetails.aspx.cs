using Logger;
using System;
using System.Web.UI.WebControls;
using v2vDashboard.Flow_Process;
using v2vDashboard.LocalResources;
using DataTransferObject;
using System.Drawing;

namespace v2vDashboard
{
    public partial class v2v_AddDetails : System.Web.UI.Page
    {
        ClsLogWriter objClsLogWriter = ClsLogWriter.GetObjLogger;
        PresentationUtility objPresentationUtility = PresentationUtility.GetPresentationUtility;
        ClsFlowAddDetails objClsFlowAddDetails = ClsFlowAddDetails.GetobjClsFlowAddDetails;
        ClsDashCommonDto objClsDashCommonDto = ClsDashCommonDto.GetobjClsDashCommonDto;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack == true)
                {

                }
                else
                {
                    objPresentationUtility.fun_GetIniSetting(this.Page);
                    objClsFlowAddDetails.fun_Get_BookNameforDDL(ddl_bks);
                    rd_select.Checked = true;
                    rd_NoDis.Checked = true;
                    fun_visibleStateForSelect(0);
                    fun_visibleStateForSelect(1);
                }

                lbl_infoMsg.Text = string.Empty;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        private void fun_visibleStateForSelect(int Val)
        {
            try
            {
                if(Val == 0)
                {
                    rd_add.Checked = false;
                    ddl_bks.Visible = true;
                    ddl_bkStatus.Visible = true;
                    txt_bkName.Visible = false;
                    txt_AuthName.Visible = false;
                    txt_PubName.Visible = false;
                    ddl_bkStatus_add.Visible = false;
                }
                else if(Val == 1)
                {
                    rd_AddDis.Checked = false;
                    txt_DisPrice.Visible = false;
                    txt_DisDesc.Visible = false;
                }
            }
            catch(Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        private void fun_visibleStateForAdd(int Val)
        {
            try
            {
                if(Val == 0)
                {
                    rd_select.Checked = false;
                    txt_bkName.Visible = true;
                    txt_AuthName.Visible = true;
                    txt_PubName.Visible = true;
                    ddl_bkStatus_add.Visible = true;
                    ddl_bks.Visible = false;
                    ddl_bkStatus.Visible = false;
                }
                else if (Val == 1)
                {
                    rd_NoDis.Checked = false;
                    txt_DisPrice.Visible = true;
                    txt_DisDesc.Visible = true;
                }
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }
        protected void rd_select_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fun_visibleStateForSelect(0);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        protected void rd_add_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fun_visibleStateForAdd(0);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        protected void ddl_bks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        protected void rd_NoDis_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fun_visibleStateForSelect(1);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        protected void rd_AddDis_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fun_visibleStateForAdd(1);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string Result = string.Empty;
            try
            {
                fun_Get_BookDetails();
                Result = fun_ValidateTextBoxes(objClsDashCommonDto);
                if (Result != "1")
                {
                    lbl_infoMsg.ForeColor = Color.Red;
                    lbl_infoMsg.Text = Result;
                    return;
                }
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            try
            {
                fun_ClearControl();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        private void fun_ClearControl()
        {
            try
            {
                rd_select.Checked = true;
                rd_add.Checked = false;
                ddl_bks.ClearSelection();
                ddl_bkStatus.SelectedValue = "0";
                txt_bkName.Text = string.Empty;
                txt_AuthName.Text = string.Empty;
                txt_PubName.Text = string.Empty;
                ddl_bkStatus_add.SelectedValue = "0";
                txt_bkType.Text = string.Empty;
                txt_bkPrice.Text = string.Empty;
                ddl_CatbkStatus.SelectedValue = "0";
                txt_NoOfStocks.Text = string.Empty;
                txt_bkDesc.Text = string.Empty;
                file_Upload.Dispose();
                rd_NoDis.Checked = true;
                rd_AddDis.Checked = false;
                txt_DisPrice.Text = string.Empty;
                txt_DisDesc.Text = string.Empty;
                lbl_infoMsg.Text = string.Empty;
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        private void setFocus(TextBox objTextBox)
        {
            try
            {
                objTextBox.Focus();
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        private void fun_Get_BookDetails()
        {
            try
            {
                if (rd_select.Checked == true)
                {
                    objClsDashCommonDto.ddlBkName = ddl_bks.SelectedItem.Text;
                    objClsDashCommonDto.ddlBkID = Convert.ToInt32(ddl_bks.SelectedValue);
                    if (ddl_bkStatus.SelectedValue == "1")
                    {
                        objClsDashCommonDto.ddlBkStatus = 1;
                    }
                    else if (ddl_bkStatus.SelectedValue == "2")
                    {
                        objClsDashCommonDto.ddlBkStatus = 0;
                    }
                }
                else if (rd_add.Checked == true)
                {
                    objClsDashCommonDto.BkName = txt_bkName.Text.Trim();
                    objClsDashCommonDto.AuthName = txt_AuthName.Text.Trim();
                    objClsDashCommonDto.PubName = txt_PubName.Text.Trim();
                    if (ddl_bkStatus_add.SelectedValue == "1")
                    {
                        objClsDashCommonDto.ddlBkStatusadd = 1;
                    }
                    else if (ddl_bkStatus_add.SelectedValue == "2")
                    {
                        objClsDashCommonDto.ddlBkStatusadd = 0;
                    }
                }

                objClsDashCommonDto.BkType = txt_bkType.Text.Trim();
                objClsDashCommonDto.BkPrice = txt_bkPrice.Text.Trim();
                if (ddl_CatbkStatus.SelectedValue == "1")
                {
                    objClsDashCommonDto.ddlCartBkStatus = 1;
                }
                else if (ddl_CatbkStatus.SelectedValue == "2")
                {
                    objClsDashCommonDto.ddlCartBkStatus = 0;
                }
                objClsDashCommonDto.NumofStock = Convert.ToInt32(txt_NoOfStocks.Text.Trim());
                objClsDashCommonDto.BkDesc = txt_bkDesc.Text.Trim();
                if(file_Upload.HasFile == true)
                {
                    objClsDashCommonDto.BkImgName = file_Upload.FileName;
                }
                else
                {
                    objClsDashCommonDto.BkImgName = string.Empty;
                }

                if(rd_AddDis.Checked == true)
                {
                    objClsDashCommonDto.BkDisPrice = txt_DisPrice.Text.Trim();
                    objClsDashCommonDto.BkDisDesc = txt_DisDesc.Text.Trim();
                }
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
            }
        }

        public string fun_ValidateTextBoxes(ClsDashCommonDto objClsDashCommonDto)
        {
            try
            {
                return objClsFlowAddDetails.fun_ValidateTextBoxes(objClsDashCommonDto);
            }
            catch (Exception exMsg)
            {
                objClsLogWriter.ErrorLogWithParameters(exMsg, "v2vDashboard.aspx.cs");
                return string.Empty;
            }
        }
    }
}