<%@ Page Title="" Language="C#" MasterPageFile="~/v2v_Dashboard.Master" AutoEventWireup="true" CodeBehind="v2v_AddDetails.aspx.cs" Inherits="v2vDashboard.v2v_AddDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" lang="javascript">
        function txtBoxSpaceChk(event) {
            if (window.event.keyCode == 32) {
                return false;
            }

            if (window.event.keyCode == 13) {
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        *{
            user-select:none;
        }
        .bookdetails{
            width:100%;
            height:100%;
            background-color:#ececec;
            overflow-x:hidden;
            overflow-y:scroll;
        }
        .CartMainDiv{
            position:relative;
            width:100%;
            height:100%;
            display:flex;
            justify-content:center;
            flex-direction:column;
            margin: 0 15px;
        }
        .div_CartHead{
            width:100%;
            margin:15px 0 25px 0;
            display:flex;
            align-items:center;
            justify-content:center;
        }
        .CartHead{
            text-transform:uppercase;
            font-size:19px;
        }
        .div_rdbtn{
            display:flex;
            align-items:center;
            justify-content:center;
            flex-wrap:wrap;
        }
        .rd{
            text-transform:uppercase;
            font-size:14px;
            font-weight:500;
            margin:0 10px;
        }
        .SelectBk{
            margin-top:15px;
            display:flex;
            align-items:center;
            justify-content:center;
            flex-wrap:wrap;
        }
        .ddl{
            width:110px;
            height:35px;
            padding:0 5px;
            text-transform:uppercase;
            border-radius:6px;
            margin:15px 10px;
        }
        .ddlbkName{
            width:300px;
            height:35px;
            padding:0 5px;
            text-transform:uppercase;
            border-radius:6px;
            margin:15px 10px;
        }
        .txtCart{
            width:250px;
            height:33px;
            padding: 0 12px;
            text-transform:capitalize;
            border-radius:6px;
            font-size:14px;
            margin:15px 0;
        }
        .txt_Desc{
            width:400px;
            height:50px;
            padding:15px 20px;
            margin:15px 0;
            border-radius:6px;
            font-size:14px;
        }
        .txtBoxDiv{
            display:flex;
            align-items:center;
            justify-content:space-evenly;
            flex-wrap:wrap;
        }
        .txtboxsForCategoryBks{
            margin-top:15px;
            display:flex;
            align-items:center;
            justify-content:space-evenly;
            flex-wrap:wrap;
        }
        .div_discount{
            width:100%;
            display:flex;
            align-items:center;
            justify-content:space-evenly;
            flex-wrap:wrap;
        }
        .btn_divsubmit{
            width:100%;
            display:flex;
            align-items:center;
            justify-content:center;
            flex-direction:column;
            flex-wrap:wrap;
            margin:30px 0;
        }
        .btnSubmit{
            padding:10px 30px;
            text-transform:uppercase;
            font-size:15px;
            background-color:royalblue;
            color:white;
            border-radius:6px;
            margin-bottom:15px;
        }
        .Clearbtn{
            background-color:gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bookdetails">
        <section class="SecCart" id="SecCart">
             <div class="CartMainDiv">
                 <div class="div_CartHead">
                    <h4 class="CartHead">Add to Our Cart</h4>
                </div>

                 <div class="div_rdbtn">
                     <asp:RadioButton ID="rd_select" CssClass="rd" Text=" Select Book" runat="server" AutoPostBack="true" OnCheckedChanged="rd_select_CheckedChanged" />
                     <asp:RadioButton ID="rd_add" CssClass="rd" Text=" Add Books" runat="server" AutoPostBack="true" OnCheckedChanged="rd_add_CheckedChanged" />
                 </div>

                 <div class="SelectBk">
                     <asp:DropDownList ID="ddl_bks" CssClass="ddlbkName" runat="server" OnSelectedIndexChanged="ddl_bks_SelectedIndexChanged"></asp:DropDownList>
                     <asp:DropDownList ID="ddl_bkStatus" CssClass="ddl" runat="server">
                         <asp:ListItem Value="0">[ SELECT ]</asp:ListItem>
                         <asp:ListItem Value="1">Active</asp:ListItem>
                         <asp:ListItem Value="2">InActive</asp:ListItem>
                     </asp:DropDownList>
                </div>

                 <div class="txtBoxDiv">
                     <asp:TextBox ID="txt_bkName" CssClass="txtCart" autocomplete="off" placeholder="BOOK NAME *" TextMode="SingleLine" runat="server"></asp:TextBox>
                     <asp:TextBox ID="txt_AuthName" CssClass="txtCart" autocomplete="off" placeholder="AUTHOR NAME" TextMode="SingleLine" runat="server"></asp:TextBox>
                     <asp:TextBox ID="txt_PubName" CssClass="txtCart" autocomplete="off" placeholder="PUBLISHER NAME" TextMode="SingleLine" runat="server"></asp:TextBox>
                     <asp:DropDownList ID="ddl_bkStatus_add" CssClass="ddl" runat="server">
                         <asp:ListItem Value="0">[ SELECT ]</asp:ListItem>
                         <asp:ListItem Value="1">Active</asp:ListItem>
                         <asp:ListItem Value="2">InActive</asp:ListItem>
                     </asp:DropDownList>
                </div>

                 <div class="txtboxsForCategoryBks">
                     <asp:TextBox ID="txt_bkType" CssClass="txtCart" autocomplete="off" placeholder="BOOK TYPE *" TextMode="SingleLine" runat="server"></asp:TextBox>
                     <asp:TextBox ID="txt_bkPrice" CssClass="txtCart" autocomplete="off" MaxLength="10" onkeypress="return txtBoxSpaceChk(event)" placeholder="PRICE *" TextMode="SingleLine" runat="server"></asp:TextBox>
                     <asp:DropDownList ID="ddl_CatbkStatus" CssClass="ddl" runat="server">
                         <asp:ListItem Value="0">[ SELECT ]</asp:ListItem>
                         <asp:ListItem Value="1">Active</asp:ListItem>
                         <asp:ListItem Value="2">InActive</asp:ListItem>
                     </asp:DropDownList>
                     <asp:TextBox ID="txt_NoOfStocks" CssClass="txtCart" autocomplete="off" onkeypress="return txtBoxSpaceChk(event)" MaxLength="2" placeholder="NO.OF STOCKS *" TextMode="SingleLine" runat="server"></asp:TextBox>
                     <asp:TextBox ID="txt_bkDesc" CssClass="txt_Desc" autocomplete="off" MaxLength="100" placeholder="BOOK DESCRIPTION *" TextMode="MultiLine" runat="server"></asp:TextBox>
                     <asp:FileUpload ID="file_Upload" placeholder="Image Upload" CssClass="txtCart" runat="server" />
                 </div>

                 <div class="div_rdbtn" style="margin-top:10px;">
                     <asp:RadioButton ID="rd_NoDis" CssClass="rd" AutoPostBack="true" Text=" No Discount" runat="server" OnCheckedChanged="rd_NoDis_CheckedChanged" />
                     <asp:RadioButton ID="rd_AddDis" CssClass="rd" AutoPostBack="true" Text=" Add Discounts" runat="server" OnCheckedChanged="rd_AddDis_CheckedChanged" />
                 </div>

                 <div class="div_discount">
                    <asp:TextBox ID="txt_DisPrice" CssClass="txtCart" autocomplete="off" MaxLength="10" onkeypress="return txtBoxSpaceChk(event)" Rows="5" placeholder="DISCOUNT PRICE *" TextMode="SingleLine" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txt_DisDesc" CssClass="txt_Desc" autocomplete="off" MaxLength="100" placeholder="DISCOUNT DESCRIPTION *" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>

                 <div class="btn_divsubmit">
                    <div class="btn_part">
                        <asp:Button ID="btn_submit" runat="server" CssClass="btnSubmit" Text="Submit" OnClick="btn_submit_Click" />
                        <asp:Button ID="btn_clear" runat="server" CssClass="btnSubmit Clearbtn" Text="Clear" OnClick="btn_clear_Click" />
                    </div>
                    <asp:Label ID="lbl_infoMsg" runat="server" ForeColor="Green" CssClass="lblinfo"></asp:Label>
                </div>

             </div>
        </section>
    </div>
</asp:Content>
