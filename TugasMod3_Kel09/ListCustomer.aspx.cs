using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace TugasMod3_Kel09
{
    public partial class ListCustomer : System.Web.UI.Page
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

        public void DataShow()
        {
            ClearData();
            ds = new DataSet();
            cmd.CommandText = "SELECT * FROM customer WHERE is_delete = 0";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();
            con.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "INSERT INTO customer VALUES('" + txtNama.Text + "','" + txtAlamat.Text + "','" + txtNohp.Text + "',0) ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE customer SET nama = '" + txtNama.Text + "', alamat = '" + txtAlamat.Text + "',no_hp = '" + txtNohp.Text + "' WHERE id = '" + txtID.Text + "' ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE customer SET is_delete = 1 WHERE id = '" + txtID.Text + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void ClearData()
        {
            txtID.Text = null;
            txtNama.Text = null;
            txtAlamat.Text = null;
            txtNohp.Text = null;
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
            string alamat = GridViewJoin.SelectedRow.Cells[2].Text;
            string nohp = GridViewJoin.SelectedRow.Cells[3].Text;
            txtID.Text = idd;
            txtNama.Text = nama;
            txtAlamat.Text = alamat;
            txtNohp.Text = nohp;
        }

        
    }
}