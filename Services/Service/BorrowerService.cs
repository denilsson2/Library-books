using Common.Model;
using Repository.EntityModel;
using Repository.Repository;
using System.Collections.Generic;

namespace Services.Service
{
    public class BorrowerService
    {
        public static bool BorrowerExists(string PersonId) {
            return (BorrowerRepository.GetBorrower(PersonId) == null ? false : true);
        }

        public static List<borrower> GetBorrowers() {
            return BorrowerRepository.GetBorrowers();
        }

        public static borrower GetBorrower(string PersonId)
        {
            return BorrowerRepository.GetBorrower(PersonId);
        }

        public static BorrowerWithBorrows GetBorrowerWithBorrows(string PersonId)
        {
            return mapBorrowerWithBorrows(BorrowerRepository.GetBorrower(PersonId));
        }

        public static BorrowerWithUser GetBorrowerWithUserByEmail(string Email)
        {
            BorrowerWithUser activeUser = new BorrowerWithUser();
            activeUser.User = AuthService.GetUser(Email);
            activeUser.Borrower = BorrowerRepository.GetBorrower(activeUser.User.PersonId);
           
            return activeUser;
        }
        
        public static BorrowerWithUser GetBorrowerWithUserByPersonId(string PersonId)
        {
            BorrowerWithUser activeUser = new BorrowerWithUser();
            activeUser.User = AuthService.GetUserByPersonId(PersonId);
            activeUser.Borrower = BorrowerRepository.GetBorrower(activeUser.User.PersonId);

            return activeUser;
        }

        private static BorrowerWithBorrows mapBorrowerWithBorrows(borrower b)
        {
            BorrowerWithBorrows borrowerwithborrows = new BorrowerWithBorrows();
            borrowerwithborrows.BorrowerWithUser = new BorrowerWithUser();
            
            borrowerwithborrows.BorrowerWithUser.Borrower = b;
            borrowerwithborrows.Borrows = new ActiveAndHistoryBorrows();
            borrowerwithborrows.Borrows.Active = BorrowService.GetActiveBorrowedBooks(b.PersonId);
            borrowerwithborrows.Borrows.History = BorrowService.GetHistoryBorrowedBooks(b.PersonId);
            borrowerwithborrows.Categories = CategoryService.GetCategories();
            borrowerwithborrows.BorrowerWithUser.User = UserRepository.GetUserByPersonId(b.PersonId);

            if (borrowerwithborrows.BorrowerWithUser.User == null)
                borrowerwithborrows.BorrowerWithUser.User = new user();

            borrowerwithborrows.Roles = RoleRepository.GetRoles();
            return borrowerwithborrows;
        }
        
        public static bool RemoveBorrower(borrower b) {

            if (HasActiveBorrows(b.PersonId))
                return false;

            BorrowRepository.RemoveBorrowsByPersonId(b.PersonId);
            UserRepository.RemoveUser(b.PersonId);
            BorrowerRepository.RemoveBorrower(b);

            return true;
        }

        public static bool HasActiveBorrows(string PersonId)
        {
            if (BorrowRepository.GetActiveBorrowListByPersonId(PersonId).Count > 0)
                return true;

            return false;
        }

        public static void UpdateBorrower(borrower b)
        {
            BorrowerRepository.UpdateBorrower(b);
        }

        public static void StoreBorrower(borrower b){
            BorrowerRepository.StoreBorrower(b);
        }

        public static List<borrower> GetBorrowersByLetter(string letter)
        {
            return BorrowerRepository.GetBorrowersByLetter(letter);
        }
    }
}
