using Company.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain
{
    public class DataManager
    {
        public IServiceCategoriesRepository ServiceCategories {  get; set; }
        public IServicesRepository Services { get; set; }

        public DataManager(IServiceCategoriesRepository serviceCategoriesRepository, IServicesRepository servicesRepository) { 
            ServiceCategories = serviceCategoriesRepository;
            Services = servicesRepository;
        }
    }
}
