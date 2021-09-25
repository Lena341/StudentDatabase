using System;
using System.Data.SqlClient;

namespace StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(); //SqlConnection is an ADO.NET class that manages connection with SQL Server DB.
            try
            {
                //Here we try to create a connection to the DB. The connection will be of type Windows Authentication
                connection.ConnectionString = "Integrated Security=true;Initial Catalog=StudentDB;Data Source=LAPTOP-B566P0U1\\SQLExpress";
                connection.Open();
                Console.Write("Please enter a Last Name: ");
                string studentLastName = Console.ReadLine(); //The student's last name will be saved in this string
                SqlCommand command = new SqlCommand(); //SqlCommand is used for queries in a DB. It executes an order from an SQL command.
                command.Connection = connection;
                command.CommandText = "SELECT Name, LastName,Semester,Direction FROM Students WHERE LastName='" + studentLastName + "'";
                Console.WriteLine("About to execute: {0}\n\n", command.CommandText);
                SqlDataReader dataReader = command.ExecuteReader(); //With dataReader we can show the data from the DB
                while(dataReader.Read())
                {
                    //The while loop reads the lines from the dataReader variable.Read() method gets the next line from the DB.
                    //We use the GetXXXX() methods to get the info of every collumn. The 0,1,2,3 show which collumn will be next to read. 
                    string name = dataReader.GetString(0);
                    string lastName = dataReader.GetString(1);
                    int semester = dataReader.GetInt32(2);
                    string direction = dataReader.GetString(3);
                    Console.WriteLine("Name: {0}\nLast Name: {1}\nSemester: {2}\nDirection: {3}\n\n", name, lastName, semester, direction);
                }
                dataReader.Close();

            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error while accessing the DB:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
