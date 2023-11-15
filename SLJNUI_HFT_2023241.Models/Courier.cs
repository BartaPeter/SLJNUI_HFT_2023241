using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Models
{
    public class Courier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourierId { get; set; }
        [Required]
        [StringLength(240)]
        public string CourierName {  get; set; }
        [Range(18, 65)]
        public int CourierAge { get; set; }
        public int RestaurantId { get; set; }
        public int FoodId { get; set; }

        public Courier(string v)
        {
            string[] strings = v.Split('#');
            CourierId = int.Parse(strings[0]);
            CourierName = strings[1];
            CourierAge = int.Parse(strings[2]);
            RestaurantId= int.Parse(strings[3]);
            FoodId= int.Parse(strings[4]);
        }
        public Courier()
        {
        }
        public virtual Restaurant restaurants { get; set; }
        public virtual Food foods { get; set; }
    }
}
