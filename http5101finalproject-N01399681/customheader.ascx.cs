using System;
using System.Collections.Generic;

namespace http5101finalproject_N01399681
{
    public partial class customheader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WEBPAGEDB db = new WEBPAGEDB();
            ListCustomHeader(db);

        }
        /*This method was referenced from the in-class example*/
        protected void ListCustomHeader(WEBPAGEDB db)
        {
            string query = "select PAGEID, PAGETITLE from pages";
            List<Dictionary<String, String>> rs = db.List_Query(query);

            foreach(Dictionary<String,String> row in rs)

            {
                string pageid = row["PAGEID"];
                custom_header.InnerHtml += "<div><a href=\"ShowPage.aspx?pageid=" + pageid + "\">" + row["PAGETITLE"] + "</a></div>";
            }
        }
    }
}