using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.Json.Serialization;

namespace SLJNUI_HFT_2023241.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        [Required]
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        [Range(1000, 50000)]
        public int FoodPrice { get; set; }

        public Food(string v)
        {
            string[] strings = v.Split('#');
            FoodId = int.Parse(strings[0]);
            FoodName = strings[1];
            FoodType = strings[2];
            FoodPrice = int.Parse(strings[3]);
            Courier = new HashSet<Courier>();
        }
        public Food()
        {
            Courier = new HashSet<Courier>();
        }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Courier> Courier { get; set; }
    }
}
