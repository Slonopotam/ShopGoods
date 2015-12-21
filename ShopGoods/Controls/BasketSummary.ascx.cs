using System;
using System.Linq;
using System.Web.Routing;
using ShopGoods.Models;
using ShopGoods.Pages.Helpers;

namespace ShopGoods.Controls
{
    public partial class BasketSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Basket myBasket = SessionHelper.GetBasket(Session);
            csQantity.InnerText = myBasket.Lines.Sum(x => x.Quantity).ToString();
            csTotal.InnerText = myBasket.ComputeTotalValue().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "basket", null).VirtualPath;
        }
    }
}