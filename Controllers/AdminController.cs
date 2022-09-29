using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BurgerShop.Models;
using MySql.Data.MySqlClient;
using System.Data;
using SchoolManagementBuildOne.Customclasess;
using System.Net;
using System.Net.Mail;

namespace BurgerShop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        [HttpGet]
        public ActionResult AdminHome()
        {
            return View();
        }
        //page ridirect
        public ActionResult AdminAddItem()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View("AdminLogin");
        }

        //Admin Login
        [HttpPost]
        public ActionResult GoTOAdminLogz(String uname,String pw) {


            MySqlDataAdapter adapter = new MySqlDataAdapter();

            String stat = "admin";
            string query = "Select * from userdetails where emailz='" + uname + "' and passwordz='" + pw + "' and statusz='"+stat+"'";
            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);
            if (row.HasRows)
            {
                if (row.Read())
                {
                    Session["adminuname"] = uname;
                    Session["adminpw"] = pw;

                }
                return Content("ok");
            }
            else
            {

                return Content("err");
            }
            
        }



        //Add new menu to shop
        [HttpPost]
        public ActionResult IAD(String itemname, String mealtype, String mealsuitblefor, String sizez, String descriptionz, String unitprice)
        {
            try
            {

                Console.WriteLine("Comeszzz");

                String firsrsql = "select * from itemdetails where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitblefor='" + mealsuitblefor + "' and sizez='" + sizez + "'";
                Dbconnection.closeCon();
                MySqlDataReader row = Dbconnection.search(firsrsql);
                if (row.HasRows)
                {
                    return Content("alre");
                }
                else
                {
                    Console.WriteLine("saved");
                    String stat = "Active";
                    int qty = 0;
                    double uu = Convert.ToDouble(unitprice);
                    String querry = "insert into itemdetails(itemname,mealtype,mealsuitblefor,sizez,descriptionz,unitprice,statusz) values('" + itemname + "','" + mealtype + "','" + mealsuitblefor + "','" + sizez + "','" + descriptionz + "','" + uu + "','" + stat + "')";
                    String querry2 = "insert into iteminstock(itemname,mealtype,mealsuitable,sizez,unitprice,qty) values('" + itemname + "','" + mealtype + "','" + mealsuitblefor + "','" + sizez + "','" + uu + "','" + qty + "')";

                    Dbconnection.iud(querry);
                    Dbconnection.iud(querry2);
                    return Content("ok");
                }


            }
            catch (Exception eee)
            {
                Console.WriteLine("Erroez");
                return Content("error");
            }
        }

        //Load all user details
        [HttpGet]
        public ActionResult LoadUser()
        {


            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from userdetails where statusz='Active'";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<UserModel> userProfileModelList = new List<UserModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    UserModel userProfileModel = new UserModel();
                    userProfileModel.Userid = Convert.ToInt32(row["userid"].ToString());
                    userProfileModel.Nameinfull = row["nameinfull"].ToString();
                    userProfileModel.Emailz = row["emailz"].ToString();
                    userProfileModel.Contactnumber = row["contactnumber"].ToString();
                    userProfileModel.City = row["city"].ToString();
                    userProfileModel.Addressz = row["addressz"].ToString();
                    userProfileModel.Statusz = row["statusz"].ToString();
                    userProfileModelList.Add(userProfileModel);
                }

            }
            return View("LoadUser", userProfileModelList);
        }

        //Load all Item details
        [HttpGet]
        public ActionResult LoadAllItems()
        {


            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from itemdetails where statusz='Active'";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<ItemModel> userProfileModelList = new List<ItemModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    ItemModel userProfileModel = new ItemModel();
                    userProfileModel.Itemid = Convert.ToInt32(row["itemid"].ToString());
                    userProfileModel.Itemname = row["itemname"].ToString();
                    userProfileModel.Mealtype = row["mealtype"].ToString();
                    userProfileModel.Mealsuitblefor = row["mealsuitblefor"].ToString();
                    userProfileModel.Sizez = row["sizez"].ToString();
                    userProfileModel.Descriptionz = row["descriptionz"].ToString();
                    userProfileModel.Unitprice = Convert.ToDouble(row["unitprice"].ToString());
                    userProfileModel.Statusz = row["statusz"].ToString();
                    userProfileModelList.Add(userProfileModel);
                }

            }
            return View("LoadAllItems", userProfileModelList);
        }

        //Report Load all user details
        [HttpGet]
        public ActionResult LoadUserReport()
        {


            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from userdetails where statusz='Active'";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<UserModel> userProfileModelList = new List<UserModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    UserModel userProfileModel = new UserModel();
                    userProfileModel.Userid = Convert.ToInt32(row["userid"].ToString());
                    userProfileModel.Nameinfull = row["nameinfull"].ToString();
                    userProfileModel.Emailz = row["emailz"].ToString();
                    userProfileModel.Contactnumber = row["contactnumber"].ToString();
                    userProfileModel.City = row["city"].ToString();
                    userProfileModel.Addressz = row["addressz"].ToString();
                    userProfileModel.Statusz = row["statusz"].ToString();
                    userProfileModelList.Add(userProfileModel);
                }

            }
            return View("LoadUserReport", userProfileModelList);
        }

        //Remove User Admin
        [HttpPost]
        public ActionResult AdminRemoveUSer(String userid)
        {
            String stat = "removed";
            String que = "Update userdetails set statusz='" + stat + "' where userid='" + userid + "' ";
            Dbconnection.iud(que);

            return Content("ok");
        }

        //Remove item Admin
        [HttpPost]
        public ActionResult AdminRemoveItem(String userid,String itemname)
        {
            String stat = "removed";
            String que = "delete from  itemdetails  where itemid='" + userid + "' ";
            String que2 = "delete from iteminstock where itemname='"+itemname+"' ";
            Dbconnection.iud(que);
            Dbconnection.iud(que2);

            return Content("ok");
        }

        //Active User Admin
        [HttpPost]
        public ActionResult AdminActiveUSer(String userid)
        {
            String stat = "Active";
            String que = "Update userdetails set statusz='" + stat + "' where userid='" + userid + "' ";
            Dbconnection.iud(que);

            return Content("ok");
        }

        //Load all removed user details
        [HttpGet]
        public ActionResult LoadUserRemoved()
        {


            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from userdetails where statusz='removed'";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<UserModel> userProfileModelList = new List<UserModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    UserModel userProfileModel = new UserModel();
                    userProfileModel.Userid = Convert.ToInt32(row["userid"].ToString());
                    userProfileModel.Nameinfull = row["nameinfull"].ToString();
                    userProfileModel.Emailz = row["emailz"].ToString();
                    userProfileModel.Contactnumber = row["contactnumber"].ToString();
                    userProfileModel.City = row["city"].ToString();
                    userProfileModel.Addressz = row["addressz"].ToString();
                    userProfileModel.Statusz = row["statusz"].ToString();
                    userProfileModelList.Add(userProfileModel);
                }

            }
            return View("LoadUserRemoved", userProfileModelList);
        }

        //Load Pending Orders
        [HttpGet]
        public ActionResult LoadpendingOrders()
        {
            String stat = "Pending";
            string query2 = "Select * from orderz where statusz='" + stat + "'  ";
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



            return View("LoadpendingOrders", itemmodellist);

        }

        //Load Accept Orders
        [HttpGet]
        public ActionResult LoadAcceptOrders()
        {
            String stat = "Active";
            string query2 = "Select * from orderz where statusz='" + stat + "'  ";
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



            return View("LoadAcceptOrders", itemmodellist);

        }
        //Load cancelled Orders
        [HttpGet]
        public ActionResult LoadCancelledOrders()
        {
            String stat = "Cancelled";
            string query2 = "Select * from orderz where statusz='" + stat + "'  ";
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



            return View("LoadCancelledOrders", itemmodellist);

        }


        //Accept Order Admin
        [HttpPost]
        public ActionResult AcceptOrder(String orderidgenarated)
        {
            String stat = "Active";
            String useremail = "";

            string query2 = "Select * from orderz where orderidgenarated='" + orderidgenarated + "'  ";
            Dbconnection.closeCon();
            MySqlDataReader row2 = Dbconnection.search(query2);
            if (row2.HasRows)
            {
                if (row2.Read())
                {
                    useremail = row2["emailaddress"].ToString();
                }
            }


                    String que = "Update orderz set statusz='"+ stat + "' where orderidgenarated='"+orderidgenarated+"' ";
            Dbconnection.iud(que);
            try
            {
                String htmlString = "Your order " + orderidgenarated + " has being acceptted..!";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("eburgershop@gmail.com");
                message.To.Add(new MailAddress(useremail));
                message.Subject = "Your Order Status of E burger";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("eburgershop@gmail.com", "Eburger123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return Content("ok");
            }
            catch (Exception ee) {
                return Content("err"+ee);
            }


            
        }

        //remove Order Admin
        [HttpPost]
        public ActionResult RemoveOrder(String orderidgenarated)
        {
            String stat = "Cancelled";
            String useremail = "";

            string query2 = "Select * from orderz where orderidgenarated='" + orderidgenarated + "'  ";
            Dbconnection.closeCon();
            MySqlDataReader row2 = Dbconnection.search(query2);
            if (row2.HasRows)
            {
                if (row2.Read())
                {
                    useremail = row2["emailaddress"].ToString();
                }
            }


            String que = "Update orderz set statusz='" + stat + "' where orderidgenarated='" + orderidgenarated + "' ";
            Dbconnection.iud(que);
            try
            {
                String htmlString = "Your order " + orderidgenarated + " has being Cancelled..!";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("eburgershop@gmail.com");
                message.To.Add(new MailAddress(useremail));
                message.Subject = "Your Order Status of E burger";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("eburgershop@gmail.com", "Eburger123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return Content("ok");
            }
            catch (Exception ee)
            {
                return Content("err" + ee);
            }
        }

        [HttpPost]
        public ActionResult setorderIdToLoadAdmin(String orderidgenarated)
        {
            Session["orderidloadzh"] = orderidgenarated;
            return Content("ok");
        }
        //admin  load single orderdetails page
        [HttpGet]
        public ActionResult LoadSingleOrderAdmin()
        {
            String genaratedid = Session["orderidloadzh"] as String;
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
                    itemmdl.Unitprice = Convert.ToDouble(row2["unitprice"].ToString());
                    itemmdl.Qty = Convert.ToInt32(row2["qty"].ToString());
                    itemmdl.Orderidgenarated = genaratedid;

                    itemmodellist.Add(itemmdl);

                }
            }



            return View("LoadSingleOrderAdmin", itemmodellist);


        }


        //Add today stock page view
        [HttpGet]
        public ActionResult AddItemsTOStock()
        {


            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from iteminstock";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<StockModel> stocklist = new List<StockModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    StockModel userProfileModel = new StockModel();
                    userProfileModel.Idstock = Convert.ToInt32(row["idstock"].ToString());
                    userProfileModel.Itemname = row["itemname"].ToString();
                    userProfileModel.Mealtype = row["mealtype"].ToString();
                    userProfileModel.Mealsuitable = row["mealsuitable"].ToString();
                    userProfileModel.Size = row["sizez"].ToString();
                    userProfileModel.Unitprice = Convert.ToDouble(row["unitprice"].ToString());
                    userProfileModel.Qty = Convert.ToInt32(row["qty"].ToString());
                    stocklist.Add(userProfileModel);
                }

            }
            return View("AddItemsTOStock", stocklist);
        }




        
        //Report current stock
        [HttpGet]
        public ActionResult ViewCurrentStock()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from iteminstock";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<StockModel> stocklist = new List<StockModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    StockModel userProfileModel = new StockModel();
                    userProfileModel.Idstock = Convert.ToInt32(row["idstock"].ToString());
                    userProfileModel.Itemname = row["itemname"].ToString();
                    userProfileModel.Mealtype = row["mealtype"].ToString();
                    userProfileModel.Mealsuitable = row["mealsuitable"].ToString();
                    userProfileModel.Size = row["sizez"].ToString();
                    userProfileModel.Unitprice = Convert.ToDouble(row["unitprice"].ToString());
                    userProfileModel.Qty = Convert.ToInt32(row["qty"].ToString());
                    stocklist.Add(userProfileModel);
                }

            }
            return View("ViewCurrentStock", stocklist);
        }
        //report Stock History
        [HttpGet]
        public ActionResult ViewStockHistory()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from stockhistory";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<StockHistoryModel> stocklist = new List<StockHistoryModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    StockHistoryModel userProfileModel = new StockHistoryModel();
                    userProfileModel.Idstockhostoty = Convert.ToInt32(row["idstockhostoty"].ToString());
                    userProfileModel.Itemname = row["itemname"].ToString();
                    userProfileModel.Mealtype = row["mealtype"].ToString();
                    userProfileModel.Mealsuitable = row["suitablefor"].ToString();
                    userProfileModel.Size = row["size"].ToString();
                    userProfileModel.Datez = row["datez"].ToString();
                    userProfileModel.Timez = row["timez"].ToString();
                    userProfileModel.Addedqty = Convert.ToInt32(row["addedqty"].ToString());
                    String ccqty = row["clearedqty"].ToString();
                    if (ccqty.Equals("") || ccqty.Equals(null))
                    {
                        userProfileModel.Clearedqty = 0;
                    }
                    else {
                        userProfileModel.Clearedqty = Convert.ToInt32(ccqty);
                    }
                   
                    stocklist.Add(userProfileModel);
                }

            }
            return View("ViewStockHistory", stocklist);
        }


        //clear currunt stock
        [HttpGet]
        public ActionResult ViewCurrentStockToClear()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            string query = "Select * from iteminstock";

            Dbconnection.closeCon();
            MySqlDataReader row = Dbconnection.search(query);


            List<StockModel> stocklist = new List<StockModel>();
            if (row.HasRows)
            {
                while (row.Read())
                {

                    StockModel userProfileModel = new StockModel();
                    userProfileModel.Idstock = Convert.ToInt32(row["idstock"].ToString());
                    userProfileModel.Itemname = row["itemname"].ToString();
                    userProfileModel.Mealtype = row["mealtype"].ToString();
                    userProfileModel.Mealsuitable = row["mealsuitable"].ToString();
                    userProfileModel.Size = row["sizez"].ToString();
                    userProfileModel.Unitprice = Convert.ToDouble(row["unitprice"].ToString());
                    userProfileModel.Qty = Convert.ToInt32(row["qty"].ToString());
                    stocklist.Add(userProfileModel);
                }

            }
            return View("ViewCurrentStockToClear", stocklist);
        }



        //Add Item to current stock action
        [HttpPost]
        public ActionResult Addtodaystock(String itemname, String mealtype, String mealsuitblefor, String sizez, String qty)
        {
            try
            {
                int qtyload = Convert.ToInt32(qty);
                String que1 = "update iteminstock set qty=qty+'"+ qtyload + "' where itemname='"+itemname+ "' and mealtype='"+mealtype+ "' and mealsuitable='"+mealsuitblefor+ "' and sizez='"+sizez+"' ";
                String todaydate = DateTime.Now.ToString("dd/MM/yyyy");
                String todaytime = DateTime.Now.ToString("HH:mm:ss");
                Dbconnection.iud(que1);
                String que2 = "select * from stockhistory where datez='" + todaydate + "' and itemname='" + itemname + "' and mealtype='" + mealtype + "' and suitablefor='" + mealsuitblefor + "' and size='" + sizez + "'";
                
                Dbconnection.closeCon();
                MySqlDataReader row = Dbconnection.search(que2);
                if (row.HasRows)
                {
                    String querry3 = "update stockhistory set addedqty=addedqty+'"+qtyload+ "' where itemname='"+itemname+ "' and mealtype='"+mealtype+ "' and suitablefor='"+mealsuitblefor+ "' and size='"+sizez+"'";
                    Dbconnection.iud(querry3);
                    return Content("ok");
                }
                else
                {
                    
                    String querry4 = "insert into stockhistory(itemname,mealtype,suitablefor,size,addedqty,datez,timez) values('" + itemname+"','"+mealtype+"','"+mealsuitblefor+"','"+sizez+"','"+ qtyload + "','"+todaydate+"','"+todaytime+"')";                  
                    Dbconnection.iud(querry4);
                    return Content("ok");
                }

            }
            catch (Exception eee)
            {
                Console.WriteLine(eee);
                return Content(""+eee);
            }
        }

        //Clear today stock
        [HttpPost]
        public ActionResult cleartodaystock(String itemname, String mealtype, String mealsuitblefor, String sizez, String qty)
        {
            try
            {
                int todayqty = 0;
                int qtyload = Convert.ToInt32(qty);
                String que1 = "update iteminstock set qty='" + todayqty + "' where itemname='" + itemname + "' and mealtype='" + mealtype + "' and mealsuitable='" + mealsuitblefor + "' and sizez='" + sizez + "' ";
                String todaydate = DateTime.Now.ToString("dd/MM/yyyy");
                String todaytime = DateTime.Now.ToString("HH:mm:ss");
                Dbconnection.iud(que1);
                String que2 = "select * from stockhistory where datez='" + todaydate + "' and itemname='" + itemname + "' and mealtype='" + mealtype + "' and suitablefor='" + mealsuitblefor + "' and size='" + sizez + "'";

                Dbconnection.closeCon();
                MySqlDataReader row = Dbconnection.search(que2);
                if (row.HasRows)
                {
                    String querry3 = "update stockhistory set clearedqty='" + qtyload + "' where itemname='" + itemname + "' and mealtype='" + mealtype + "' and suitablefor='" + mealsuitblefor + "' and size='" + sizez + "' and datez='" + todaydate + "'";
                    Dbconnection.iud(querry3);
                    return Content("ok");
                }
                else {
                    return Content("aw");
                }
               

            }
            catch (Exception eee)
            {
                Console.WriteLine(eee);
                return Content("" + eee);
            }
        }

        //Logout Admin
        [HttpGet]
        public ActionResult ADminLogout()
        {

            Session["adminuname"] = null;
            Session["adminpw"] = null;
            Session["orderidloadzh"] = null;

            Session.Remove("uname");
            Session.Remove("pw");
            Session.Remove("orderidloadz");

            


            return View("AdminLogin");
        }





    }
}