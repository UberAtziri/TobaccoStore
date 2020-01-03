using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TobaccoStore.Models
{
    public class OrderModel
    {
        [Required]
        public int Id { get; set; }
        public List<TobaccoModel> Purchases { get; set; }
        public User Customer{get; set;}
        

    }
}