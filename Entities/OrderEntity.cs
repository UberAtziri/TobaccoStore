using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.OData.Builder;
using TobaccoStore.Data;

namespace TobaccoStore.Entities
{
    public class OrderEntity : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int? TobaccoId { get; set; }
        [ForeignKey("TobaccoId")]
        [AutoExpand]
        public List<TobaccoEntity> Purchases { get; set; } = new List<TobaccoEntity>();
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        [AutoExpand]
        public UserEntity Customer{get; set;}

        public void AddItem(TobaccoEntity item)
        {
            Purchases.Add(item);
        }
        

    }
}