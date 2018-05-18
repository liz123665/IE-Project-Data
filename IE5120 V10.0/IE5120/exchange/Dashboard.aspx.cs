using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IE5120.exchange
{
    public partial class dashboard : System.Web.UI.Page
    {
        public string cul = "";
        public string tableau_url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["culture"]==null)
            {
                Response.Redirect("Culture.aspx");
            }else
            {
                cul = Session["culture"].ToString();
                if (cul.Equals("china"))
                {
                    //if session variable is equal to china, assign tableau link as below
                    LinkButton1.Style.Add("Color","#48cfad");
                    tableau_url = "https://public.tableau.com/views/dashChina/1?:embed=y&:display_count=yes&publish=yes";
                }else if (cul.Equals("india"))
                {
                    //if session variable is equal to india, assign tableau link as below
                    LinkButton2.Style.Add("Color", "#48cfad");
                    tableau_url = "https://public.tableau.com/views/dashIndia/1?:embed=y&:display_count=yes&publish=yes";
                }
                else
                {
                    //if session variable is equal to italy, assign tableau link as below
                    LinkButton3.Style.Add("Color", "#48cfad");
                    tableau_url = "https://public.tableau.com/views/dashItaly/1?:embed=y&:display_count=yes&publish=yes";
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["culture"] = "china";//if link button 1 is clicked, assign session variable to china
            Response.Redirect("Dashboard.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["culture"] = "india";//if link button 2 is clicked, assign session variable to india
            Response.Redirect("Dashboard.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["culture"] = "italy";//if link button 3 is clicked, assign session variable to italy
            Response.Redirect("Dashboard.aspx");
        }
    }
}