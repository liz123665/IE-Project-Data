using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace IE5120.exchange
{
    public partial class MyBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Session["uid"].ToString();//access user id from session object
                string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
                MySqlConnection con = new MySqlConnection(conn);
                con.Open();
                string sql = "select ub.id,b.ISBN,b.Title,b.Publisher from Books b,User_Books ub where ub.id='" + id + "' and b.ISBN=ub.isbn";
                //create database connection and initialize sql commond, this sql commond is to
                //select the books user have already posted to book list

                MySqlCommand cmd = new MySqlCommand(sql, con);
                DataSet ds = new DataSet();
                MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
                dr.Fill(ds);
                this.ListView1.DataSource = ds;
                this.ListView1.DataBind();
                con.Close();
            }
        }

        void cnnDB()//this function is for database connection
        {
            string id = Session["uid"].ToString();//access user id from session object
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            string sql = "select ub.id,b.ISBN,b.Title,b.Publisher from Books b,User_Books ub where ub.id='" + id + "' and b.ISBN=ub.isbn";
            //create database connection and initialize sql commond, this sql commond is to
            //select the books user have already posted to book list

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
            //execute sql commond

            DataSet ds = new DataSet();
            dr.Fill(ds);//fill in ds variable by dr
            this.ListView1.DataSource = ds;// Assign datasource variable to listview
            this.ListView1.DataBind();// Bind data to listview
            con.Close();
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            //control datapager component
            cnnDB();
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            string id = Session["uid"].ToString();//access user id from session object
            string keyword = TextBox1.Text;
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            string sql = "select ub.id,b.ISBN,b.Title,b.Publisher from Books b,User_Books ub where ub.id='" + id + "' and b.ISBN=ub.isbn and b.Title like '%" + keyword + "%'";
            //create database connection and initialize sql commond, this sql commond is to
            //select the books user have already posted to book list

            MySqlCommand cmd = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
            //execute sql commond

            dr.Fill(ds);//fill in data adapter by using dataset
            this.ListView1.DataSource = ds;
            this.ListView1.DataBind();
            //bind dataset to list view

            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Session["uid"].ToString();//access user id from session object
            string keyword = TextBox1.Text;
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            string sql = "select ub.id,b.ISBN,b.Title,b.Publisher from Books b,User_Books ub where ub.id='" + id + "' and b.ISBN=ub.isbn and b.Title like '%" + keyword + "%'";
            //create database connection and initialize sql commond, this sql commond is to
            //select the books user have already posted to book list

            MySqlCommand cmd = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
            dr.Fill(ds);
            //fill in data adapter by using dataset

            this.ListView1.DataSource = ds;
            this.ListView1.DataBind();
            //bind dataset to list view

            con.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //terminate session object and redirect to login page
            Session["uid"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBooks.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExchangeHomepage.aspx");
        }
    }
}