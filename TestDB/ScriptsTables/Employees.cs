using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.ScriptsTables
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public int JobId { get; set; }
        public int? ManagerId { get; set; }
        public int? DepartmentId { get; set; }

        public Employees() { }

        public Employees(string firstName, string lastName, string email,
                         string phoneNumber, DateTime hireDate, double salary,
                         int jobId, int? managerId, int? departmentId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            HireDate = hireDate;
            Salary = salary;
            JobId = jobId;
            ManagerId = managerId;
            DepartmentId = departmentId;
        }

        public Employees(int employeeId, string firstName, string lastName, string email,
                         string phoneNumber, DateTime hireDate, double salary,
                         int jobId, int? managerId, int? departmentId)
            : this(firstName, lastName, email, phoneNumber, hireDate, salary, jobId, managerId, departmentId)
        {
            EmployeeId = employeeId;
        }
    }
}
