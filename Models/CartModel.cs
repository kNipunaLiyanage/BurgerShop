using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{
    public class CartModel
    {
        int idcart;
        String emailaddress;
        String statusz;

        public CartModel()
        {
        }

        public CartModel(int idcart, string emailaddress, string statusz)
        {
            this.Idcart = idcart;
            this.Emailaddress = emailaddress;
            this.Statusz = statusz;
        }

        public int Idcart { get => idcart; set => idcart = value; }
        public string Emailaddress { get => emailaddress; set => emailaddress = value; }
        public string Statusz { get => statusz; set => statusz = value; }
    }
}