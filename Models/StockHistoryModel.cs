using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{
    public class StockHistoryModel
    {
        int idstockhostoty;
        String itemname;
        String mealtype;
        String mealsuitable;
        String size;
        int addedqty;
        int clearedqty;
        String datez;
        String timez;

        public StockHistoryModel()
        {
        }

        public StockHistoryModel(int idstockhostoty, string itemname, string mealtype, string mealsuitable, string size, int addedqty, int clearedqty, string datez, string timez)
        {
            this.Idstockhostoty = idstockhostoty;
            this.Itemname = itemname;
            this.Mealtype = mealtype;
            this.Mealsuitable = mealsuitable;
            this.Size = size;
            this.Addedqty = addedqty;
            this.Clearedqty = clearedqty;
            this.Datez = datez;
            this.Timez = timez;
        }

        public int Idstockhostoty { get => idstockhostoty; set => idstockhostoty = value; }
        public string Itemname { get => itemname; set => itemname = value; }
        public string Mealtype { get => mealtype; set => mealtype = value; }
        public string Mealsuitable { get => mealsuitable; set => mealsuitable = value; }
        public string Size { get => size; set => size = value; }
        public int Addedqty { get => addedqty; set => addedqty = value; }
        public int Clearedqty { get => clearedqty; set => clearedqty = value; }
        public string Datez { get => datez; set => datez = value; }
        public string Timez { get => timez; set => timez = value; }
    }
}