using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.GenerateRandomNumbers
{
    public partial class GenerateRandomNumbers : System.Web.UI.Page
    {
        private Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            int from = int.Parse(this.InputTextRangeFrom.Value);
            int to = int.Parse(this.InputTextRangeTo.Value);

            this.RandomNumber.Value = random.Next(from, to + 1).ToString();
        }
    }
}