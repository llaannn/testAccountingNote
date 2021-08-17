using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ucControlimage : System.Web.UI.UserControl
    {
       public string MyTitle { get; set; }

        public enum BCcolor 
        {
            Blue,
            Red,
            Green
        }//列舉後當作是屬性使用
        public BCcolor BackColor { get; set; } = BCcolor.Green;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.MyTitle))
            {
                this.ltlTitle.Text = this.MyTitle;
                this.imgCover.Alt = this.MyTitle;
            }

            this.divMain.Style.Add("background-color",this.BackColor.ToString());

        }
         


        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ltlTitle.Text = "ucControlimage_Click";
            this.imgCover.Alt = "ucControlimage_Click";
        }

        public void SetText(string title)
        {
            if(!string.IsNullOrWhiteSpace(title))
            {
                this.ltlTitle.Text = title;
                this.imgCover.Alt = title;
            }
        }
    }
}