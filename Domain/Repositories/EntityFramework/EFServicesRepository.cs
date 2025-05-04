using Company.Domain.Entities;
using Company.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Company.Domain.Repositories.EntityFramework
{
    public class EFServicesRepository : IServicesRepository
    {
        private readonly AppDbContext _context;
        public EFServicesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Services>> GetServicesAsync()
        {
            return await _context.Services.Include(x => x.ServiceCategory).ToListAsync();
        }

        public async Task<Services?> GetServicesByIdAsync(int id)
        {
            return await _context.Services.Include(x => x.ServiceCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServicesAsync(Services entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServicesAsync(int id)
        {
            _context.Entry(new Services() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
