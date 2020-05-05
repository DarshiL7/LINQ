using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LINQ_Queries
{
    class Program
    {
        Employee employee = new Employee();
        Incentive incentive = new Incentive();
        static List<Employee> Employees = new List<Employee>
        {
            new Employee{EmplyoeeId=1,FirstName="John",LastName="Abraham",Salary=1000000,JoiningDate="01-Jan-13 12.00.00 AM",Department="Banking"},
            new Employee{EmplyoeeId=2,FirstName="Michael",LastName="Clarke",Salary=800000,JoiningDate="01-JAN-13 12.00.00 AM",Department="Insurance"},
            new Employee{EmplyoeeId=3,FirstName="Roy",LastName="Thomas",Salary=700000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Banking"},
            new Employee{EmplyoeeId=4,FirstName="Tom",LastName="Jose",Salary=600000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Insurance"},
            new Employee{EmplyoeeId=5,FirstName="Jerry",LastName="Pinto",Salary=650000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Insurance"},
            new Employee{EmplyoeeId=6,FirstName="Philip",LastName="Mathew",Salary=750000,JoiningDate="01-JAN-13 12.00.00 AM",Department="Services"},
            new Employee{EmplyoeeId=7,FirstName="TestName1",LastName="123",Salary=650000,JoiningDate="01-JAN-13 12.00.00 AM",Department="Services"},
            new Employee{EmplyoeeId=8,FirstName="TestName2",LastName="Lname%",Salary=600000,JoiningDate="01-FEB-13 12.00.00 AM",Department="Insurance"},
        };
        static List<Incentive> Incentives = new List<Incentive>
        {
            new Incentive {EmployeeRefId=1,IncentiveDate="01-FEB-13",IncentiveAmount=5000},
            new Incentive {EmployeeRefId=2,IncentiveDate="01-FEB-13",IncentiveAmount=3000},
            new Incentive {EmployeeRefId=3,IncentiveDate="01-FEB-13",IncentiveAmount=4000},
            new Incentive {EmployeeRefId=1,IncentiveDate="01-JAN-13",IncentiveAmount=4500},
            new Incentive {EmployeeRefId=2,IncentiveDate="01-JAN-13",IncentiveAmount=3500},
        };
        static void Main(string[] args)
        {
            //Employee employees = new Employee();
            //employees.Employees
            //Incentive incentives = new Incentive();

            //Console.WriteLine("Hello World!");

            Console.WriteLine("Get all employee details from the employee table");
            IEnumerable<Employee> emplyeeQuery1 =
                from Employee in Employees
                select Employee;
            Console.WriteLine($"EmployeeId\tFirstName\tLastName\tSalary\tJoiningDate\t\tDepartment");
            foreach (Employee emp in emplyeeQuery1)
            {
                Console.WriteLine($"{emp.EmplyoeeId}\t\t{emp.FirstName}\t\t{emp.LastName}\t\t{emp.Salary}\t{emp.JoiningDate}\t{ emp.Department}");
            }
            Console.WriteLine();
            Console.WriteLine("Get First_Name, Last_Name from employee table");

            
            Console.WriteLine($"FirstName\tLastName");
            foreach (Employee emp in emplyeeQuery1)
            {
                Console.WriteLine($"{emp.FirstName}\t\t{emp.LastName}");
            }
            Console.WriteLine();
            Console.WriteLine("Get First_Name from employee table in upper case");

            Console.WriteLine("FirstName");
            foreach (Employee emp in emplyeeQuery1)
            {
                Console.WriteLine($"{emp.FirstName.ToUpper()}");
            }

            Console.WriteLine();
            Console.WriteLine("Get First_Name from employee table in lower case");

            Console.WriteLine("FirstName");
            foreach (Employee emp in emplyeeQuery1)
            {
                Console.WriteLine($"{emp.FirstName.ToLower()}");
            }

            Console.WriteLine();
            Console.WriteLine("Get unique DEPARTMENT from employee table");
            var employee = (from Employee in Employees select Employee.Department).Distinct();

            Console.WriteLine("Department");
            foreach (var emp in employee)
            {
                Console.WriteLine($"{emp}");
            }


            Console.WriteLine();
            Console.WriteLine("Select first 3 characters of FIRST_NAME from EMPLOYEE");

            var emp8 = from e in Employees select e.FirstName;
            foreach(var emp in emp8)
            {
                Console.WriteLine(emp.Substring(0, 3));
            }

            Console.WriteLine();
            Console.WriteLine("Get position of 'o' in name 'John' from employee table");


            var emp9 = from emp in Employees where emp.FirstName == "John" select emp;
            foreach (var emp in emp9)
            {
                Console.WriteLine(emp.FirstName.IndexOf("o"));
            }

            Console.WriteLine();
            Console.WriteLine("Get length of FIRST_NAME from employee table");

            var emp10 = from emp in Employees select emp.FirstName;
            foreach(var emp in emp10)
            {
                Console.WriteLine(emp.Length);
            }

            Console.WriteLine();
            Console.WriteLine("Get First_Name from employee table after replacing 'o' with '$'");

            foreach (var emp in emp10)
            {
                Console.WriteLine(emp.Replace('o','$'));
            }

            Console.WriteLine();
            Console.WriteLine("Get all employee details from the employee table order by First_Name Ascending");

            var emp11 = from emp in Employees orderby emp.FirstName ascending select emp;

            foreach (var emp in emp11)
            {
                Console.WriteLine(emp.FirstName);
            }

            Console.WriteLine();
            Console.WriteLine("Get all employee details from the employee table order by First_Name descending");
            var emp12 = from emp in Employees orderby emp.FirstName descending select emp;

            foreach (var emp in emp12)
            {
                Console.WriteLine(emp.FirstName);
            }

            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose employee name is John");

            
            foreach(var emp in emp9)
            {
                Console.WriteLine(emp.FirstName,emp.LastName,emp.Salary);
            }


            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose employee name are John and Roy");
            var emp13 = from emp in Employees where emp.FirstName == "John" || emp.FirstName == "Roy" select emp;
            foreach (var emp in emp13)
            {
                Console.WriteLine("Fname:{0},Lame:{1},Date:{2}", emp.FirstName, emp.LastName, emp.JoiningDate);
            }


            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose first name starts with 'J'");

            var emp14 = from emp in Employees where emp.FirstName.StartsWith("J") select emp;
            foreach(var emp in emp14)
            {
                Console.WriteLine(emp.FirstName);
            }

            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose first name contains 'o'");

            var emp15 = from emp in Employees where emp.FirstName.Contains("o") select emp;
            foreach (var emp in emp15)
            {
                Console.WriteLine(emp.FirstName);
            }

            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose first name ends with 'n'");

            var emp16 = from emp in Employees where emp.FirstName.EndsWith("n") select emp;
            foreach (var emp in emp16)
            {
                Console.WriteLine(emp.FirstName);
            }


            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose Salary greater than 600000");

            var emp17 = from emp in Employees where emp.Salary > 600000 select emp;

            foreach (var emp in emp17)

            {
                Console.WriteLine(emp.FirstName,emp.Salary);
            }


            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose Salary less than 800000");


            var emp18 = from emp in Employees where emp.Salary < 800000 select emp;

            foreach (var emp in emp18)

            {
                Console.WriteLine(emp.FirstName, emp.Salary);
            }


            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose Salary between 500000 and 800000");

            var emp19 = from emp in Employees where emp.Salary > 500000 && emp.Salary < 800000 select emp;

            foreach (var emp in emp19)

            {
                Console.WriteLine(emp.FirstName, emp.Salary);
            }

            Console.WriteLine();
            Console.WriteLine("Get employee details from employee table whose name is 'John' and 'Michael'");

            var emp20 = from emp in Employees where emp.FirstName == "John" || emp.FirstName == "Michael" select emp;
            foreach (var emp in emp20)
            {
                Console.WriteLine("Fname:{0},Lame:{1},Date:{2}", emp.FirstName, emp.LastName, emp.JoiningDate);
            }
        }
    }
}
