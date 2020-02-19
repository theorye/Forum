using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.DataLayer.Interfaces
{
    interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int? id);
        void InsertNew(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
