using System;
using System.Collections.Generic;
using Common.Model;
using Repository.Repository;
using Repository.EntityModel;

namespace Services.Service
{
    public class BorrowService
    {
        public static List<BorrowedBookCopy> GetActiveBorrowedBooks(string PersonId) {
            return MapBorrow(BorrowRepository.GetActiveBorrowListByPersonId(PersonId));    
        }
        
        public static List<BorrowedBookCopy> GetHistoryBorrowedBooks(string PersonId) {
            return MapBorrow(BorrowRepository.GetHistoryBorrowListByPersonId(PersonId));
        }
        
        public static List<BorrowedBookCopy> MapBorrow(List<borrow> b) {
            List<BorrowedBookCopy> borrowedBookCopy = new List<BorrowedBookCopy>();
            foreach (borrow borrow in b)
            {
                copy c = CopyRepository.GetCopyByBarcode(borrow.Barcode);
                borrowedBookCopy.Add(new BorrowedBookCopy() { 
                    Borrow = borrow,
                    Authors = AuthorRepository.GetAuthorsByBookISBN(c.ISBN),
                    Book = BookRepository.GetBook(c.ISBN),
                    Category = CategoryRepository.GetCategoryById(BorrowerRepository.GetBorrower(borrow.PersonId).CategoryId),
                    Fine = FineRepository.GetFine(borrow.Barcode, borrow.PersonId)
                });
            }
            return borrowedBookCopy;
        }

        public static void RenewLoad(borrower br, string barcode)
        {
            DateTime ToBeReturnedDate = DateTime.Today.AddDays(CategoryRepository.GetCategoryById(br.CategoryId).Period);
            BorrowRepository.UpdateBorrowDates(br.PersonId, barcode, ToBeReturnedDate);
        }

        public static void RenewAllLoans(borrower br, List<BorrowedBookCopy> borrowes)
        {
            DateTime ToBeReturnedDate = DateTime.Today.AddDays(CategoryRepository.GetCategoryById(br.CategoryId).Period);
            foreach (BorrowedBookCopy b in borrowes)
                BorrowRepository.UpdateBorrowDates(br.PersonId, b.Borrow.Barcode, ToBeReturnedDate);
        }
    }
}
