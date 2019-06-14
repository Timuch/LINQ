using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static readonly List<Employee> employees = Employee.GetEmployeesList();
        static readonly List<EmployeeOptionEntry> employeesOptionEntries = EmployeeOptionEntry.GetEmployeeOptionEntries();

        static void Main()
        {
            Console.WriteLine("     Employees:");
            foreach (var a in employees)
            {
                a.Print();
            }

            Console.WriteLine("     EmployeesEntries:");
            foreach (var a in employeesOptionEntries)
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
            GroupBy();
            ToDictionary();
            ToLookup();
            Console.ReadKey();
        }

        private static void Where()
        {
            Console.WriteLine("     Where");

            Console.WriteLine("     Employees where firstname.lenth > 5:");
            foreach (var a in employees.Where(e => e.firstName.Length > 5))
            {
                a.Print();
            }

            Console.WriteLine("     Employees where index % 2 == 0:");
            foreach (var a in employees.Where((e, i) => i % 2 == 0))
            {
                a.Print();
            }

            Console.WriteLine("     Employees where firstname.lenth > 5 && index % 2 == 0:");
            foreach (var a in employees.Where((e, i) => e.firstName.Length > 5 && i % 2 == 0))
            {
                a.Print();
            }
        }

        private static void Select()
        {
            Console.WriteLine("     Select");

            Console.WriteLine("     Employee's firstName:");
            foreach (var a in employees.Select(e => e.firstName))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("     Employee's firstname lengths:");
            foreach (var a in employees.Select(e => new { employee = e, length = e.firstName.Length }))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("     Employee's indexes:");
            foreach (var e in employees.Select((e, i) => new { employee = e, index = i }))
            {
                Console.WriteLine(e);
            }
        }

        private static void SelectMany()
        {
            Console.WriteLine("     SelectMany");

            Console.WriteLine("     Employee's chars");
            foreach (var a in employees.SelectMany(e => e.firstName.ToArray()))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("     Employee's optionEntries count:");
            foreach (var a in employees.SelectMany(e => employeesOptionEntries.Where(eo => eo.id == e.id).Select(eo => new { eo.id, count = eo.optionsCount })))
            {
                Console.WriteLine(a);
            }
        }

        private static void OrderBy()
        {
            Console.WriteLine("     OrderBy");

            Console.WriteLine("     Ordered by LastName");
            foreach (var a in employees.OrderBy(e => e.lastName))
            {
                a.Print();
            }

            Console.WriteLine("     Ordered by firstName length by custom comparer");
            foreach (var a in employees.OrderBy((e => e.firstName), new StringLenthComparer()))
            {
                a.Print();
            }

            Console.WriteLine("     Descending ordered by firstName length by custom comparer");
            foreach (var a in employees.OrderByDescending((e => e.firstName), new StringLenthComparer()))
            {
                a.Print();
            }            
        }

        private static void ThenBy()
        {
            Console.WriteLine("     ThenBy");

            Console.WriteLine("     Ordered by firstName length by custom comparer, then ordered by lastname length by custom comparer");
            foreach (var a in employees.OrderBy((e => e.firstName), new StringLenthComparer()).ThenBy((e => e.lastName), new StringLenthComparer()))
            {
                a.Print();
            }

            Console.WriteLine("     Ordered by firstName length by custom comparer, then descending ordered by lastname length by custom comparer");
            foreach (var a in employees.OrderBy((e => e.firstName), new StringLenthComparer()).ThenByDescending((e => e.lastName), new StringLenthComparer()))
            {
                a.Print();
            }
        }

        private static void Join()
        {
            Console.WriteLine("     Join");

            Console.WriteLine("     Employees joins employeeOptionEntries");
            foreach (var a in employees.Join(employeesOptionEntries, e => e.id, o => o.id, (e, o) => new {e, o.optionsCount }))
            {
                Console.WriteLine(a);
            }
        }

        private static void GroupJoin()
        {
            Console.WriteLine("     GroupJoin");

            Console.WriteLine("     Employees groupJoins employeeOptionEntries");            
            foreach (var a in employees.GroupJoin(employeesOptionEntries, e => e.id, o => o.id, (e, o) => new {e, options = o.Sum(os => os.optionsCount) }))
            {
                Console.WriteLine(a);
            }
        }

        private static void GroupBy()
        {
            Console.WriteLine("     GroupBy");

            Console.WriteLine("     Entries grouped by id");
            foreach (var entrieGroup in employeesOptionEntries.GroupBy(e => e.id))
            {
                Console.WriteLine($"    Group id = {entrieGroup.Key}");
                foreach(var entrie in entrieGroup)
                {
                    entrie.Print();
                }
            }

            Console.WriteLine("     Employees grouped by firstName <= 5 and firstname > 5");
            foreach(var employeeGroup in employees.GroupBy(e => e.firstName, new StringLengthEqualityComparer()))
            {
                if (StringLengthEqualityComparer.IsSmall(employeeGroup.Key))
                    Console.WriteLine($"    Small first name length:");
                else
                    Console.WriteLine($"    Big first name length:");

                foreach (var employee in employeeGroup)
                {
                    employee.Print();
                }
            }

            Console.WriteLine("     Date awarded for employees");
            foreach(var entrieGroup in employeesOptionEntries.GroupBy(e => e.id, o => o.dateAwarded))
            {
                employees.Where(e => e.id == entrieGroup.Key).FirstOrDefault().Print();
                foreach(var entrie in entrieGroup)
                {
                    Console.WriteLine(entrie);
                }
            }

            Console.WriteLine("     Date awarded for employees with firstname <= 5 and firstName > 5");
            var employeesAndTheirOptionEntries = employees.Join(employeesOptionEntries, e => e.id, e => e.id, (e, o) => new { employee = e, employeeOptionEntry = o });
            foreach (var group in employeesAndTheirOptionEntries.GroupBy(x => x.employee.firstName, x => x.employeeOptionEntry.dateAwarded, new StringLengthEqualityComparer()))
            {
                if(StringLengthEqualityComparer.IsSmall(group.Key))
                    Console.WriteLine($"    Small first name length:");
                else
                    Console.WriteLine($"    Big first name length:");

                foreach(var date in group.OrderBy(x => x))
                {
                    Console.WriteLine(date);
                }
            }
        }

        private static void ToDictionary()
        {
            Console.WriteLine("     ToDictionary");

            Console.WriteLine("     Employees in dictionary, key is id:");
            foreach (var employee in employees.ToDictionary(e => e.id))
            {
                Console.WriteLine($"Key {employee.Key.ToString().PadRight(10)} Value {employee.Value}");
            }

            Console.WriteLine("     Employees in dictionary, key is id, firstname is selector:");
            foreach (var employee in employees.ToDictionary(e => e.id, e => e.firstName))
            {
                Console.WriteLine($"Key {employee.Key.ToString().PadRight(10)} Value {employee.Value}");
            }   
        }

        private static void ToLookup()
        {
            Console.WriteLine("     ToLookup");

            Console.WriteLine("     Employees in lookup, key is id:");
            foreach (var employeeGroup in employees.ToLookup(e => e.id))
            {
                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine($"Key {employeeGroup.Key.ToString().PadRight(10)} Value {employee}");
                }                
            }

            Console.WriteLine("     Employees in lookup, key is id, firstname is selector:");
            foreach (var employeeGroup in employees.ToLookup(e => e.id, e => e.firstName))
            {
                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine($"Key {employeeGroup.Key.ToString().PadRight(10)} Value {employee}");
                }
            }

            Console.WriteLine("     Employees in lookup, key is firstName, lastName is selector, String length compare:");
            foreach (var employeeGroup in employees.ToLookup(e => e.firstName, e => e.lastName, new StringLengthEqualityComparer()))
            {
                if (StringLengthEqualityComparer.IsSmall(employeeGroup.Key))
                    Console.WriteLine($"    Small first name length:");
                else
                    Console.WriteLine($"    Big first name length:");

                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine($"Key {employeeGroup.Key.ToString().PadRight(10)} Value {employee}");
                }
            }
        }
    }
}