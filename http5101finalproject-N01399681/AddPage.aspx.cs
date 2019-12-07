using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace http5101finalproject_N01399681
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*add page method*/
        protected void Add_Page(object sender, EventArgs e)
        {
            WEBPAGEDB db = new WEBPAGEDB();

            //create a new specific page
            HTTPpage new_page = new HTTPpage();
            //set that student data
            new_page.SetPtitle (page_title.Text);
            new_page.SetPbody(page_body.Text);

            //add the page to the database
            db.AddPage(new_page);


            Response.Redirect("ListPages.aspx");
        }

    }
}