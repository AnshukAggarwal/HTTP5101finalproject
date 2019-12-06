using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace http5101finalproject_N01399681
{
    public class HTTPpage
    {   /*set private variables*/
        private string Ptitle;
        private string Pbody;

        /*now create the get and set methods . These will be public so that other files can access them*/

        public string GetPtitle()
        {
            return Ptitle;
        }
        public string GetPbody()
        {
            return Pbody;
        }

        public void SetPtitle(string value)
        {
            Ptitle = value;
        }

        public void SetPbody(string value)
        {
            Pbody = value;

        }
    }
}