using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerShop.Models
{


    public class UserModel
    {

        int userid;
        String nameinfull;
        String emailz;
        String contactnumber;
        String addressz;
        String city;
        String passwordz;
        String statusz;

        public UserModel(){
        
        }

        public UserModel(int userid, string nameinfull, string emailz, string contactnumber, string addressz, string city, string passwordz, string statusz)
        {
            this.Userid = userid;
            this.Nameinfull = nameinfull;
            this.Emailz = emailz;
            this.Contactnumber = contactnumber;
            this.Addressz = addressz;
            this.City = city;
            this.Passwordz = passwordz;
            this.Statusz = statusz;
        }

        public int Userid { get => userid; set => userid = value; }
        public string Nameinfull { get => nameinfull; set => nameinfull = value; }
        public string Emailz { get => emailz; set => emailz = value; }
        public string Contactnumber { get => contactnumber; set => contactnumber = value; }
        public string Addressz { get => addressz; set => addressz = value; }
        public string City { get => city; set => city = value; }
        public string Passwordz { get => passwordz; set => passwordz = value; }
        public string Statusz { get => statusz; set => statusz = value; }
    }

}