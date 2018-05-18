using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IE5120.exchange
{
    public partial class Culture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Session["cul"] = "China";//if link button 1 is clicked, assign session variable to china
        //}

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    Session["cul"] = "Italy";//if link button 2 is clicked, assign session variable to italy
        //}

        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    Session["cul"] = "India";//if link button 3 is clicked, assign session variable to india
        //}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["culture"] = "china";//if image button 1 is clicked, assign session variable to china
            Response.Redirect("Dashboard.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session["culture"] = "india";//if image button 2 is clicked, assign session variable to india
            Response.Redirect("Dashboard.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["culture"] = "italy";//if image button 3 is clicked, assign session variable to italy
            Response.Redirect("Dashboard.aspx");
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Session["culture"] = "china";//if link button 1 is clicked, assign session variable to china
            Response.Redirect("Dashboard.aspx");
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Session["culture"] = "india";//if link button 2 is clicked, assign session variable to india
            Response.Redirect("Dashboard.aspx");
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            Session["culture"] = "italy";//if link button 3 is clicked, assign session variable to italy
            Response.Redirect("Dashboard.aspx");
        }
    }
}