using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string MyTitle { get; set; } = string.Empty;
        //開一個欄位 叫做""是個字串 直接做初始化

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ltMsg.Text = this.txtEmail.Text;
        }

        public void SetPageCaption(string title)
        {
            if(!string.IsNullOrWhiteSpace(title))
            this.ltlCaption.Text = title;
        }
       

    }
}