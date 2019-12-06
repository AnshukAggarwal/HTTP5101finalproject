using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace http5101finalproject_N01399681
{
    public partial class ContentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                WEBPAGEDB db = new WEBPAGEDB();
                ShowPageInfo(db);
            }
            

        }
        protected void ShowPageInfo(WEBPAGEDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //try getting the particular record
            if (valid)
            {

                HTTPpage page_record = db.FindPage(Int32.Parse(pageid));
                page_title.Text = page_record.GetPtitle();
                page_body.Text = page_record.GetPbody();
                
            }

            if (!valid)
            {
                httppage.InnerHtml = "There was an error finding that page.";
            }
        }
    }
}