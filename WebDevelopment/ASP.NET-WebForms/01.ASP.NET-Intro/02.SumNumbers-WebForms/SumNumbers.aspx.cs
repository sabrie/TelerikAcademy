using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SumNumbers_WebForms
{
    public partial class SumNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        protected void BtnCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                decimal first = Decimal.Parse(this.TextBoxFirstNum.Text);
                decimal second = Decimal.Parse(this.TextBoxSecondNum.Text);
                decimal sum = first + second;
                this.TextBoxSum.Text = (sum).ToString();
            }
            catch (Exception ex)
            {

                this.TextBoxSum.Text = "Error! You can sum only numbers";
            }
        }
    }
}