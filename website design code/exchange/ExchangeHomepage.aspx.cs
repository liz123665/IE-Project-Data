using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IE5120.exchange
{
    public partial class ExchangeHomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"]==null)
            {
                //if user has not login, redirect user to login page
                Response.Redirect("Login.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["uid"] = null;//terminate uid session object and redirect to login page
            Response.Redirect("Login.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //if image button is clicked, redirect the page
            Response.Redirect("ExchangeBooks.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //if image button is clicked, redirect the page
            Response.Redirect("MyBooks.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //if image button is clicked, redirect the page
            Response.Redirect("Allbooks.aspx");
        }
    }
}