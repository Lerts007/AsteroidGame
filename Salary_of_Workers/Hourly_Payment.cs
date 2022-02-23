using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_of_Workers
{
    internal class Hourly_Payment : Worker
    {
        public Hourly_Payment(string name, string surname, double salary) : base(name, surname, salary)
        {

        }
        public override double Salary(double salary)
        {
            return 20.8 * 8 * salary;
        }
    }
}
