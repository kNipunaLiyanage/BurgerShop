using BurgerShop.Models;
using MySql.Data.MySqlClient;
using SchoolManagementBuildOne.Customclasess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BurgerShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        
        //Register User
        [HttpPost]
        public ActionResult Usr(String nameinfull,String emailz,String contactnumber,String city,String addressz,String pw)
        {
            try {

                String firsrsql = "select * from userdetails where emailz='" + emailz + "'";
                Dbconnection.closeCon();
                MySqlDataReader row = Dbconnection.search(firsrsql);
                if (row.HasRows)
                {
                    return Content("alre");
                }
                else
                {
                    String stat = "Active";
                    String querry = "insert into userdetails(nameinfull,emailz,contactnumber,addressz,city,passwordz,statusz) values('" + nameinfull + "','" + emailz + "','" + contactnumber + "','" + addressz + "','" + city + "','" + pw + "','" + stat + "')";

                    Dbconnection.iud(querry);
                    return Content("ok");
                }

                
            }
            catch (Exception e) {
                return Content("error");
            }
            
           
        }

        //Login User
        [HttpPost]
        public ActionResult LogUSR(String uname,String pw) {

            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from userdetails where emailz='"+uname+ "' and passwordz='"+pw+"'";
            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);
            if (row.HasRows)
            {
                if (row.Read())
                {
                    Session["uname"] = uname;
                    Session["pw"] = pw;
                    
                }
                return Content("ok");
            }
            else {

                return Content("err");
            }


                    
        }
        //Logout User
        [HttpGet]
        public ActionResult UserLogout() {

            Session["uname"] = null;
            Session["pw"] = null;
            Session["orderidloadz"] = null;

            Session.Remove("uname");
            Session.Remove("pw");
            Session.Remove("orderidloadz");

            
            
            return View("Index");
        }



        //Load Edit profile
        [HttpGet]
        public ActionResult LoadUserEdit() {

            String uname = Session["uname"] as String;

            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from userdetails where emailz='"+uname+"'";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<UserModel> userProfileModelList = new List<UserModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    UserModel userProfileModel = new UserModel();
                    userProfileModel.Nameinfull = row["nameinfull"].ToString();
                    userProfileModel.Emailz = row["emailz"].ToString();
                    userProfileModel.Contactnumber = row["contactnumber"].ToString();
                    userProfileModel.City = row["city"].ToString();
                    userProfileModel.Addressz = row["addressz"].ToString();
                    userProfileModel.Statusz = row["statusz"].ToString();
                    userProfileModelList.Add(userProfileModel);
                }

            }
            return View("LoadUserEdit", userProfileModelList);


        }

        //Change Userpassword
        [HttpPost]
        public ActionResult ChangePassword(String currentpw, String newpw)
        {

            String uname = Session["uname"] as String;
            String pw = Session["pw"] as String;

            if (currentpw.Equals(pw))
            {

                String quer1 = "update userdetails set passwordz='" + newpw + "' where emailz='" + uname + "'";
                Dbconnection.iud(quer1);
                Session["pw"] = newpw;
                return Content("ok");
            }
            else
            {

                return Content("notmatched");
            }

        }




            //change userdetails
            [HttpPost]
            public ActionResult ChangeDetaisUser(String namez, String contactz,String addressz)
            {
            String uname = Session["uname"] as String;
            String quer1 = "update userdetails set nameinfull='" + namez + "',contactnumber='"+contactz+ "',addressz='"+addressz+"' where emailz='" + uname + "'";
            Dbconnection.iud(quer1);

            return Content("ok");
            }

        //Remove all items from cart
        [HttpPost]
        public ActionResult RemoveallFromcart(String idz)
        {
            String uname = Session["uname"] as String;
            String quer1 = "DELETE FROM cart WHERE emailaddress = '" + uname+"';";
            Dbconnection.iud(quer1);
            String quer2 = "DELETE FROM cartitems WHERE emailaddress = '" + uname + "';";
            Dbconnection.iud(quer2);
            return Content("ok");
        }


        //Load all Menu details
        [HttpGet]
        public ActionResult LoadMenu()
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from iteminstock";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<BurgerShop.Models.StockModel> stockmodellist = new List<BurgerShop.Models.StockModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    StockModel stocklist = new StockModel();
                    stocklist.Idstock = Convert.ToInt32(row["idstock"].ToString());
                    stocklist.Itemname = row["itemname"].ToString();
                    stocklist.Mealtype = row["mealtype"].ToString();
                    stocklist.Mealsuitable = row["mealsuitable"].ToString();
                    stocklist.Size = row["sizez"].ToString();
                    stocklist.Unitprice = Convert.ToDouble(row["unitprice"].ToString());
                    stocklist.Qty = Convert.ToInt32(row["qty"].ToString());
                    stockmodellist.Add(stocklist);
                }

            }
            return View("LoadMenu", stockmodellist);
        }

        //Load all Menu details
        [HttpPost]
        public ActionResult SinglemenuItem()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            String idstock = Request["txtAmount"].ToString();
            string query = "Select * from iteminstock where idstock='"+idstock+"'";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);
            String itemname = "";
            String mealtype = "";
            String mealsuit = "";
            String size = "";
            if (row.HasRows)
            {
                while (row.Read())
                {

                    itemname = row["itemname"].ToString();
                    mealtype = row["mealtype"].ToString();
                    mealsuit = row["mealsuitable"].ToString();
                    size = row["sizez"].ToString();
                }

            }
            string query2 = "Select * from itemdetails where itemname='" + itemname + "' and mealtype='"+mealtype+ "' and mealsuitblefor='" + mealsuit + "' and sizez='" + size + "' ";
            Dbconnection.closeCon();
            MySqlDataReader row2 = Dbconnection.search(query2);

            List<BurgerShop.Models.ItemModel> itemmodellist = new List<BurgerShop.Models.ItemModel>();
            if (row2.HasRows)
            {
                while (row2.Read())
                {
                    ItemModel itemmdl = new ItemModel();
                    itemmdl.Itemid = Convert.ToInt32(row2["itemid"].ToString());
                    itemmdl.Itemname = row2["itemname"].ToString();
                    itemmdl.Mealtype = row2["mealtype"].ToString();
                    itemmdl.Mealsuitblefor = row2["mealsuitblefor"].ToString();
                    itemmdl.Sizez = row2["sizez"].ToString();
                    itemmdl.Descriptionz = row2["descriptionz"].ToString();
                    itemmdl.Unitprice = Convert.ToDouble(row2["unitprice"].ToString());
                    itemmodellist.Add(itemmdl);

                }
            }



                    return View("SinglemenuItem", itemmodellist);
        }


        //Add Item to user Cart
        
        public ActionResult USRCART(int itemid,String itemname,String mealtype,String mealsuitable,String sizez,String unitprice) {

           
            String uname = Session["uname"] as String;
            String cartstat = "Active";
            if (string.IsNullOrEmpty(uname))
            {
                return Content("nouser");
            }
            else
            {
                String contentz = "";
                string query1 = "Select * from cart where emailaddress='" + uname + "' and statusz='" + cartstat + "' ";
                Dbconnection.closeCon();
                MySqlDataReader row1 = Dbconnection.search(query1);
                if (row1.HasRows)
                {

                    if (row1.Read()) { 


                            
                        int cartid = Convert.ToInt32(row1["idcart"].ToString());
                        string query5 = "Select * from cartitems where cartidz='" + cartid + "' and itemname='" + itemname + "' and mealtyepe='" + mealtype + "' and suitablefor='" + mealsuitable + "' and sizez='" + sizez + "' ";
                        Dbconnection.closeCon();
                        MySqlDataReader row3 = Dbconnection.search(query5);
                        if (row3.HasRows)
                        {
                            if (row3.Read()) {
                                int qty = 1;
                                int stockqty = Convert.ToInt32(row3["qty"].ToString());
                                int final_qty = stockqty + 1;


                                String query10 = "select * from iteminstock where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitable + "' and sizez='" + sizez + "'";
                                Dbconnection.closeCon();
                                MySqlDataReader row7 = Dbconnection.search(query10);
                                if (row7.HasRows) {
                                    if (row7.Read()) {
                                      int   remainingqty = Convert.ToInt32(row7["qty"].ToString());
                                        if (remainingqty >= final_qty)
                                        {
                                            string query7 = "update  cartitems set qty=qty+'" + qty + "' where cartidz='" + cartid + "' and itemname='" + itemname + "' and mealtyepe='" + mealtype + "' and suitablefor='" + mealsuitable + "' and sizez='" + sizez + "' ";
                                            String qqz = "update iteminstock set qty=qty-1 where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitable + "' and sizez='" + sizez + "' ";
                                            Dbconnection.iud(query7);
                                            Dbconnection.iud(qqz);
                                            contentz = "ok";
                                        }
                                        else {
                                            contentz = "lowaty";

                                        }


                                    }
                                }

                                

                            }


                        }
                        else {
                            int stockqty = 0;
                            int qty = 1;
                            String query8 = "select * from iteminstock where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitable + "' and sizez='" + sizez + "'";
                            Dbconnection.closeCon();
                            MySqlDataReader row4 = Dbconnection.search(query8);
                            if (row4.HasRows)
                            {
                                if (row4.Read())
                                {
                                    stockqty = Convert.ToInt32(row4["qty"].ToString());
                                    if (stockqty >= qty)
                                    {
                                        string query6 = "insert into cartitems(cartidz,emailaddress,itemname,mealtyepe,suitablefor,sizez,unitprice,qty) values('" + cartid + "','" + uname + "' ,'" + itemname + "' ,'" + mealtype + "' ,'" + mealsuitable + "' ,'" + sizez + "' ,'" + unitprice + "' ,'" + qty + "')";
                                            String qqz = "update iteminstock set qty=qty-1 where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitable + "' and sizez='" + sizez + "' ";

                                        Dbconnection.iud(query6);
                                        Dbconnection.iud(qqz);
                                        contentz = "ok";

                                    }
                                    else {
                                        contentz = "lowaty";
                                    }

                                }
                            }

                                    
                           

                        }


                        }


                }
                else {
                    int last_id = 0;
                    int qty = 1;
                    int stockqty = 0;

                    String query8 = "select * from iteminstock where itemname='"+itemname+ "' and mealtype='"+mealtype+ "' and mealsuitable='" + mealsuitable + "' and sizez='" + sizez + "'";
                    Dbconnection.closeCon();
                    MySqlDataReader row4 = Dbconnection.search(query8);
                    if (row4.HasRows)
                    {
                        if (row4.Read())
                        {
                            stockqty = Convert.ToInt32(row4["qty"].ToString());
                            if (stockqty >= qty)
                            {
                                string query2 = "insert into cart(emailaddress,statusz) values('" + uname + "','" + cartstat + "')";
                                Dbconnection.iud(query2);

                                string query3 = "Select MAX(idcart) as x FROM cart";
                                Dbconnection.closeCon();
                                MySqlDataReader row2 = Dbconnection.search(query3);
                                if (row2.HasRows)
                                {
                                    while (row2.Read())
                                    {
                                        last_id = Convert.ToInt32(row2["x"].ToString());
                                    }
                                }
                                string query4 = "insert into cartitems(cartidz,emailaddress,itemname,mealtyepe,suitablefor,sizez,unitprice,qty) values('" + last_id + "','" + uname + "' ,'" + itemname + "' ,'" + mealtype + "' ,'" + mealsuitable + "' ,'" + sizez + "' ,'" + unitprice + "' ,'" + qty + "')";
                                String qqz = "update iteminstock set qty=qty-1 where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitable + "' and sizez='" + sizez + "' ";

                                Dbconnection.iud(query4);
                                Dbconnection.iud(qqz);
                                contentz = "ok";
                            }
                            else
                            {
                                contentz = "lowaty";
                            }
                        }
                    }
                    
                    

                    

                }
                return Content(contentz);
            }
        }

        //View User Cart
        [HttpGet]
        public ActionResult ViewUserCart() {

            String uname = Session["uname"] as String;
            String cartstat = "Active";
            List<BurgerShop.Models.CartItemsModel> cartItems = new List<BurgerShop.Models.CartItemsModel>();

            string query1 = "Select * from cart where emailaddress='" + uname + "' and statusz='" + cartstat + "' ";
            Dbconnection.closeCon();
            MySqlDataReader row1 = Dbconnection.search(query1);
            if (row1.HasRows)
            {

                if (row1.Read())
                {
                    int cartid = Convert.ToInt32(row1["idcart"].ToString());
                    string query5 = "Select * from cartitems where cartidz='" + cartid + "'";
                    Dbconnection.closeCon();
                    MySqlDataReader row2 = Dbconnection.search(query5);
                    
                    if (row2.HasRows)
                    {
                        while (row2.Read()) {
                            CartItemsModel itemmdl = new CartItemsModel();
                            itemmdl.Idcartitems = Convert.ToInt32(row2["idcartitems"].ToString());
                            itemmdl.Cartidz = Convert.ToInt32(row2["cartidz"].ToString());
                            itemmdl.Emailaddress = row2["emailaddress"].ToString();
                            itemmdl.Itemname = row2["itemname"].ToString();
                            itemmdl.Mealtyepe = row2["mealtyepe"].ToString();
                            itemmdl.Suitablefor = row2["suitablefor"].ToString();
                            itemmdl.Sizez = row2["sizez"].ToString();

                            itemmdl.Unitprice = Convert.ToDouble(row2["unitprice"].ToString());
                            itemmdl.Qty = Convert.ToInt32(row2["qty"].ToString());
                            cartItems.Add(itemmdl);

                        }
                    
                    }
                    
                }
               
            }


            return View("ViewUserCart", cartItems);
        }

        //Add One item to cart
        [HttpPost]
        public ActionResult addOneItemcart(String itemname, String mealtype, String mealsuitblefor, String sizez, String cartidz) {

            
            String contentz = "";
            int cartidlaodz = Convert.ToInt32(cartidz);
            //string query5 = "SELECT * FROM cartitems WHERE cartidz='7' AND itemname='Chicken Cheese Burger' AND mealtyepe='Spicy' AND suitablefor='dinner' AND sizez='small'";
            string query5 = "SELECT * FROM cartitems WHERE cartidz='"+cartidlaodz+"' AND itemname='"+itemname+"' AND mealtyepe='"+mealtype+"' AND suitablefor='"+mealsuitblefor+"' AND sizez='"+sizez+"'";
            Dbconnection.closeCon();
            MySqlDataReader row3 = Dbconnection.search(query5);
            if (row3.HasRows)
            {
                if (row3.Read())
                {
                    int qty = 1;
                    int stockqty = Convert.ToInt32(row3["qty"].ToString());
                    int final_qty = stockqty + 1;


                    String query10 = "select * from iteminstock where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitblefor + "' and sizez='" + sizez + "'";
                    Dbconnection.closeCon();
                    MySqlDataReader row7 = Dbconnection.search(query10);
                    if (row7.HasRows)
                    {
                        if (row7.Read())
                        {
                            int remainingqty = Convert.ToInt32(row7["qty"].ToString());
                            if (remainingqty >= final_qty)
                            {
                                string query7 = "update  cartitems set qty=qty+'" + qty + "' where cartidz='" + cartidlaodz + "' and itemname='" + itemname + "' and mealtyepe='" + mealtype + "' and suitablefor='" + mealsuitblefor + "' and sizez='" + sizez + "' ";
                                String qqz = "update iteminstock set qty=qty-1 where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitblefor + "' and sizez='" + sizez + "' ";

                                Dbconnection.iud(query7);
                                Dbconnection.iud(qqz);
                                contentz = "ok";
                            }
                            else
                            {
                                contentz = "lowaty";

                            }


                        }
                    }
                    else {
                        contentz = "stock cz";
                    }

                }
            }
            else {
                contentz = "empty "+itemname + mealtype + mealsuitblefor + sizez + cartidlaodz;
            }

                    return Content(contentz);
        }

        //remove One item from cart
        [HttpPost]
        public ActionResult removeOneItemcart(String itemname, String mealtype, String mealsuitblefor, String sizez, String cartidz)
        {

            
            String contentz = "";
            int cartidlaodz = Convert.ToInt32(cartidz);
            //string query5 = "SELECT * FROM cartitems WHERE cartidz='7' AND itemname='Chicken Cheese Burger' AND mealtyepe='Spicy' AND suitablefor='dinner' AND sizez='small'";
            string query5 = "SELECT * FROM cartitems WHERE cartidz='" + cartidlaodz + "' AND itemname='" + itemname + "' AND mealtyepe='" + mealtype + "' AND suitablefor='" + mealsuitblefor + "' AND sizez='" + sizez + "'";
            Dbconnection.closeCon();
            MySqlDataReader row3 = Dbconnection.search(query5);
            if (row3.HasRows)
            {
                if (row3.Read())
                {
                    int qty = 1;
                    int stockqty = Convert.ToInt32(row3["qty"].ToString());
                    int final_qty = stockqty - 1;
                    if (final_qty == 0)
                    {
                       
                        contentz = "lowaty";
                    }
                    else
                    {
                        string query7 = "update  cartitems set qty=qty-'" + qty + "' where cartidz='" + cartidlaodz + "' and itemname='" + itemname + "' and mealtyepe='" + mealtype + "' and suitablefor='" + mealsuitblefor + "' and sizez='" + sizez + "' ";
                                String qqz = "update iteminstock set qty=qty+1 where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitblefor + "' and sizez='" + sizez + "' ";

                        Dbconnection.iud(query7);
                        Dbconnection.iud(qqz);
                        contentz = "ok";

                    }

                }
            }
            else
            {
                contentz = "empty " + itemname + mealtype + mealsuitblefor + sizez + cartidlaodz;
            }

            return Content(contentz);
        }
        //remove single item from cart
        [HttpPost]
        public ActionResult removeSingleItemcart(String itemname, String mealtype, String mealsuitblefor, String sizez, String cartidz)
        {

            
            String contentz = "";
            int cartidlaodz = Convert.ToInt32(cartidz);
            //string query5 = "SELECT * FROM cartitems WHERE cartidz='7' AND itemname='Chicken Cheese Burger' AND mealtyepe='Spicy' AND suitablefor='dinner' AND sizez='small'";
            string query5 = "delete FROM cartitems WHERE cartidz='" + cartidlaodz + "' AND itemname='" + itemname + "' AND mealtyepe='" + mealtype + "' AND suitablefor='" + mealsuitblefor + "' AND sizez='" + sizez + "'";
            Dbconnection.iud(query5);

            return Content("ok");
        }

        //user loadcheckout page
        [HttpGet]
        public ActionResult CheckoutPage()
        {
            String uname = Session["uname"] as String;
            String cartstat = "Active";
            List<BurgerShop.Models.CartItemsModel> cartItems = new List<BurgerShop.Models.CartItemsModel>();

            string query1 = "Select * from cart where emailaddress='" + uname + "' and statusz='" + cartstat + "' ";
            Dbconnection.closeCon();
            MySqlDataReader row1 = Dbconnection.search(query1);
            if (row1.HasRows)
            {

                if (row1.Read())
                {
                    int cartid = Convert.ToInt32(row1["idcart"].ToString());
                    string query5 = "Select * from cartitems where cartidz='" + cartid + "'";
                    Dbconnection.closeCon();
                    MySqlDataReader row2 = Dbconnection.search(query5);

                    if (row2.HasRows)
                    {
                        while (row2.Read())
                        {
                            CartItemsModel itemmdl = new CartItemsModel();
                            itemmdl.Idcartitems = Convert.ToInt32(row2["idcartitems"].ToString());
                            itemmdl.Cartidz = Convert.ToInt32(row2["cartidz"].ToString());
                            itemmdl.Emailaddress = row2["emailaddress"].ToString();
                            itemmdl.Itemname = row2["itemname"].ToString();
                            itemmdl.Mealtyepe = row2["mealtyepe"].ToString();
                            itemmdl.Suitablefor = row2["suitablefor"].ToString();
                            itemmdl.Sizez = row2["sizez"].ToString();

                            itemmdl.Unitprice = Convert.ToDouble(row2["unitprice"].ToString());
                            itemmdl.Qty = Convert.ToInt32(row2["qty"].ToString());
                            cartItems.Add(itemmdl);

                        }

                    }

                }

            }


            return View("CheckoutPage", cartItems);
        }

        //user place order
        [HttpPost]
        public ActionResult placeNeworder(String cartid,String city,String nameinfull,String contact,String addressz,String totalp) {

            String uname = Session["uname"] as String;
            String todaydate = DateTime.Now.ToString("dd/MM/yyyy");
            String todaytime = DateTime.Now.ToString("HH:mm:ss");
            String status = "Pending";
            int cartidgenarated = Convert.ToInt32(cartid);
            int _min = 1111;
            int _max = 9999;
            Random rdm = new Random();
            int num = rdm.Next(_min, _max);
            String genarated_orderid = "ORD" + num;
            int lastid = 0;

            string query4 = "insert into orderz(emailaddress,datez,timez,totalpricez,nameinfull,cityz,addressz,contactz,orderidgenarated,statusz) values('" + uname + "','" + todaydate + "' ,'" + todaytime + "' ,'" + totalp + "' ,'" + nameinfull + "' ,'" + city + "' ,'" + addressz + "' ,'" + contact + "','" + genarated_orderid + "','" + status + "')";
            Dbconnection.iud(query4);

            string query3 = "Select MAX(idcart) as x FROM cart";
            Dbconnection.closeCon();
            MySqlDataReader row11 = Dbconnection.search(query3);
            if (row11.HasRows)
            {
                while (row11.Read())
                {
                    lastid = Convert.ToInt32(row11["x"].ToString());
                }
            }

            string query5 = "Select * from cartitems where cartidz='" + cartidgenarated + "'";
            Dbconnection.closeCon();
            MySqlDataReader row2 = Dbconnection.search(query5);

            if (row2.HasRows)
            {
                while (row2.Read())
                {
                    
                    string query6 = "insert into orderdetailz(orderidz,itemname,mealtype,mealsuitable,sizez,unitprice,qty,orderidgenarated) values('" + lastid + "','" + row2["itemname"].ToString() + "' ,'" + row2["mealtyepe"].ToString() + "' ,'" + row2["suitablefor"].ToString() + "' ,'" + row2["sizez"].ToString() + "' ,'" + Convert.ToDouble(row2["unitprice"].ToString()) + "' ,'" + Convert.ToInt32(row2["qty"].ToString()) + "' ,'" + genarated_orderid + "')";
                    Dbconnection.iud2(query6);
                }
            }
            Dbconnection.closeCon();

            String query7 = "delete from cart where emailaddress='" + uname+"'";
            String query8 = "delete from cartitems where emailaddress='" + uname + "'";
            Dbconnection.iud(query8);
            Dbconnection.iud(query7);
            

            return Content("ok");
        }

        //user orderdetails page
        [HttpGet]
        public ActionResult LoadMyorders()
        {
            
            String uname = Session["uname"] as String;
            string query2 = "Select * from orderz where emailaddress='" + uname + "'  ";
            Dbconnection.closeCon();
            MySqlDataReader row2 = Dbconnection.search(query2);

            List<BurgerShop.Models.OrderzModel> itemmodellist = new List<BurgerShop.Models.OrderzModel>();
            if (row2.HasRows)
            {
                while (row2.Read())
                {
                    OrderzModel itemmdl = new OrderzModel();
                    itemmdl.Idorderz = Convert.ToInt32(row2["idorderz"].ToString());
                    itemmdl.Emailaddress = row2["emailaddress"].ToString();
                    itemmdl.Datez = row2["datez"].ToString();
                    itemmdl.Timez = row2["timez"].ToString();
                    itemmdl.Totalpricez = row2["totalpricez"].ToString();
                    itemmdl.Nameinfull = row2["nameinfull"].ToString();
                    itemmdl.Cityz = row2["cityz"].ToString();
                    itemmdl.Addressz = row2["addressz"].ToString();
                    itemmdl.Contactz = row2["contactz"].ToString();
                    itemmdl.Orderidgenarated = row2["orderidgenarated"].ToString();
                    itemmdl.Statusz = row2["statusz"].ToString();
                    itemmodellist.Add(itemmdl);

                }
            }



            return View("LoadMyorders", itemmodellist);
        }

        //user ridirect to load single orderdetails page
        [HttpPost]
        public ActionResult setorderId(String orderidgenarated)
        {
            Session["orderidloadz"] = orderidgenarated;
            return Content("ok");
        }

        //user  load single orderdetails page
        [HttpGet]
        public ActionResult LoadSingleOrder()
        {
            String genaratedid = Session["orderidloadz"] as String;
            string query2 = "Select * from orderdetailz where orderidgenarated='" + genaratedid + "'  ";
            Dbconnection.closeCon();
            MySqlDataReader row2 = Dbconnection.search(query2);

            List<BurgerShop.Models.OrderdetailzModel> itemmodellist = new List<BurgerShop.Models.OrderdetailzModel>();
            if (row2.HasRows)
            {
                while (row2.Read())
                {
                    OrderdetailzModel itemmdl = new OrderdetailzModel();
                    itemmdl.Idorderdetails = Convert.ToInt32(row2["idorderdetails"].ToString());
                    itemmdl.Itemname = row2["itemname"].ToString();
                    itemmdl.Mealtype = row2["mealtype"].ToString();
                    itemmdl.Mealsuitable = row2["mealsuitable"].ToString();
                    itemmdl.Sizez = row2["sizez"].ToString();
                    itemmdl.Unitprice= Convert.ToDouble(row2["unitprice"].ToString());
                    itemmdl.Qty = Convert.ToInt32(row2["qty"].ToString());

                    itemmodellist.Add(itemmdl);

                }
            }



            return View("LoadSingleOrder", itemmodellist);


        }








    }
}