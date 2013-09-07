using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.GenerateRandomNumbers_WebControls
{
    public partial class GenerateRandomNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateRandomNumber_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            int from = int.Parse(this.TextBoxFrom.Text);
            int to = int.Parse(this.TextBoxTo.Text);

            this.TextBoxRandomNumber.Text = random.Next(from, to + 1).ToString();
        }
    }
}