using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace ShopGoods.Models
{
    public class Good
    {
        [Key]
        public int GoodsID { get; set; }
        public string GoodsArticul { get; set; }
        public string GoodsName { get; set; }
        public string GoodsCompany { get; set; }
        public decimal GoodsPrice { get; set; }
    }
}