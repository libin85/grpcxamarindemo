using EmployeeDirectoryServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryServer.Services
{
    public class EmployeeService : EmployeeRequests.EmployeeRequestsBase

    {
        public override Task<EmployeeListResponse> GetEmployees(Empty request, ServerCallContext context)
        {
            var employeeList = new List<Employee>{
                new Employee
                {
                    EmployeeId = 1,
                    FullName = "Bill Gates",
                    EmployeeTitle = "Founder",
                    ProfilePictureUrl = ""
                }, new Employee
                {
                    EmployeeId = 2,
                    FullName = "Satya Nadella",
                    EmployeeTitle = "CEO",
                    ProfilePictureUrl = ""
                }, new Employee
                {
                    EmployeeId = 3,
                    FullName = "Miguel de Icaza",
                    EmployeeTitle = "Distingushed Developer",
                    ProfilePictureUrl = ""
                },new Employee
                {
                    EmployeeId = 4,
                    FullName = "Scott Hanselman",
                    EmployeeTitle = "Program Manager",
                    ProfilePictureUrl = ""
                }};
            var response = new EmployeeListResponse();
            response.Employee.AddRange(employeeList);
            return Task.FromResult(response) ;
        }
    }
}
