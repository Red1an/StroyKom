using Company.Domain.Entities;
using Company.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Repositories.EntityFramework
{
    public class EFServiceCategoriesRepository //: IServiceCategoriesRepository
    {
        private readonly AppDbContext _context;
        public EFServiceCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync()
        {
            return await _context.ServiceCategories.Include(x => x.Services).ToListAsync();
        }

        public async Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id)
        {
            return await _context.ServiceCategories.Include(x => x.Services).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServiceCategoryAcinc(ServiceCategory entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added: EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceCategoryAsync(int id)
        {
            _context.Entry(new ServiceCategory() { Id = id}).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
