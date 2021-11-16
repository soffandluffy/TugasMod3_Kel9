<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="TugasMod3_Kel09.Product" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product</title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton  ID="btnOrder" runat="server" PostBackUrl="Order.aspx"><span style="margin-right: 30px;">Order</span></asp:LinkButton>
            <asp:LinkButton ID="btnCustomer" runat="server" PostBackUrl="ListCustomer.aspx"><span style="margin-right: 30px;">Customer</span></asp:LinkButton>
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
                <td>Harga :</td>
                <td><asp:TextBox ID="txtHarga" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>Berat :</td>
                <td><asp:TextBox ID="txtBerat" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                <td>Stok :</td>
                <td><asp:TextBox ID="txtStok" runat="server"></asp:TextBox></td>
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
        <asp:GridView ID="GridViewJoin" runat="server" DataKeyNames="id,nama,harga,berat,stok" OnRowDataBound="GridViewJoin_RowDataBound" OnSelectedIndexChanged="GridViewJoin_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>
