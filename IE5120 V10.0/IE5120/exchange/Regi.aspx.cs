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
    public partial class Regi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //access user's input from web page
            string email = TextBox1.Text;
            string uname = TextBox2.Text;
            string pwd1 = TextBox4.Text;
            string pwd2 = TextBox5.Text;
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            string sql1 = "select * from Users where email='"+email+"'";
            con.Open();
            //create database connection and initialize sql commond
            //this sql is to check whether this user has already registered

            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            MySqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                //if result set is not empty, which this user has already registered,
                //pop up a dialog to remind user to login
                dr.Close();
                con.Close();
                Response.Write("<script language=javascript> alert('This email has been registered already, please login in directly'); </script>");
            }
            else
            {
                //if it is not able to find this user in User table,
                //that means this user can register a new id
                dr.Close();
                con.Close();
                string sql = "insert into Users value ('" + email + "','" + uname + "','" + pwd1 + "','" + email + "')";
                con.Open();
                //create database connection and initialize sql commond

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                //execute insert sql commond to insert this new user to User table

                con.Close();
                Session["uid"] = email;//assign the new user's email to session object
                Response.Redirect("ExchangeHomepage.aspx");//redirect page to exchange book homepage
            }
        }
    }
}