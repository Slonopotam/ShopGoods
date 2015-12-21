using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopGoods.Models;
using ShopGoods.Models.Repository;
using System.Web.ModelBinding;
using System.Collections;
using System.Xml.Linq;

namespace ShopGoods.Pages.Admin
{
    public partial class Goods : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable GetGoods()
        {
            return repository.Goods;
        }

        public void UpdateGood(int GoodID)
        {
            Good myGood = repository.Goods
                .Where(p => p.GoodsID == GoodID).FirstOrDefault();
            if (myGood != null && TryUpdateModel(myGood,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGood(myGood);
            }
        }

        public void DeleteGood(int GoodID)
        {
            Good myGood = repository.Goods
                .Where(p => p.GoodsID == GoodID).FirstOrDefault();
            if (myGood != null)
            {
                repository.DeleteGood(myGood);
            }
        }

        public void AddGood()
        {
            Good myGood = new Good();
            if (TryUpdateModel(myGood,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGood(myGood);
            }
        }

        public void InsertGood()
        {
            Good updGood = new Good();
            XDocument xDoc = XDocument.Load(@"d:\Work\C#\ShopGoods\ShopGoods\App_Data\UpdDb.xml");
            
            foreach (XElement elm in xDoc.Descendants("Good"))
            {
                if (elm.HasElements)
                {
                    if (elm.Attribute("Articul") != null)
                    {
                        updGood.GoodsArticul = elm.Attribute("Articul").Value;
                    }

                    if (elm.Attribute("Value") != null)
                    {
                        updGood.GoodsPrice = decimal.Parse(elm.Attribute("Value").Value);
                    }
                }

                if (elm.Element("Producer").Attribute("Name") != null)
                {
                    updGood.GoodsCompany = elm.Element("Producer").Attribute("Name").Value;
                }

                if (elm.Element("GoodType").Attribute("Name") != null)
                {
                    updGood.GoodsName = elm.Element("GoodType").Attribute("Name").Value;
                }
                
                repository.SaveGood(updGood);
            }
        }
    }
}