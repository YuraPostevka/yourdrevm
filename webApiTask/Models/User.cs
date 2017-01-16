using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }

        public List<ToDoList> ToDoLists { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
