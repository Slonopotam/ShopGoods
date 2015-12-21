using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using ShopGoods.Models;
using ShopGoods.Models.Repository;
using ShopGoods.Pages.Helpers;

namespace ShopGoods.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order myOrder = new Order();
                if (TryUpdateModel(myOrder,
                   new FormValueProvider(ModelBindingExecutionContext)))
                {

                    myOrder.OrderLines = new List<OrderLine>();

                    Basket myBasket = SessionHelper.GetBasket(Session);

                    foreach (BasketLine line in myBasket.Lines)
                    {
                        myOrder.OrderLines.Add(new OrderLine
                        {
                            Order = myOrder,
                            Good = line.Good,
                            Quantity = line.Quantity
                        });
                    }

                    new Repository().SaveOrder(myOrder);
                    myBasket.Clear();

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }

        }
    }
}