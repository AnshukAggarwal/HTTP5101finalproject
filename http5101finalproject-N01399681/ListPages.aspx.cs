using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace http5101finalproject_N01399681
{
    public partial class ListPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //now create the variables
            pages_result.InnerHtml = "";
            string searchkey = "";

            if (Page.IsPostBack)
            {
                searchkey = page_search.Text;
            }
            string query = "select * FROM PAGES";
            if (searchkey != "")
            {
                query += " WHERE PAGEID like '%" + searchkey + "%' ";
                query += " PAGETITLE like '%" + searchkey + "%' ";
            }

            WEBPAGEDB db = new WEBPAGEDB();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                pages_result.InnerHtml += "<div class=\"listitem\">";

                string pageid = row["PAGEID"];

                string pagetitle = row["PAGETITLE"];
                pages_result.InnerHtml += "<div class=\"col\"><a href=\"ShowPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></div>";

                string pagebody = row["PAGEBODY"];
                pages_result.InnerHtml+= "<div class=\"col\">" + pagebody + "</div>";

                pages_result.InnerHtml += "</div>";


            }
        }
    }

}