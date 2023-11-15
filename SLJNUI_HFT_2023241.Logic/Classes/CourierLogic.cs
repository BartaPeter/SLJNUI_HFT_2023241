using SLJNUI_HFT_2023241.Models;
using SLJNUI_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Logic
{
    public class CourierLogic : ICourierLogic
    {
        IRepository<Courier> repository;

        public CourierLogic(IRepository<Courier> repository)
        {
            this.repository = repository;
        }

        public void Create(Courier item)
        {
            if(item.CourierAge >= 18 && item.CourierAge <= 65)
            {
                this.repository.Create(item);
            }
            else
            {
                throw new ArgumentException("Codded age is not suitable for the courier job.");
            }
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Courier Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Courier> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Courier item)
        {
            this.repository.Update(item);
        }
    }
}
