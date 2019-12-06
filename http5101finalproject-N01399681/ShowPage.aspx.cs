using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace http5101finalproject_N01399681
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WEBPAGEDB db = new WEBPAGEDB();
            ShowPageInfo(db);
        }
            
        protected void Delete_Page(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            WEBPAGEDB db = new WEBPAGEDB();

            
            if (valid)
            {
                db.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }
        }

        protected void ShowPageInfo(WEBPAGEDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //We will attempt to get the record we need
            if (valid)
            {

                HTTPpage page_record = db.FindPage(Int32.Parse(pageid));



                page_title.InnerHtml = page_record.GetPtitle();
                page_body.InnerHtml = page_record.GetPbody();
                
            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                page.InnerHtml = "There was an error finding that student.";
            }
        }
        /*Update the Page*/
        protected void Update_Page(object sender, EventArgs e)
        {
            Response.Redirect("ContentPage.aspx");
            /*I will create a new page to display details of a particular page. On that page I want to have a done button which will 
             * redirect to list pages*/
        }
    }
}