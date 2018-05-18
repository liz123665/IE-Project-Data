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
    public partial class Allbooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
                MySqlConnection con = new MySqlConnection(conn);
                con.Open();
                //create database connection and open connection

                string sql = "select * from Books";
                //initialize sql query commond

                MySqlCommand cmd = new MySqlCommand(sql, con);
                //createcmd to execute query 

                DataSet ds = new DataSet();
                MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
                dr.Fill(ds);
                //use dataset variable to fill in dataadapter

                this.ListView1.DataSource = ds;
                this.ListView1.DataBind();
                //bind dataset to list view of webpage

                con.Close();//close connection for next query execution
            }
        }

        void cnnDB()//this function is for database connection
        {
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            //create database connection and open connection

            string sql = "select * from Books";
            //initialize sql query commond

            MySqlCommand cmd = new MySqlCommand(sql, con);
            //create cmd to execute query

            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);//read from database
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string keyword = TextBox1.Text;//access variable from web page which element's id is Textbox1
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            //create database connection and open connection

            string sql = "select * from Books where Title like '%" + keyword + "%'";
            //create sql commond

            MySqlCommand cmd = new MySqlCommand(sql, con);
            //to execute sql commond

            DataSet ds = new DataSet();
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
            dr.Fill(ds);
            //execute dataadapter to fill in dataset    

            this.ListView1.DataSource = ds;
            this.ListView1.DataBind();
            //bind data to list view of web page

            con.Close();//close connection for next query
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            string keyword = TextBox1.Text;
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            //create database connection and open connection

            string sql = "select * from Books where Title like '%" + keyword + "%'";
            //create sql commond

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);//read from database
            DataSet ds = new DataSet();
            dr.Fill(ds);//fill in ds variable by dr
            this.ListView1.DataSource = ds;// Assign datasource variable to listview
            this.ListView1.DataBind();// Bind data to listview
            con.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //terminate session uid and sign out, redirect to login page
            Session["uid"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //view all books, refresh this page
            Response.Redirect("Allbooks.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExchangeHomepage.aspx");
        }
    }
}