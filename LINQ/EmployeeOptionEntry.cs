using System;
using System.Collections.Generic;

namespace LINQ
{
    public class EmployeeOptionEntry
    {
        public int id;
        public long optionsCount;
        public DateTime dateAwarded;

        public static List<EmployeeOptionEntry> GetEmployeeOptionEntries()
        {
            List<EmployeeOptionEntry> empOptions = new List<EmployeeOptionEntry>
            {
                new EmployeeOptionEntry
                {
                    id = 1,
                    optionsCount = 2,
                    dateAwarded = DateTime.Parse("1999/12/31")
                },
                new EmployeeOptionEntry
                {
                    id = 2,
                    optionsCount = 10000,
                    dateAwarded = DateTime.Parse("1992/06/30")
                },
                new EmployeeOptionEntry
                {
                    id = 2,
                    optionsCount = 10000,
                    dateAwarded = DateTime.Parse("1994/01/01")
                },
                new EmployeeOptionEntry
                {
                    id = 3,
                    optionsCount = 5000,
                    dateAwarded = DateTime.Parse("1997/09/30")
                },
                new EmployeeOptionEntry
                {
                    id = 2,
                    optionsCount = 10000,
                    dateAwarded = DateTime.Parse("2003/04/01")
                },
                new EmployeeOptionEntry
                {
                    id = 3,
                    optionsCount = 7500,
                    dateAwarded = DateTime.Parse("1998/09/30")
                },
                new EmployeeOptionEntry
                {
                    id = 3,
                    optionsCount = 7500,
                    dateAwarded = DateTime.Parse("1998/09/30")
                },
                new EmployeeOptionEntry
                {
                    id = 4,
                    optionsCount = 1500,
                    dateAwarded = DateTime.Parse("1997/12/31")
                },
                new EmployeeOptionEntry
                {
                    id = 101,
                    optionsCount = 2,
                    dateAwarded = DateTime.Parse("1998/12/31")
                }
            };

            return (empOptions);
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"id: {id.ToString().PadRight(5)} dateAwarded: {dateAwarded.ToString().PadRight(23)} optionsCount: {optionsCount.ToString().PadRight(3)}";
        }
    }
}
