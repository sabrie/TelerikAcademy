using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace _02.SayHelloFromCodeAndAspx
{
    public partial class SayHelloFromCodeAndAspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal literal = new Literal();
            literal.Text = "Hello, ASP.NET (from code)";
            this.PlaceholderHello.Controls.Add(literal);

            this.LiteralAssemblyLocation.Text = "Current Assembly Location: " + Assembly.GetExecutingAssembly().Location;
        }
    }
}