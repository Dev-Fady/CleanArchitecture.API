using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class GenericRepo<TModels> : IGenericRepo<TModels> where TModels : NamedEntity
    {
        private readonly AppDbContext _context;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<TModels> GetAll()
        {
            //return _context.Set<TModels>().AsNoTracking().AsQueryable();
            return _context.Set<TModels>().AsQueryable();
        }

        public async Task<TModels?> GetByIdAsync(int id)
        {
            return await _context.Set<TModels>().SingleOrDefaultAsync(x => x.Id==id);
        }
        public async Task<bool> AddAsync(TModels entity)
        {
            _context.Set<TModels>().Add(entity);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> ArchivedAsync(TModels entity)
        {
            _context.Set<TModels>().Remove(entity);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UnArchivedAsync(TModels entity)
        {
            entity.ArchivedByID = null;
            entity.ArchivedDateTime = DateTime.Now;
            entity.ArchivedByName = null;
            entity.IsArchived = false;
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateAsync(TModels entity)
        {
            _context.Set<TModels>().Update(entity);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
