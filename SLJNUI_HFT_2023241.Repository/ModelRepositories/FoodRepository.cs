using SLJNUI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Repository
{
    public class FoodRepository : Repository<Food>, IRepository<Food>
    {
        public FoodRepository(RestaurantDbContext ctx) : base(ctx)
        {

        }

        public override Food Read(int id)
        {
            return ctx.Foods.FirstOrDefault(t => t.FoodId == id);
        }

        public override void Update(Food item)
        {
            var old = Read(item.FoodId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
