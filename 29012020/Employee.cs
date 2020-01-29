using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29012020
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Employee()
        {

        }
        public Employee(int id, string firstname, string lastname, int salary)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Salary = salary;
        }
    }

}
