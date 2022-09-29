using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{
    public class CartItemsModel
    {
        int idcartitems;
        int cartidz;
        String emailaddress;
        String itemname;
        String mealtyepe;
        String suitablefor;
        String sizez;
        double unitprice;
        int qty;

        public CartItemsModel()
        {
        }

        public CartItemsModel(int idcartitems, int cartidz, string emailaddress, string itemname, string mealtyepe, string suitablefor, string sizez, double unitprice, int qty)
        {
            this.Idcartitems = idcartitems;
            this.Cartidz = cartidz;
            this.Emailaddress = emailaddress;
            this.Itemname = itemname;
            this.Mealtyepe = mealtyepe;
            this.Suitablefor = suitablefor;
            this.Sizez = sizez;
            this.Unitprice = unitprice;
            this.Qty = qty;
        }

        public int Idcartitems { get => idcartitems; set => idcartitems = value; }
        public int Cartidz { get => cartidz; set => cartidz = value; }
        public string Emailaddress { get => emailaddress; set => emailaddress = value; }
        public string Itemname { get => itemname; set => itemname = value; }
        public string Mealtyepe { get => mealtyepe; set => mealtyepe = value; }
        public string Suitablefor { get => suitablefor; set => suitablefor = value; }
        public string Sizez { get => sizez; set => sizez = value; }
        public double Unitprice { get => unitprice; set => unitprice = value; }
        public int Qty { get => qty; set => qty = value; }
    }
}