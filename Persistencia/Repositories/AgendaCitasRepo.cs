using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Repositories
{
    public class AgendaCitasRepo<T> : IAgendaRepo<T> where T : class
    {
        private readonly DbContext.AgendaCitasDbContext _context;
        private readonly DbSet<T> _dbSet;

        public AgendaCitasRepo(DbContext.AgendaCitasDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> Delete(T entity)
        {
            try { 
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try { 
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<T> GetById(int id)
        {
            try 
            { 
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();

        }
        public async Task<T> Update(T entity)
        {
            try 
            { 
              _context.Update(entity);
              await _context.SaveChangesAsync();
              return entity;

            } catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
