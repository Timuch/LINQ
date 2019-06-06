using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Employee
    {
        public int id;
        public string firstName;
        public string lastName;

        public static List<Employee> GetEmployeesList()
        {
            List<Employee> al = new List<Employee>
            {
                new Employee { id = 1, firstName = "Joe", lastName = "Rattz" },
                new Employee { id = 2, firstName = "William", lastName = "Gates" },
                new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" },
                new Employee { id = 4, firstName = "David", lastName = "Lightman" },
                new Employee { id = 101, firstName = "Kevin", lastName = "Flynn" }
            };
            return (al);
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"id: {id.ToString().PadRight(5)} firstName: {firstName.PadRight(10)} lastName: {lastName.PadRight(10)}";
        }
    }
}
