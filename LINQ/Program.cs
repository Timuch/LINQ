using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("     Employees:");
            foreach (var a in Employee.GetEmployeesList())
            {
                a.Print();
            }

            Console.WriteLine("     EmployeesEntries:");
            foreach (var a in EmployeeOptionEntry.GetEmployeeOptionEntries())
            {
                a.Print();
            }

            Where();
            Select();
            SelectMany();
            OrderBy();
            ThenBy();
            Join();
            GroupJoin();
            Console.ReadKey();
        }

        private static void Where()
        {
            Console.WriteLine("     WhereGame");

            Console.WriteLine("     Employees where firstname.lenth > 5:");
            foreach (var a in Employee.GetEmployeesList().Where(e => e.firstName.Length > 5))
            {
                a.Print();
            }

            Console.WriteLine("     Employees where index % 2 == 0:");
            foreach (var a in Employee.GetEmployeesList().Where((e, i) => i % 2 == 0))
            {
                a.Print();
            }

            Console.WriteLine("     Employees where firstname.lenth > 5 && index % 2 == 0:");
            foreach (var a in Employee.GetEmployeesList().Where((e, i) => e.firstName.Length > 5 && i % 2 == 0))
            {
                a.Print();
            }
        }

        private static void Select()
        {
            Console.WriteLine("     Selectgame");

            Console.WriteLine("     Employee's firstName:");
            foreach (var a in Employee.GetEmployeesList().Select(e => e.firstName))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("     Employee's firstname lengths:");
            foreach (var a in Employee.GetEmployeesList().Select(e => new { employee = e, length = e.firstName.Length }))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("     Employee's indexes:");
            foreach (var e in Employee.GetEmployeesList().Select((e, i) => new { employee = e, index = i }))
            {
                Console.WriteLine(e);
            }
        }

        private static void SelectMany()
        {
            Console.WriteLine("     SelectManyGame");

            Console.WriteLine("     Employee's chars");
            foreach (var a in Employee.GetEmployeesList().SelectMany(e => e.firstName.ToArray()))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("     Employee's optionEntries count:");
            var employees = Employee.GetEmployeesList();
            var employeesOptionEntries = EmployeeOptionEntry.GetEmployeeOptionEntries();
            foreach (var a in employees.SelectMany(e => employeesOptionEntries.Where(eo => eo.id == e.id).Select(eo => new { eo.id, count = eo.optionsCount })))
            {
                Console.WriteLine(a);
            }
        }

        private static void OrderBy()
        {
            Console.WriteLine("     OrderByGame");

            Console.WriteLine("     Ordered by LastName");
            foreach (var a in Employee.GetEmployeesList().OrderBy(e => e.lastName))
            {
                a.Print();
            }

            Console.WriteLine("     Ordered by firstName length by custom comparer");
            foreach (var a in Employee.GetEmployeesList().OrderBy((e => e.firstName), new CustomStringComparer()))
            {
                a.Print();
            }

            Console.WriteLine("     Descending ordered by firstName length by custom comparer");
            foreach (var a in Employee.GetEmployeesList().OrderByDescending((e => e.firstName), new CustomStringComparer()))
            {
                a.Print();
            }            
        }

        private static void ThenBy()
        {
            Console.WriteLine("     Ordered by firstName length by custom comparer, then ordered by lastname length by custom comparer");
            foreach (var a in Employee.GetEmployeesList().OrderBy((e => e.firstName), new CustomStringComparer()).ThenBy((e => e.lastName), new CustomStringComparer()))
            {
                a.Print();
            }

            Console.WriteLine("     Ordered by firstName length by custom comparer, then descending ordered by lastname length by custom comparer");
            foreach (var a in Employee.GetEmployeesList().OrderBy((e => e.firstName), new CustomStringComparer()).ThenByDescending((e => e.lastName), new CustomStringComparer()))
            {
                a.Print();
            }
        }

        private static void Join()
        {
            Console.WriteLine("     Employees joins employeeOptionEntries");
            var employees = Employee.GetEmployeesList();
            var employeesOptionEntries = EmployeeOptionEntry.GetEmployeeOptionEntries();
            foreach (var a in employees.Join(employeesOptionEntries, e => e.id, o => o.id, (e, o) => new {e, o.optionsCount }))
            {
                Console.WriteLine(a);
            }
        }

        private static void GroupJoin()
        {
            Console.WriteLine("     Employees groupJoins employeeOptionEntries");
            var employees = Employee.GetEmployeesList();
            var employeesOptionEntries = EmployeeOptionEntry.GetEmployeeOptionEntries();
            foreach (var a in employees.GroupJoin(employeesOptionEntries, e => e.id, o => o.id, (e, o) => new {e, options = o.Sum(os => os.optionsCount) }))
            {
                Console.WriteLine(a);
            }
        }
    }
}
