using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Main mainMaster = this.Master as Main;
            //this.Master就能取得主頁面，但是因為主要的名稱是繼承於 Main所以需要自主轉型，把Master轉型為Main才能放入 mainMaster

            mainMaster.MyTitle = "預設頁";
            mainMaster.SetPageCaption("預設頁字串可以自由置換內容");


            //this.ucControlimage.SetText("第一個uc");
            this.ucControlimage1.SetText("第二個uc");
            this.ucControlimage2.SetText("第三個uc");
        }
    }
}