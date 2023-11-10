using SLJNUI_HFT_2023241.Models;
using System.Linq;

namespace SLJNUI_HFT_2023241.Logic
{
    public interface IFoodLogic
    {
        void Create(Food item);
        void Delete(int id);
        Food Read(int id);
        IQueryable<Food> ReadAll();
        void Update(Food item);
    }
}