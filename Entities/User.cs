using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TobaccoStore.Entities
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        User
    }
}
