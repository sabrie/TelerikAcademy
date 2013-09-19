using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Web.Services;

namespace _3.WebPhotoAlbum
{
    public partial class WebPhotoAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Slide[] GetSlides()
        {
            return new Slide[]{
                new Slide("Images/Agassi_Federer.jpg", "Agassi and Federer", "Agassi and Federer"),
                new Slide("Images/Amelie.jpg", "Amelie Mauresmo", "Amelie Mauresmo"),
                new Slide("Images/Nadal.jpg", "Rafael Nadal", "Rafael Nadal"),
                new Slide("Images/Sharapova.jpg", "Maria Sharapova", "Maria Sharapova")
            };
        }
    }
}