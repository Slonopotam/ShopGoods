using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopGoods.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GoodsUrl
        {
            get
            {
                return generateURL(null);
            }
        }

        private string generateURL(string routeName)
        {
            return RouteTable.Routes.GetVirtualPath(null, routeName, null).VirtualPath;
        }
    }
}