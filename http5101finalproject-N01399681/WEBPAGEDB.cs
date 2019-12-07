using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

/*Code is referrenced from the in class example*/

namespace http5101finalproject_N01399681
{
    public class WEBPAGEDB
    {
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "webpages"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();


                //for every row in the result set
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }//end row
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        public HTTPpage FindPage(int id)
        {
            
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            
            HTTPpage page = new HTTPpage();
            try
            {
                //write a query with the id information provided
                string query = "select * from PAGES where pageid= " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run the query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                List<HTTPpage> Pages = new List<HTTPpage>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single page
                    HTTPpage Page = new HTTPpage();

                    //Look at each column in the result set row, add both the column name and the column value to our Page dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);

                        switch (key)
                        {
                            case "PAGETITLE":
                                Page.SetPtitle(value);
                                break;
                            case "PAGEBODY":
                                Page.SetPbody(value);
                                break;
                        }

                    }
                    //Add the student to the list of pages
                    Pages.Add(Page);
                }

                page = Pages[0]; //get the first page

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in the find page method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return page;
        }

        public void AddPage(HTTPpage new_page)
        {
            

            string query = "insert into pages (PAGETITLE,PAGEBODY) values ('{0}','{1}')";
            query = String.Format(query, new_page.GetPtitle(), new_page.GetPbody());


            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddPage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void DeletePage(int pageid)
        {
            string query = "DELETE from pages where PAGEID= {0}";
            query = String.Format(query,pageid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);

            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed Query " + cmd);
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the delete Page Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
        public void UpdatePage(int pageid, HTTPpage new_page)

        {
            Debug.WriteLine("I am inside the update page method");

            string query="update pages set PAGETITLE='{0}', PAGEBODY='{1}' where PAGEID='{2}'";
            query = String.Format(query, new_page.GetPtitle(), new_page.GetPbody(),pageid);
            Debug.WriteLine("This is the" + query);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Try to update a student with the information provided to us.
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                //If that doesn't seem to work, check Debug>Windows>Output for the below message
                Debug.WriteLine("Something went wrong in the UpdatePage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();



        }
    } 
         
    }