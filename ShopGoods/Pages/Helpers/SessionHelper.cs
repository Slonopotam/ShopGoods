using System;
using System.Web.SessionState;
using ShopGoods.Models;

namespace ShopGoods.Pages.Helpers
{
    public enum SessionKey
    {
        BASKET,
        RETURN_URL
    }

    public class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                return default(T);
            }
        }

        public static Basket GetBasket(HttpSessionState session)
        {
            Basket myBasket = Get<Basket>(session, SessionKey.BASKET);
            if(myBasket == null)
            {
                myBasket = new Basket();
                Set(session, SessionKey.BASKET, myBasket);
            }
            return myBasket;
        }
    }
}