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
    public partial class Order : System.Web.UI.Page
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
            cmd.CommandText = "SELECT o.id, c.nama, o.tanggal, o.status, o.kurir, o.is_delete FROM orders o LEFT JOIN customer c ON c.id = o.customer_id WHERE o.is_delete = 0";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT id,nama FROM customer WHERE is_delete = 0";
            comm.Connection = con;
            DataSet dst = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dst);
            ddCustomer.DataTextField = dst.Tables[0].Columns["nama"].ToString();
            ddCustomer.DataValueField = dst.Tables[0].Columns["id"].ToString();
            ddCustomer.DataSource = dst.Tables[0];
            ddCustomer.DataBind();

            SqlCommand comm2 = new SqlCommand();
            comm2.CommandText = "SELECT ordet.id, cust.nama as nama_customer, " +
                "ord.tanggal, " +
                "ord.status, " +
                "ord.kurir, " +
                "pro.nama as nama_product, " +
                "ordet.qty, " +
                "ord.is_delete FROM orders ord " +
                "INNER JOIN customer cust ON cust.id = ord.customer_id " +
                "INNER JOIN order_details ordet ON ordet.order_id = ord.id " +
                "INNER JOIN product pro ON pro.id = ordet.product_id " +
                "WHERE ord.is_delete = 0";
            comm2.Connection = con;
            DataSet dst2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(comm2);
            da2.Fill(dst2);
            gvOrderDetails.DataSource = dst2;
            gvOrderDetails.DataBind();

            con.Close();
        }

        public void ClearData()
        {
            txtID.Text = null;
            txtTanggal.Text = null;
            txtStatus.Text = null;
            txtKurir.Text = null;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "INSERT INTO orders " +
                "VALUES('" + ddCustomer.SelectedValue + "'," +
                "'" + txtTanggal.Text + "'," +
                "'" + txtStatus.Text + "'," +
                "'" + txtKurir.Text + "'," +
                "0) ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE orders SET " +
                "customer_id = '" + ddCustomer.SelectedValue + "'," +
                "tanggal = '" + txtTanggal.Text + "'," +
                "status = '" + txtStatus.Text + "'," +
                "kurir = '" + txtKurir.Text + "'" +
                "WHERE id = '" + txtID.Text + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "UPDATE orders SET is_delete = 1 WHERE id = '" + txtID.Text + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void GridViewJoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = GridViewJoin.SelectedRow.Cells[0].Text;
            string customer = GridViewJoin.SelectedRow.Cells[1].Text;
            DateTime tanggal = DateTime.Parse(GridViewJoin.SelectedRow.Cells[2].Text);
            string status = GridViewJoin.SelectedRow.Cells[3].Text;
            string kurir = GridViewJoin.SelectedRow.Cells[4].Text;

            txtID.Text = idd;
            ddCustomer.SelectedIndex = ddCustomer.Items.IndexOf(ddCustomer.Items.FindByText(customer));
            txtTanggal.Text = tanggal.ToString("yyyy-MM-dd");
            txtStatus.Text = status;
            txtKurir.Text = kurir;
        }

        protected void GridViewJoin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridViewJoin, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            
        }
    }
}