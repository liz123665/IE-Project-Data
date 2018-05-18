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
    public partial class BooksDetails : System.Web.UI.Page
    {
        public string isbn = "";//initialize variable isbn
        public string title = "";//initialize variable title, which is book name
        public string publisher = "";//initialize variable publisher, which is publisher of book
        public string author = "";//initialize variable author, which is author of book
        public string year = "";//initialize variable year, which is publisher year of book
        protected void Page_Load(object sender, EventArgs e)
        {
            isbn = Request.QueryString["isbn"];//access the isbn, using request object to access the variable
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            string sql = "select * from Books where ISBN='" + isbn + "'";
            //initialize sql query commond
            con.Open();
            //create database connection and open connection

            MySqlCommand cmd = new MySqlCommand(sql, con);
            //createcmd to execute query 

            MySqlDataReader dr = cmd.ExecuteReader();
            //execute sql query and store data in resultset

            if (dr.Read())
            {//if there is result set
                isbn = dr["ISBN"].ToString();//assign isbn
                title = dr["Title"].ToString();//assign title
                publisher = dr["Publisher"].ToString();//assign publisher
                author = dr["Author"].ToString();//assign author
                year = dr["Year"].ToString();//assign year
            }
            dr.Close();
            con.Close();
            //close connection of database for next query
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Session["uid"].ToString();//access user id by access session variable
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            string sql1 = "select * from User_Books where id='"+id+"' and isbn='"+isbn+"'";
            con.Open();
            //initialize sql commond and open connection of database

            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            MySqlDataReader dr = cmd1.ExecuteReader();
            //initialize cmd1 to execute sql commond

            if (dr.Read())
            {
                //if result set is not null, which means the book can be found in database. therefore it is not allowed to add a duplicated book in database
                Response.Write("<script language=javascript> alert('This book is in your book list already'); </script>");
                //pop up a dialog to inform user that this book has exist in the book list already

                dr.Close();
                con.Close();//close connection of database
            }
            else
            {
                //if the previous query return null result, which means this book can be added to list
                dr.Close();
                con.Close();
                string sql = "insert into User_Books value ('" + id + "','" + isbn + "')";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                //execute insert operation and add book into list

                con.Close();
                Response.Write("<script language=javascript> alert('the books has been successfully posted to the books exchange market!'); </script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Allbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //terminate session object uid and log out
            Session["uid"] = null;
            Response.Redirect("Login.aspx");
        }

    }
}