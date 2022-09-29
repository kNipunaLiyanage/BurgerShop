using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{
    public class StockModel
    {
        int idstock;
        String itemname;
        String mealtype;
        String mealsuitable;
        String size;
        double unitprice;
        int qty;

        public StockModel()
        {
        }

        public StockModel(int idstock, string itemname, string mealtype, string mealsuitable, string size, double unitprice, int qty)
        {
            this.Idstock = idstock;
            this.Itemname = itemname;
            this.Mealtype = mealtype;
            this.Mealsuitable = mealsuitable;
            this.Size = size;
            this.Unitprice = unitprice;
            this.Qty = qty;
        }

        public int Idstock { get => idstock; set => idstock = value; }
        public string Itemname { get => itemname; set => itemname = value; }
        public string Mealtype { get => mealtype; set => mealtype = value; }
        public string Mealsuitable { get => mealsuitable; set => mealsuitable = value; }
        public string Size { get => size; set => size = value; }
        public double Unitprice { get => unitprice; set => unitprice = value; }
        public int Qty { get => qty; set => qty = value; }
    }
}