using Repository.EntityModel;
using Repository.Repository;

namespace Services.Service
{
    public class BookAuthorService
    {
        public static void StoreBookAuthor(bookAuthor ba)
        {
            BookAuthorRepository.StoreBookAuthor(ba);
        }

        public static bool BookAuthorExists(int Aid, string ISBN)
        {
            return (BookAuthorRepository.GetBookAuthor(Aid, ISBN) != null ? true : false);
        }

        public static void RemoveBookAuthorByISBN(string ISBN)
        {
            BookAuthorRepository.RemoveBookAuthorByISBN(ISBN);
        }

        public static void RemoveBookAuthor(int Aid, string ISBN)
        {
            BookAuthorRepository.RemoveBookAuthor(Aid, ISBN);
        }
    }
}
