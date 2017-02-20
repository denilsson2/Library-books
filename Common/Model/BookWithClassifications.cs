using System.Collections.Generic;

namespace Common.Model
{
    /// <summary>
    /// Used when creating a new book with classification
    /// </summary>
    public class BookWithClassifications
    {
        public Repository.EntityModel.book Book {get; set;}
        public List<Repository.EntityModel.classification> Classifications { get; set; }
    }
}
