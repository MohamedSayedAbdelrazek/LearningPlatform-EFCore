using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session03.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string ?Bio { get; set; } 
        public DateTime JoinDate { get; set; }

        public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();
    }
}
