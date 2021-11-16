<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deleted.aspx.cs" Inherits="TugasMod3_Kel09.Deleted" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deleted</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="btnCustomer" runat="server" PostBackUrl="ListCustomer.aspx"><span style="margin-right: 30px;">Customer</span></asp:LinkButton>
            <asp:LinkButton  ID="btnOrder" runat="server" PostBackUrl="Order.aspx"><span style="margin-right: 30px;">Order</span></asp:LinkButton>
            <asp:LinkButton ID="btnProduct" runat="server" PostBackUrl="Product.aspx"><span style="margin-right: 30px;">Product</span></asp:LinkButton>
            <h3>Customer</h3>
            <asp:GridView ID="gvCustomer" runat="server" DataKeyNames="id,nama,alamat,no_hp" OnRowDataBound="gvCustomer_RowDataBound" OnSelectedIndexChanged="gvCustomer_SelectedIndexChanged" >
            </asp:GridView>
            <h3>Product</h3>
            <asp:GridView ID="gvProduct" runat="server" DataKeyNames="id,nama,harga,berat,stok" OnRowDataBound="gvProduct_RowDataBound" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" >
            </asp:GridView>
            <h3>Orders</h3>
            <asp:GridView ID="gvOrders" runat="server" DataKeyNames="id,nama,tanggal,status,kurir" OnRowDataBound="gvOrders_RowDataBound" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
