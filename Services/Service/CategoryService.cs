using Repository.EntityModel;
using Repository.Repository;
using System.Collections.Generic;

namespace Services.Service
{
    public class CategoryService
    {
        public static List<category> GetCategories() {
            return CategoryRepository.GetCategories();
        }
    }
}
