using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TugasMod3_Kel09
{
    public partial class Product : System.Web.UI.Page
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
            ClearData();
            ds = new DataSet();
            cmd.CommandText = "SELECT * FROM product WHERE is_delete = 0";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();
            con.Close();
        }

        private void ClearData()
        {
            txtID.Text = null;
            txtNama.Text = null;
            txtHarga.Text = null;
            txtBerat.Text = null;
            txtStok.Text = null;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "INSERT INTO product VALUES('" + txtNama.Text + "'," +
                "'" + txtHarga.Text + "'," +
                "'" + txtBerat.Text + "'," +
                "'" + txtStok.Text + "'," +
                "0) ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE product SET is_delete = 1 WHERE id = '" + txtID.Text + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE product SET nama = '" + txtNama.Text + "'," +
                "harga = '" + txtHarga.Text + "'," +
                "berat = '" + txtBerat.Text + "'," +
                "stok = '" + txtStok.Text + "'" +
                "WHERE id = '" + txtID.Text + "' ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void GridViewJoin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridViewJoin, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridViewJoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = GridViewJoin.SelectedRow.Cells[0].Text;
            string nama = GridViewJoin.SelectedRow.Cells[1].Text;
            string harga = GridViewJoin.SelectedRow.Cells[2].Text;
            string berat = GridViewJoin.SelectedRow.Cells[3].Text;
            string stok = GridViewJoin.SelectedRow.Cells[4].Text;
            txtID.Text = idd;
            txtNama.Text = nama;
            txtHarga.Text = harga;
            txtBerat.Text = berat;
            txtStok.Text = stok;
        }
    }
}