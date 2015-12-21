using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopGoods.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Good> Goods
        {
            get { return context.Goods; }
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders.Include(o => o.OrderLines.Select(ol => ol.Good));
            }
        }

        public void SaveGood(Good good)
        {
            if (good.GoodsID == 0)
            {
                good = context.Goods.Add(good);
            }
            else
            {
                Good dbGood = context.Goods.Find(good.GoodsID);
                if (dbGood != null)
                {
                    dbGood.GoodsName = good.GoodsName;
                    dbGood.GoodsArticul = good.GoodsArticul;
                    dbGood.GoodsPrice = good.GoodsPrice;
                    dbGood.GoodsCompany = good.GoodsCompany;
                }
            }
            context.SaveChanges();
        }

        public void DeleteGood(Good good)
        {
            IEnumerable<Order> orders = context.Orders
                .Include(o => o.OrderLines.Select(ol => ol.Good))
                .Where(o => o.OrderLines
                    .Count(ol => ol.Good.GoodsID == good.GoodsID) > 0)
                .ToArray();

            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Goods.Remove(good);
            context.SaveChanges();
        }

        // Сохранить данные заказа в базе данных
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Good).State
                        = EntityState.Modified;
                }
            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.Deliver = order.Deliver;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }
    }
}