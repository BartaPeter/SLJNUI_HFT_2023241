using SLJNUI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRepository<Restaurant>
    {
        public RestaurantRepository(RestaurantDbContext ctx) : base(ctx)
        {
        }

        public override Restaurant Read(int id)
        {
            return ctx.Restaurants.FirstOrDefault(t => t.RestaurantId== id);
        }

        public override void Update(Restaurant item)
        {
            var old = Read(item.RestaurantId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();

        }
    }
}
