using System;
using System.Web.Routing;

//namespace ShopGoods.App_Start
namespace ShopGoods
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "list/{category}/{page}",
                                        "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
            routes.MapPageRoute("basket", "basket", "~/Pages/BasketView.aspx");
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");
            routes.MapPageRoute("admin_goods", "admin/goods", "~/Pages/Admin/Goods.aspx");
        }
    }
}