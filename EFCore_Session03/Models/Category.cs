using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session03.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        //Course relationship
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        //Recursive relationship
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> Childs { get; set; } = new HashSet<Category>();
    }
}
