﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.PrintBrowserTypeAndIP
{
    public partial class BrowserTypeAndIP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralOutput.Text = "Browser Type: " + Request.Browser.Type + "<br/>"; 
            this.LiteralOutput.Text += "IP Address: " + Request.UserHostAddress;
        }
    }
}