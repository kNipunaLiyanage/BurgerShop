using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{
    public class ItemModel
    {
        int itemid;
        String itemname;
        String mealtype;
        String mealsuitblefor;
        String sizez;
        String descriptionz;
        double unitprice;
        String statusz;

        public ItemModel()
        {

        }

        public ItemModel(int itemid, string itemname, string mealtype, string mealsuitblefor, string sizez, string descriptionz, double unitprice, string statusz)
        {
            this.Itemid = itemid;
            this.Itemname = itemname;
            this.Mealtype = mealtype;
            this.Mealsuitblefor = mealsuitblefor;
            this.Sizez = sizez;
            this.Descriptionz = descriptionz;
            this.Unitprice = unitprice;
            this.Statusz = statusz;
        }

        public int Itemid { get => itemid; set => itemid = value; }
        public string Itemname { get => itemname; set => itemname = value; }
        public string Mealtype { get => mealtype; set => mealtype = value; }
        public string Mealsuitblefor { get => mealsuitblefor; set => mealsuitblefor = value; }
        public string Sizez { get => sizez; set => sizez = value; }
        public string Descriptionz { get => descriptionz; set => descriptionz = value; }
        public double Unitprice { get => unitprice; set => unitprice = value; }
        public string Statusz { get => statusz; set => statusz = value; }
    }
}