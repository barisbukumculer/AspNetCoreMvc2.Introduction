using AspNetCoreMvc2.Introduction.Entities;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction
{
    public class EmployeeListViewModel
    {
        public List<Employee> Emloyees { get; set; }
        public List<string> cities { get; set; }
    }
}