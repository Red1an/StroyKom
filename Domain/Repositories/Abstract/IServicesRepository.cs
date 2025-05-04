using Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Repositories.Abstract
{
    public interface IServicesRepository
    {
        Task<IEnumerable<Services>> GetServicesAsync();
        Task<Services?> GetServicesByIdAsync(int id);
        Task SaveServicesAsync(Services entity);
        Task DeleteServicesAsync(int id);
    }
}
