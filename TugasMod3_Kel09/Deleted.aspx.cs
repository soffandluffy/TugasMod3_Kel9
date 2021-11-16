using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace TugasMod3_Kel09
{
    public partial class Deleted : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=SOFFANMA\\SQLEXPRESS;Initial Catalog=TugasMod3SBDKel9;Integrated Security=True";
            con.Open();
            if (!Page.IsPostBack)
            {
                DataShow();
            }
            
        }

        private void DataShow()
        {
            ds = new DataSet();
            cmd.CommandText = "SELECT * FROM product WHERE is_delete = 1";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            gvProduct.DataSource = ds;
            gvProduct.DataBind();

            DataSet ds2 = new DataSet();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "SELECT o.id, c.nama, o.tanggal, o.status, o.kurir, o.is_delete FROM orders o LEFT JOIN customer c ON c.id = o.customer_id WHERE o.is_delete = 1";
            cmd2.Connection = con;
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(ds2);
            cmd2.ExecuteNonQuery();
            gvOrders.DataSource = ds2;
            gvOrders.DataBind();

            DataSet ds3 = new DataSet();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SELECT * FROM customer WHERE is_delete = 1";
            cmd3.Connection = con;
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            sda3.Fill(ds3);
            cmd3.ExecuteNonQuery();
            gvCustomer.DataSource = ds3;
            gvCustomer.DataBind();

            con.Close();
        }

        protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvProduct, "Select$" + e.Row.RowIndex);
                e.Row.Cells[5].Attributes["style"] = "cursor:pointer";
            }
        }


        protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = gvProduct.SelectedRow.Cells[0].Text;
            cmd.CommandText = "UPDATE product SET is_delete = 0 WHERE id = '" + idd + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void gvCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvProduct, "Select$" + e.Row.RowIndex);
                e.Row.Cells[4].Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = gvProduct.SelectedRow.Cells[0].Text;
            cmd.CommandText = "UPDATE customer SET is_delete = 0 WHERE id = '" + idd + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvProduct, "Select$" + e.Row.RowIndex);
                e.Row.Cells[5].Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = gvProduct.SelectedRow.Cells[0].Text;
            cmd.CommandText = "UPDATE orders SET is_delete = 0 WHERE id = '" + idd + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }
    }
}