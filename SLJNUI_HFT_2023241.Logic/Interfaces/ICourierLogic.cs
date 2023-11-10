using SLJNUI_HFT_2023241.Models;
using System.Linq;

namespace SLJNUI_HFT_2023241.Logic
{
    public interface ICourierLogic
    {
        void Create(Courier item);
        void Delete(int id);
        Courier Read(int id);
        IQueryable<Courier> ReadAll();
        void Update(Courier item);
    }
}