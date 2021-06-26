using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace QuizWebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void addItemToOrder(string name, int price, int quantity)
        {
            OnlineShopping.Product product = new OnlineShopping.Product(name, price, quantity);
        }
        
        [WebMethod]
        public bool UpdateCredits(int newamount,string username)
        {
            
            return OnlineShopping.SqlData.UpdateCredits(newamount,username);
        }
        [WebMethod]
        public int DisplayStocks(string category, string brand)
        {
            int stocks = OnlineShopping.SqlData.DisplayStocks(category, brand);
            return stocks;
        }
        [WebMethod]
        public bool VerifyUser(string username, string password)
        {
            return OnlineShopping.SqlData.VerifyUser(username, password);
        }
        [WebMethod]
        public int DisplayPrice(string category, string brand)
        {
            return OnlineShopping.SqlData.DisplayPrice(category, brand);
        }
    }
}
