using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_of_Workers
{
    internal abstract class Worker : IComparable
    {
        public string _Name;
        public string _Surname;
        public double _Salary;

        protected Worker(string name, string surname, double salary)
        {
            _Name = name;
            _Surname = surname;
            _Salary = Salary(salary);
        }

        public abstract double Salary(double salary);

        public int CompareTo(object? obj)
        {

            if (((Worker)obj)._Name[0] > _Name[0])
                    return -1;
            if (((Worker)obj)._Name[0] == _Name[0])
                    return 0;
            return 1;
        }
    }
}
