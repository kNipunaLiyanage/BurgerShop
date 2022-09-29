using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SchoolManagementBuildOne.Customclasess
{
    class Dbconnection
    {
        //Start Define Static variables
        public static MySqlConnection c;
        public static String myConnectionString;
        //End Define Static variables

        //Start Define Singleton create connection method
        public static MySqlConnection createCon()
        {

            myConnectionString = "Database=eburgershop;Data Source=localhost;User Id=root;Password=";
            c = new MySqlConnection(myConnectionString);

            return c;
        }
        //End Define Singleton create connection method

        //Start : A single method to insert update delete data
        public static void iud(String sql)
        {

            if (c == null)
            {
                createCon();
            }
            c.Close();
            string myiudquery = sql;
            MySqlCommand myCommand = new MySqlCommand(myiudquery);
            myCommand.Connection = c;
            c.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
            c.Close();
        }

        public static void iud2(String sql)
        {
            String myConnectionString2 = "Database=eburgershop;Data Source=localhost;User Id=root;Password=";
            MySqlConnection c2 = new MySqlConnection(myConnectionString2);
            
            string myiudquery = sql;
            MySqlCommand myCommand = new MySqlCommand(myiudquery);
            myCommand.Connection = c2;
            c2.Open();
            myCommand.ExecuteNonQuery();
            //myCommand.Connection.Close();
           // c.Close();
        }
        //End : A single method to insert update delete data

        //Start :  method Close the connection that created 
        public static void closeCon()
        {

            if (c == null)
            {
              
            }
            else { 
            c.Close();

            }
        }
        //End :  method Close the connection that created 

        //Start : A single method search data
        public static MySqlDataReader search(String sql) 
        {

            if (c == null) {
            createCon();
            }
            MySqlCommand myCommand = new MySqlCommand(sql);
            myCommand.Connection = c;
            c.Open();
           
            MySqlDataReader datareader = myCommand.ExecuteReader();

            
            return datareader;
        }
        //END : A single method search data
        public static MySqlDataAdapter searchGrid(String sql)
        {

            if (c == null)
            {
                createCon();
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, c);
            

            return adapter;
        }

    }




    }





