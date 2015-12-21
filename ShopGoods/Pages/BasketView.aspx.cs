using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using ShopGoods.Models;
using ShopGoods.Pages.Helpers;
using ShopGoods.Models.Repository;

namespace ShopGoods.Pages
{
    public partial class BasketView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int goodId;
                if (int.TryParse(Request.Form["remove"], out goodId))
                {
                    Good goodToRemove = repository.Goods
                        .Where(g => g.GoodsID == goodId).FirstOrDefault();
                    if (goodToRemove != null)
                    {
                        SessionHelper.GetBasket(Session).RemoveLine(goodToRemove);
                    }
                }
            }

        }

        public IEnumerable<BasketLine> GetBasketLines()
        {
            return SessionHelper.GetBasket(Session).Lines;
        }

        public decimal BasketTotal
        {
            get
            {
                return SessionHelper.GetBasket(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }

        public string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout",
                    null).VirtualPath;
            }
        }
    }
}