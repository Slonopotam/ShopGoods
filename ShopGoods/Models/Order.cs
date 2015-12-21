using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShopGoods.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage="Пожалуйста, укажите своё имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вы должны указать хотя бы один адрес доставки")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Пожалуйста укажите город, куда нужно доставить заказ")]
        public string City { get; set; }
        public string Deliver { get; set; }
        public bool Dispatched { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        [Key]
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Good Good { get; set; }
        public int Quantity { get; set; }
    }
}