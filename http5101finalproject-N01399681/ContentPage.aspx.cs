using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace http5101finalproject_N01399681
{
    public partial class ContentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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

        /*Update the Page*/
        /*I will create a new page to display details of a particular page. */
        protected void Update_Page(object sender, EventArgs e)
        {
            /*instantiate a connection to edit the page*/
            WEBPAGEDB db = new WEBPAGEDB();

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            HTTPpage new_page = new HTTPpage();

            if (valid)
            {
                

                new_page.SetPtitle(page_title.Text);
                new_page.SetPbody(page_body.Text);
            }
            try
            {
                Debug.WriteLine("I am trying to update this page");
                db.UpdatePage(Int32.Parse(pageid), new_page);
                Response.Redirect("ShowPage.aspx?pageid=" + pageid);
            }
            catch
            {
                valid = false;
            }

        

            if (!valid)
            {
                httppage.InnerHtml = "There was an error updating that page.";
            }

        }


    }
}