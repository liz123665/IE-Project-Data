using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace IE5120.exchange
{
    public partial class Contact : System.Web.UI.Page
    {
        string receiver = "";
        string msgsender = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            receiver = Request.QueryString["receiver"];//access the receiver of email
            msgsender = Session["uid"].ToString();//access current user email
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["uid"] = null;//terminate uid session object and log out
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //MailMessage message = new MailMessage();//create object for mail message
            //message.To.Add(new MailAddress(receiver)); // specify email receiver
            //message.From = new MailAddress("clou10@student.monash.com");//this is system email address
            //message.Subject = "Culkeeper";//email subject
            //string msgdetails = "Hello, there is one user contact you on culkeeper books exchange program, if you would like to contact back, please reply this email " + msgsender;
            ////description of email

            //message.Body = string.Format(msgdetails + TextBox1.Text);//details content of email
            //message.IsBodyHtml = true;
            //var smtp = new SmtpClient();//initialize smtp server variable
            //var credential = new NetworkCredential
            //{
            //    UserName = "clou10@student.monash.com"
            //};//initialie credential lisence
            //smtp.Credentials = credential;
            //smtp.Host = "smtp.monash.edu.au";//host name
            //smtp.Send(message);//send message
            Response.Write("<script language=javascript> alert('Message has been sent, please check your mail box for reply!');window.location='ExchangeBooksDetails.aspx' </script>");
        }

    }
}