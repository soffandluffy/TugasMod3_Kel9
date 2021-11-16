<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCustomer.aspx.cs" Inherits="TugasMod3_Kel09.ListCustomer" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer</title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton  ID="btnOrder" runat="server" PostBackUrl="Order.aspx"><span style="margin-right: 30px;">Order</span></asp:LinkButton>
            <asp:LinkButton ID="btnProduct" runat="server" PostBackUrl="Product.aspx"><span style="margin-right: 30px;">Product</span></asp:LinkButton>
            <asp:LinkButton ID="btnDeleted" runat="server" PostBackUrl="Deleted.aspx">Deleted</asp:LinkButton>
            <table>
                <tr>
                <td>ID :</td>
                <td><asp:TextBox ID="txtID" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>Nama :</td>
                <td><asp:TextBox ID="txtNama" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>Alamat :</td>
                <td><asp:TextBox ID="txtAlamat" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>No Hp :</td>
                <td><asp:TextBox ID="txtNohp" runat="server"></asp:TextBox></td>
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
        <asp:GridView ID="GridViewJoin" runat="server" DataKeyNames="id,nama,alamat,no_hp" OnRowDataBound="GridViewJoin_RowDataBound" OnSelectedIndexChanged="GridViewJoin_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>
