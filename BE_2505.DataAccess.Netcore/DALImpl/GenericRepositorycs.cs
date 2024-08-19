using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class GenericRepositorycs<T> : IGenericRepository<T> where T : class
    {
        private BE_25_05DbContext _context;
        public GenericRepositorycs(BE_25_05DbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAll()
        {
            return _context.Set<T>().AsQueryable().ToList();
        }

        public async Task<int> InsertUpdate(T entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }
    }
}
