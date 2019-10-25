using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectory.Models
{
    public class EmployeeResult
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeePosition { get; set; }
        public string ProfilePicture { get; set; }

    }
}
