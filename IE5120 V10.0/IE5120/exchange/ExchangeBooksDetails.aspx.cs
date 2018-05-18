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
    public partial class ExchangeBooksDetails : System.Web.UI.Page
    {
        string isbn = "";
        string uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = Session["uid"].ToString();
            if (Request.QueryString["isbn"] == null)
            {
                //if request object is null, assign isbn as variable in session object,
                //this step is to avoid error when page is redirected from contact page
                isbn = Session["isbn_number"].ToString();
            }
            else
            {                
                //is request object exist, assign isbn as request object
                isbn = Request.QueryString["isbn"].ToString();
                Session["isbn_number"] = isbn;//and assign session object to isbn as well
            }
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            string sql = "select distinct b.ISBN,b.Title,b.Publisher,b.Author,b.Year,u.username,u.email,u.id from User_Books ub,Books b,Users u where ub.isbn=b.ISBN and u.id=ub.id and b.ISBN='"+isbn+"' and ub.id != '"+uid+"'";
            //create database connection and initialize sql commond

            MySqlCommand cmd = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
            dr.Fill(ds);
            //using dataadapter to fill in dataset

            this.ListView1.DataSource = ds;
            this.ListView1.DataBind();
            //bind data to list view

            con.Close();
        }

        void cnnDB()//this function is for database connection
        {
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            string sql = "select distinct b.ISBN,b.Title,b.Publisher,b.Author,b.Year,u.username,u.email,u.id from User_Books ub,Books b,Users u where ub.isbn=b.ISBN and u.id=ub.id and b.ISBN='" + isbn + "' and ub.id != '"+uid+"'";
            //create database connection and initialize sql commond

            MySqlCommand cmd = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
            dr.Fill(ds);
            //using dataadapter to fill in dataset

            this.ListView1.DataSource = ds;
            this.ListView1.DataBind();
            //bind data to list view

            con.Close();
        }        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["uid"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExchangeBooks.aspx");
        }
    }
}