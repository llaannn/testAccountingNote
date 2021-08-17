using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountNoteFin.UserControl
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        /// <summary>
        /// 頁面url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 總筆數
        /// </summary>
        public int TotalSize { get; set; }
        /// <summary>
        /// 頁面筆數
        /// </summary>
        public int PagesSize { get; set; }
        /// <summary>
        /// 目前筆數
        /// </summary>
        public int CurrentPage { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            //int totalPages = this.GetTotalPages();
            this.Bind();
        }

        public void Bind()
        {
            int totalPages = this.GetTotalPages();
            this.ltPager.Text = $"共{this.TotalSize}筆，共{totalPages}頁，現在在第{this.GetCurrentPage()}頁<br/>";

            for (var i = 1; i <= totalPages; i++)
            {
                this.ltPager.Text += $"<a href='{this.Url}'>{i}</a>&nbsp";
            }
        }

        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];
            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;


            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;
            return intPage;

        }


        private int GetTotalPages()//取得總筆數
        {
            int pegers = this.TotalSize / this.PagesSize;
            try
            {
              int a = this.PagesSize;
            }
            catch (Exception ex)
            {
                throw ex;
              
            }

            if ((this.TotalSize % this.PagesSize) > 0)
                pegers += 1;
            return pegers;
        }
    }
}