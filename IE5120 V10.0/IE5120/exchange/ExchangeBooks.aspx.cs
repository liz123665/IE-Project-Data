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
    public partial class ExchangeBooks : System.Web.UI.Page
    {
        string book_culture = "";//initialize the variable book_culture
        string uid = "";//initialiaze the variable uid
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = Session["uid"].ToString();//access the session object to assign variable uid
            if (Session["book_culture"] == null)
            {//if session object 'book_culture' doesn't exist, assign book_culture is "", this is for sql query
                book_culture = "";
            }
            else
            {//if session object 'book_culture' is not null, assign a new variable to book_culture
                book_culture = Session["book_culture"].ToString();
            }
            if (book_culture.Equals(""))
            {//highlight page element 'All'
                LinkButton2.Style.Add("Color","#48cfad");
            }else if (book_culture.Equals("China"))
            {//highlight page element 'China'
                LinkButton3.Style.Add("Color", "#48cfad");
            }
            else if (book_culture.Equals("India"))
            {//highlight page element 'India'
                LinkButton4.Style.Add("Color", "#48cfad");
            }
            else if (book_culture.Equals("Italy"))
            {//highlight page element 'Italy'
                LinkButton5.Style.Add("Color", "#48cfad");
            }
            if (!Page.IsPostBack)
            {           
                string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
                MySqlConnection con = new MySqlConnection(conn);
                con.Open();
                //create database connection and open the connection

                string sql = "select distinct b.ISBN,b.Title,b.Publisher,b.Author,b.Year,b.Culture,b.Description from User_Books ub,Books b where ub.isbn=b.ISBN and b.Culture like '%"+book_culture+"%' and ub.id!='"+uid+"'";
                //initialize sql query, access isbn,book title, publisher, author, publish year and culture

                MySqlCommand cmd = new MySqlCommand(sql, con);
                //create cmd variable to execute sql query

                DataSet ds = new DataSet();
                //initialize dataset variable for store resultset

                MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
                //initialize dataadapter to access resultset from database

                dr.Fill(ds);
                //pass dataset variable to dataadapter

                this.ListView1.DataSource = ds;
                this.ListView1.DataBind();
                //bind the resultset to list view at web page
                con.Close();//close connection for next sql query execution
            }
        }

        void cnnDB()//this function is for database connection
        {
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            //create database connection and open the connection

            string sql = "select distinct b.ISBN,b.Title,b.Publisher,b.Author,b.Year,b.Culture,b.Description from User_Books ub,Books b where ub.isbn=b.ISBN and b.Culture like '%" + book_culture + "%' and ub.id!='"+uid+"'";
            //initialize sql query, access isbn,book title, publisher, author, publish year and culture

            MySqlCommand cmd = new MySqlCommand(sql, con);
            //initialize dataset variable for store resultset
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);//read from database
            DataSet ds = new DataSet();
            dr.Fill(ds);//fill in ds variable by dr

            this.ListView1.DataSource = ds;// Assign datasource variable to listview
            this.ListView1.DataBind();// Bind data to listview
            con.Close();//close connection for next query execution
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string keyword = TextBox1.Text;
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            //create database connection and open the connection

            string sql = "select distinct b.ISBN,b.Title,b.Publisher,b.Author,b.Year,b.Culture,b.Description from User_Books ub,Books b where ub.isbn=b.ISBN and b.Culture like '%" + book_culture + "%' and b.Title like '%" + keyword + "%' and ub.id!='"+uid+"'";
            //initialize sql query, access isbn,book title, publisher, author, publish year and culture

            MySqlCommand cmd = new MySqlCommand(sql, con);
            //initialize dataset variable for store resultset

            DataSet ds = new DataSet();
            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);
            dr.Fill(ds);
            //fill in ds variable by dr

            this.ListView1.DataSource = ds;// Assign datasource variable to listview
            this.ListView1.DataBind();// Bind data to listview
            con.Close();//close connection for next query execution
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            //control datapager component
            cnnDB();
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            string keyword = TextBox1.Text;
            string conn = "Data Source=ie5120mysql.cgos91z1jnbd.ap-southeast-2.rds.amazonaws.com;User ID=itmaniacs;Password=itmaniacs;DataBase=ie5120mysql";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            //create database connection and open the connection

            string sql = "select distinct b.ISBN,b.Title,b.Publisher,b.Author,b.Year,b.Culture,b.Description from User_Books ub,Books b where ub.isbn=b.ISBN and b.Culture like '%" + book_culture + "%' and b.Title like '%" + keyword + "%' and ub.id!='"+uid+"'";
            //initialize sql query, access isbn,book title, publisher, author, publish year and culture

            MySqlCommand cmd = new MySqlCommand(sql, con);
            //initialize dataset variable for store resultset

            MySqlDataAdapter dr = new MySqlDataAdapter(sql, con);//read from database
            DataSet ds = new DataSet();
            dr.Fill(ds);//fill in ds variable by dr
            this.ListView1.DataSource = ds;// Assign datasource variable to listview
            this.ListView1.DataBind();// Bind data to listview
            con.Close();//close connection for next query execution
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //terminate uid session object and redirect to login page
            Session["uid"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //redirect to exchenge books page
            Response.Redirect("ExchangeBooks.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //terminate book_culture session object and redirect to books exchange page
            Session["book_culture"] = null;
            Response.Redirect("ExchangeBooks.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //change content of session to china and redirect to books exchange page
            Session["book_culture"] = "China";
            Response.Redirect("ExchangeBooks.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //change content of session to india and redirect to books exchange page
            Session["book_culture"] = "India";
            Response.Redirect("ExchangeBooks.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //change content of session to italy and redirect to books exchange page
            Session["book_culture"] = "Italy";
            Response.Redirect("ExchangeBooks.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExchangeHomepage.aspx");
        }
    }
}