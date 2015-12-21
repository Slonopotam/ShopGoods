using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGoods.Models
{
    public class Basket
    {
        private List<BasketLine> lineCollection = new List<BasketLine>();

        public void AddItem(Good good, int quantity)
        {
            BasketLine line = lineCollection.Where(p => p.Good.GoodsID == good.GoodsID).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new BasketLine
                {
                    Good = good,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Good good)
        {
            lineCollection.RemoveAll(l => l.Good.GoodsID == good.GoodsID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Good.GoodsPrice * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<BasketLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class BasketLine
    {
        public Good Good { get; set; }
        public int Quantity {get; set; }
    }
}