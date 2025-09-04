using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Persistencia.Repositories
{
    public class AgendaCitasRepo<T> : IAgendaRepo<T> where T : class
    {
        private readonly DbContext.AgendaCitasDbContext _context;
        private readonly DbSet<T> _dbSet;
        private ILogs _Logger;

        public AgendaCitasRepo(DbContext.AgendaCitasDbContext context, ILogs logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _Logger = logger;
        }
        public async Task<T> Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                
                return entity;
                
            }
            catch (DbUpdateException ex)
            {
                throw new Shared.RepositoryExeption($"Error al agrega a la base de datos", ex) ;
            }
        }
        public async Task<bool> Delete(T entity)
        {
            try { 
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
               
                return true;
            }
            catch (SqlException ex)
            {
                _Logger.logError($"Error al eliminar de la base de datos: {ex.Message}");
                throw new Shared.RepositoryExeption($"Error al eliminar de la base de datos", ex);
                
            }

        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try { 

               
                return await _dbSet.ToListAsync();

            }
            catch (DbUpdateException ex)
            {
               throw new Shared.RepositoryExeption("Error al obtener todas las entidades", ex);
               _Logger.logError($"Error al obtener todas las entidades: {ex.Message}");
            }

        }
        public async Task<T> GetById(int id)
        {
            try 
            {
                return await _dbSet.FindAsync(id); 
            }
            catch (SqlException ex)
            {
              _Logger.logError($"Error al obtener la entidad por ID: {ex.Message}");
                throw new Shared.RepositoryExeption($"Error al obtener la entidad por ID", ex);
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

            } catch (DbUpdateException ex)
            {
                _Logger.logError($"Error al actualizar la entidad: {ex.Message}");
                throw new Shared.RepositoryExeption($"Error al aplicar cambios en la base de datos", ex);
                
            }
        }
    }
}
