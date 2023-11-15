using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Models
{
    public class Restaurant
    {
        [StringLength(240)]
        public string RestaurantName { get; set; }
        [Range(5, 200)]
        public int StaffDb { get; set; }
        [Required]
        public bool RestaurantOpen { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }
        public Restaurant(string v)
        {
            string[] strings = v.Split('#');
            RestaurantName = strings[0];
            StaffDb = int.Parse(strings[1]);
            RestaurantOpen = bool.Parse(strings[2]);
            RestaurantId = int.Parse(strings[3]);
            Courier = new HashSet<Courier>();
        }
        public Restaurant()
        {
            Courier = new HashSet<Courier>();
        }
        [NotMapped]
        public virtual ICollection<Courier> Courier { get; set; }

    }
}
