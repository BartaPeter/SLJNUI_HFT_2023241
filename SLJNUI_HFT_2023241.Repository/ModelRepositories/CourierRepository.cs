using SLJNUI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Repository
{
    public class CourierRepository : Repository<Courier>, IRepository<Courier>
    {
        public CourierRepository(RestaurantDbContext ctx) : base(ctx)
        {
        }

        public override Courier Read(int id)
        {
            return ctx.Couriers.FirstOrDefault(t => t.CourierId == id);
        }

        public override void Update(Courier item)
        {
            var old = Read(item.CourierId);
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
