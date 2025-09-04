using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Repositories
{
    public class AgendaCitasRepo<T> : IAgendaRepo<T> where T : class
    {
        private readonly DbContext.AgendaCitasDbContext _context;
        private readonly DbSet<T> _dbSet;
        private ILogs<AgendaCitasRepo<T>> Logger_;

        public AgendaCitasRepo(DbContext.AgendaCitasDbContext context, ILogs<AgendaCitasRepo<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            Logger_ = logger;
        }
        public async Task<T> Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                Logger_.logInfo($"{entity.GetType} añadido correctamente", DateTime.Now);
                return entity;
                
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
        }
        public async Task<bool> Delete(T entity)
        {
            try { 
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                Logger_.logInfo($"{entity.GetType} eliminado correctamente", DateTime.Now);
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

                Logger_.logInfo($"Obteniendo todos los registros de {typeof(T)}", DateTime.Now);
                return await _dbSet.ToListAsync();

            }
            catch (DbUpdateException ex)
            {
                return null;
            }

        }
        public async Task<T> GetById(int id)
        {
            try 
            { 
                Logger_.logInfo($"Obteniendo {typeof(T)} con ID: {id}", DateTime.Now);
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task SaveAsync()
        {
            Logger_.logInfo($"Guardando cambios en la base de datos para {typeof(T)}", DateTime.Now);       
            await _context.SaveChangesAsync();

        }
        public async Task<T> Update(T entity)
        {
            try 
            { 
              _context.Update(entity);
              await _context.SaveChangesAsync();
                Logger_.logInfo($"{entity.GetType} actualizado correctamente", DateTime.Now);
                return entity;

            } catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
