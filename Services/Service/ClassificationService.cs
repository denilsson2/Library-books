using System.Collections.Generic;
using Repository.EntityModel;
using Repository.Repository;

namespace Services.Service
{
    public class ClassificationService
    {
        public static List<classification> GetClassifications()
        {
            return ClassificationRepository.GetClassifications();
        }
    }
}
