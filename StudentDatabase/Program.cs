using System;
using System.Data.SqlClient;

namespace StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(); 
            try
            {
                connection.ConnectionString = "Integrated Security=true;Initial Catalog=StudentDB;Data Source=server\\SQLExpress";
                connection.Open();
                Console.Write("Please enter a Last Name: ");
                string studentLastName = Console.ReadLine(); 
                SqlCommand command = new SqlCommand(); 
                command.Connection = connection;
                command.CommandText = "SELECT Name, LastName,Semester,Direction FROM Students WHERE LastName='" + studentLastName + "'";
                Console.WriteLine("About to execute: {0}\n\n", command.CommandText);
                SqlDataReader dataReader = command.ExecuteReader(); 
                while(dataReader.Read())
                {
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
