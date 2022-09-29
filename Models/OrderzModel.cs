using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{
    public class OrderzModel
    {
       
        int idorderz;
        String emailaddress;
        String datez;
        String timez;
        String totalpricez;
        String nameinfull;
        String cityz;
        String addressz;
        String contactz;
        String orderidgenarated;
        String statusz;

        public OrderzModel()
        {
        }

        public OrderzModel(int idorderz, string emailaddress, string datez, string timez, string totalpricez, string nameinfull, string cityz, string addressz, string contactz, string orderidgenarated, string statusz)
        {
            this.Idorderz = idorderz;
            this.Emailaddress = emailaddress;
            this.Datez = datez;
            this.Timez = timez;
            this.Totalpricez = totalpricez;
            this.Nameinfull = nameinfull;
            this.Cityz = cityz;
            this.Addressz = addressz;
            this.Contactz = contactz;
            this.Orderidgenarated = orderidgenarated;
            this.Statusz = statusz;
        }

        public int Idorderz { get => idorderz; set => idorderz = value; }
        public string Emailaddress { get => emailaddress; set => emailaddress = value; }
        public string Datez { get => datez; set => datez = value; }
        public string Timez { get => timez; set => timez = value; }
        public string Totalpricez { get => totalpricez; set => totalpricez = value; }
        public string Nameinfull { get => nameinfull; set => nameinfull = value; }
        public string Cityz { get => cityz; set => cityz = value; }
        public string Addressz { get => addressz; set => addressz = value; }
        public string Contactz { get => contactz; set => contactz = value; }
        public string Orderidgenarated { get => orderidgenarated; set => orderidgenarated = value; }
        public string Statusz { get => statusz; set => statusz = value; }
    }
}