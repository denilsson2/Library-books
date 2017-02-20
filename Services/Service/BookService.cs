using Common.Model;
using Repository.EntityModel;
using Repository.Repository;
using System.Collections.Generic;

namespace Services.Service
{
    public class BookService
    {
        public static List<book> GetBooksByAuthor(int aid)
        {
            return BookRepository.GetBookListByAuthor(aid);
        }

        public static book GetBook(string isbn) {
            return BookRepository.GetBook(isbn);
        }

        public static BookWithAuthorsAndAuthors GetBookWithAuthorsAndAuthors(string isbn)
        {
            return MapBookWithAuthorsAndAuthors(BookRepository.GetBook(isbn));
        }

        public static BookWithAuthorsAndAuthors MapBookWithAuthorsAndAuthors(book b)
        {
            BookWithAuthorsAndAuthors baa = new BookWithAuthorsAndAuthors();
            baa.Book = b;
            baa.Authors = AuthorService.GetAuthors("FirstName");
            baa.BookAuthors = AuthorService.GetAuthersByBook(b.ISBN);

            return baa;
        }

        public static List<book> GetBooks()
        {
            return BookRepository.GetBooks();
        }
        public static List<book> GetBooksByLetter(string letter)
        {
            return BookRepository.GetBooksByLetter(letter);
        }
        public static List<book> GetBooksByNumber(List<string> number)
        {
            return BookRepository.GetBooksByNumber(number);
        }

        public static BookWithAuthors GetBookWithAuthors(string isbn)
        {
            return mapBookWithAuthors(BookRepository.GetBook(isbn));
        }

        private static BookWithAuthors mapBookWithAuthors(book b)
        {
            BookWithAuthors bookandauthers = new BookWithAuthors();
            bookandauthers.Book = b;
            bookandauthers.Authors = AuthorService.GetAuthersByBook(b.ISBN);
            return bookandauthers;
        }

        public static bool BookExists(string ISBN)
        {
            return (BookRepository.GetBook(ISBN) != null ? true : false);
        }

        public static BookWithClassifications NewBookWithClassifications()
        {
            return new BookWithClassifications()
                {
                    Book = new Repository.EntityModel.book(),
                    Classifications = ClassificationService.GetClassifications()
                };
        }        

        public static void UpdateBook(book b)
        {
            BookRepository.UpdateBook(b);
        }

        public static List<book> GetBooksBySearch(string input)
        {
            return BookRepository.GetBooksBySearch(input);
        }       

        public static bool StoreBook(book b, int copies, string library)
        {
            BookRepository.StoreBook(b);
            for (int i = 0; i < copies; i++)
                CopyService.CreateCopy(b.ISBN, library);

            return true;
        }

        public static bool RemoveBook(string isbn)
        {
            if (HasBorrows(isbn) || HasAuthors(isbn))
                return false;

            CopyService.RemoveCopyByISBN(isbn);
            BookAuthorService.RemoveBookAuthorByISBN(isbn);
            BookRepository.RemoveBook(isbn);

            return true;
        }

        public static bool HasBorrows(string isbn)
        {
            foreach (copy c in CopyRepository.GetCopiesByISBN(isbn))
                if (CopyService.IsBorrowed(c))
                    return false;
            return true;
        }

        public static bool HasAuthors(string isbn)
        {
            if (AuthorRepository.GetAuthorsByBookISBN(isbn).Count > 0)
                return true;

            return false;
        }
    }
}
