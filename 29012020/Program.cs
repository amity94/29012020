using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace _29012020
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
                Console.WriteLine("Without using");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Salaries";


                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                List<Object> list = new List<object>();
                while (reader.Read())
                {
                    Console.WriteLine($" {reader["ID"]}, {reader["FIRSTNAME"]} {reader["LASTNAME"]}, {reader["SALARY"]}");
                    var e = new
                    {
                        Id = reader["ID"],
                        FirstName = reader["FIRSTNAME"]
                    };
                    list.Add(e);
                }
                cmd.Connection.Close();

                Console.WriteLine("!===============================!");
                Console.WriteLine("With using");
                List<object> results = new List<object>();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand($"SELECT * from Salaries", connection))
                    {
                        using (SqlDataReader reader2 = command.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                Console.WriteLine($" {reader2["ID"]}, {reader2["FIRSTNAME"]} {reader2["LASTNAME"]}, {reader2["SALARY"]}");
                                var obj = new
                                {
                                    Id = reader2["ID"],
                                    FirstName = reader2["FIRSTNAME"]
                                };
                                results.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                }
            #endregion

            Type employee_type = Type.GetType("_29012020.Employee");
            Type type = Type.GetType("_29012020.Employee");
            Employee emp = new Employee();
            if(type == employee_type) 
            {
                if(type == typeof(Employee))
                {
                    Console.WriteLine();
                }
                if(type == emp.GetType())
                {
                    Console.WriteLine();
                }
                Console.WriteLine();
                var t3 = type.GetType();
                var t4 = type.GetType();
                if(t3 == t4)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("full name = {0}", type.FullName);
            Console.WriteLine("just the class name = {0}", type.Name);
            Console.WriteLine("just the namespace = {0}", type.Namespace);
            Console.WriteLine();
            Console.WriteLine("methods in customer class");
            
            MethodInfo[] methods = employee_type.GetMethods();
            foreach(MethodInfo method in methods)
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            Console.WriteLine();

            PropertyInfo[] properties = employee_type.GetProperties();
            foreach(PropertyInfo property in properties)
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            Console.WriteLine();

            ConstructorInfo[] constructors = employee_type.GetConstructors();
            foreach(ConstructorInfo constructor in constructors)
                Console.WriteLine(constructor);

        }
    }
}

