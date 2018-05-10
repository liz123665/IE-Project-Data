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
    public partial class DeleteBooks : System.Web.UI.Page
    {
        //initialize some variables need to be displayed on web page
        public string isbn = "";//isbn number of book
        public string title = "";//book name
        public string publisher = "";//book publisher
        public string author = "";//author of book
        public string year = "";//publish year of book
        protected void Page_Load(object sender, EventArgs e)
        {
            isbn = Request.QueryString["isbn"].ToString();
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            string sql = "select * from Book where ISBN='" + isbn + "'";
            con.Open();
            //establish database connection and define sql commond and open the connection

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            //initialize commondwith connection and execute sql commond

            if (dr.Read())
            {
                //if there is result set, assign variable below to each item
                //and display these variables on web page
                isbn = dr["ISBN"].ToString();
                title = dr["Title"].ToString();
                publisher = dr["Publisher"].ToString();
                author = dr["Author"].ToString();
                year = dr["Year"].ToString();
            }
            dr.Close();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Session["uid"].ToString();//access user id from session object
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            string sql = "delete from User_Books where id='"+id+"' and isbn='"+isbn+"'";
            con.Open();
            //initialize commondwith connection and execute sql commond

            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            //initialize commondwith connection and execute sql commond
            //execute delete sql commond

            con.Close();
            Response.Write("<script language=javascript> alert('The book has been removed from your book list successfully!');window.location='MyBooks.aspx'; </script>");
            //pop up a dialog to inform user that the book has been deleted and redirect page to my books page
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["uid"] = null;//terminate session object and redirect to login page
            Response.Redirect("Login.aspx");
        }
    }
}