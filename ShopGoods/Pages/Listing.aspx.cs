using System;
using System.Collections.Generic;
using System.Linq;
using ShopGoods.Models;
using ShopGoods.Models.Repository;
using System.Web.Routing;
using ShopGoods.Pages.Helpers;

namespace ShopGoods.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        private int pageSize = 4;

        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterGoods().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        public IEnumerable<Good> GetGoods()
        {
            return FilterGoods()
                .OrderBy(g => g.GoodsID)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Good> FilterGoods()
        {
            IEnumerable<Good> goods = repository.Goods;
            string currentCategory = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
            return currentCategory == null ? goods : goods.Where(p => p.GoodsCompany == currentCategory);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedGoodId;
                if(int.TryParse(Request.Form["add"], out selectedGoodId))
                {
                    Good selectedGood = repository.Goods.Where(g => g.GoodsID == selectedGoodId).FirstOrDefault();

                    if (selectedGood != null)
                    {
                        SessionHelper.GetBasket(Session).AddItem(selectedGood, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);

                        Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "basket", null).VirtualPath);
                    }
                }
            }
        }

        public IEnumerable<ShopGoods.Models.Good> Unnamed_GetData()
        {
            return null;
        }

        public IEnumerable<ShopGoods.Models.Good> Unnamed_GetData1()
        {
            return null;
        }
    }
}