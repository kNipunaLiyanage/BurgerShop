using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{
    public class OrderdetailzModel
    {
        
        int idorderdetails;
        int orderidz;
        String itemname;
        String mealtype;
        String mealsuitable;
        String sizez;
        double unitprice;
        int qty;
        String orderidgenarated;

        public OrderdetailzModel()
        {

        }

        public OrderdetailzModel(int idorderdetails, int orderidz, string itemname, string mealtype, string mealsuitable, string sizez, double unitprice, int qty, string orderidgenarated)
        {
            this.Idorderdetails = idorderdetails;
            this.Orderidz = orderidz;
            this.Itemname = itemname;
            this.Mealtype = mealtype;
            this.Mealsuitable = mealsuitable;
            this.Sizez = sizez;
            this.Unitprice = unitprice;
            this.Qty = qty;
            this.Orderidgenarated = orderidgenarated;
        }

        public int Idorderdetails { get => idorderdetails; set => idorderdetails = value; }
        public int Orderidz { get => orderidz; set => orderidz = value; }
        public string Itemname { get => itemname; set => itemname = value; }
        public string Mealtype { get => mealtype; set => mealtype = value; }
        public string Mealsuitable { get => mealsuitable; set => mealsuitable = value; }
        public string Sizez { get => sizez; set => sizez = value; }
        public double Unitprice { get => unitprice; set => unitprice = value; }
        public int Qty { get => qty; set => qty = value; }
        public string Orderidgenarated { get => orderidgenarated; set => orderidgenarated = value; }
    }
}