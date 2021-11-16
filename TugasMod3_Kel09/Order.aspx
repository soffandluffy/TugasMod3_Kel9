<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="TugasMod3_Kel09.Order" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product</title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton  ID="btnCustomer" runat="server" PostBackUrl="ListCustomer.aspx"><span style="margin-right: 30px;">Customer</span></asp:LinkButton>
            <asp:LinkButton ID="btnProduct" runat="server" PostBackUrl="Product.aspx"><span style="margin-right: 30px;">Product</span></asp:LinkButton>
            <asp:LinkButton ID="btnDeleted" runat="server" PostBackUrl="Deleted.aspx">Deleted</asp:LinkButton>
            <table>
                <tr>
                <td class="auto-style1">ID :</td>
                <td class="auto-style1"><asp:TextBox ID="txtID" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>Customer :</td>
                <td><asp:DropDownList ID="ddCustomer" Width="165px" runat="server"></asp:DropDownList> </td>
                </tr>
                <tr>
                <td>Tanggal :</td>
                <td><asp:TextBox ID="txtTanggal" runat="server" TextMode="Date"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>Status :</td>
                <td><asp:TextBox ID="txtStatus" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>Kurir :</td>
                <td><asp:TextBox ID="txtKurir" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click" />

                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridViewJoin" runat="server" DataKeyNames="id,nama,tanggal,status,kurir" OnRowDataBound="GridViewJoin_RowDataBound" OnSelectedIndexChanged="GridViewJoin_SelectedIndexChanged">
        </asp:GridView>
        <h3>Order Details</h3>
        <asp:GridView ID="gvOrderDetails" runat="server" DataKeyNames="id">
        </asp:GridView>
    </form>
</body>
</html>
