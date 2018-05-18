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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"]!=null)
            {
                Response.Redirect("ExchangeHomepage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string pwd = TextBox2.Text;
            //access email and password input from web page

            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            string sql = "select * from Users where email='" + email + "' and pwd='"+pwd+"'";
            con.Open();
            //create database connection and initialize sql commond to search for user in User table

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            //execute sql commond

            if (dr.Read())
            {
                //if there is result set, which this user exist, create session object and assign this user's email to session object
                Session["uid"] = dr["id"].ToString();
                Response.Redirect("ExchangeHomepage.aspx");//if login has been verified, redirect to exchange book homepage
                dr.Close();
                con.Close();
            }
            else
            {
                Label1.Visible = true; //if it is not able to find any of user's details in User table, make the error message label visuable               
            }
            
        }
    }
}