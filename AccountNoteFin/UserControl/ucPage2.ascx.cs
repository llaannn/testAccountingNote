using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountNoteFin.UserControl
{
    public partial class ucPage2 : System.Web.UI.UserControl
    {
        public string Url { get; set; }
        public int TotalSize { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int GetCurrentPage()//取得目前頁數
        {
            string pageText = this.Request.QueryString["page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int pageIndex = 0;
            if (!int.TryParse(pageText, out pageIndex))
                return 1;
            return pageIndex;

        }


        public void Bind()//讓外界決定參數都給好了 這邊要算頁數
        {
            //檢查一頁筆數
            if (this.PageSize <= 0)
                throw new DivideByZeroException();

            //算總頁數
            int totalPage = this.TotalSize / this.PageSize;
            if (this.TotalSize % this.PageSize > 0)
                totalPage += 1;


            this.aLinkFirst.HRef = $"{this.Url}?page=1";
            this.aLinkLast.HRef = $"{this.Url}?page={totalPage}";


            this.CurrentPage = this.GetCurrentPage();
            //if (this.CurrentPage == 1)
            //{
            //    this.aLink1.Visible = false;
            //    this.aLink2.Visible = false;
            //    this.aLink3.HRef = "";

            //}


            //計算控制項的頁數
                int prevM1 = this.CurrentPage - 1;
                int prevM2 = this.CurrentPage - 2;
                int nextP1 = this.CurrentPage + 1;
                int nextP2 = this.CurrentPage + 2;

                this.aLink2.HRef = $"{this.Url}?Page={prevM1}";
                this.aLink2.InnerText = prevM1.ToString();
                this.aLink1.HRef = $"{this.Url}?Page={prevM2}";
                this.aLink1.InnerText = prevM2.ToString();

                this.aLink4.HRef = $"{this.Url}?Page={nextP1}";
                this.aLink4.InnerText = nextP1.ToString();
                this.aLink5.HRef = $"{this.Url}?Page={nextP2}";
                this.aLink5.InnerText = nextP2.ToString();

            this.ltlCurrentPage.Text = this.CurrentPage.ToString();

            //if (prevM2 <= 0)
            //    this.aLink1.Visible = false;
            //if (prevM1 <= 0)
            //    this.aLink2.Visible = false;
            //if (nextP1 > totalPage)
            //    this.aLink4.Visible = false;
            //if (nextP2 > totalPage)
            //    this.aLink5.Visible = false;

            this.aLink1.Visible = (prevM2 > 0);
            this.aLink2.Visible = (prevM1 > 0);
            this.aLink4.Visible = (nextP1 <= totalPage);
            this.aLink5.Visible = (nextP2 <= totalPage);

            this.ltPager.Text = $"共{this.TotalSize}筆，共{totalPage}頁，目前在第{this.GetCurrentPage()}頁";
        }
    }
}