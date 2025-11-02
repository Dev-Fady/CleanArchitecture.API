using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IGenericRepo<TModels> where TModels : class
    {
        IQueryable<TModels> GetAll();
        Task<TModels> GetByIdAsync(int id);
        Task<bool> AddAsync(TModels entity);
        Task<bool> UpdateAsync(TModels entity);
        Task<bool> ArchivedAsync(TModels entity);
        Task<bool> UnArchivedAsync(TModels entity);
    }
}
