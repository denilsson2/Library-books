using Common.Model;
using Repository.EntityModel;
using Repository.Repository;

namespace Services.Service
{
    public class UserService
    {
        public static ActiveAndHistoryBorrows GetActiveAndHistoryBorrows(string PersonId) 
        {
            return new ActiveAndHistoryBorrows()
            {
                Active = BorrowService.GetActiveBorrowedBooks(PersonId),
                History = BorrowService.GetHistoryBorrowedBooks(PersonId)
            };
        }
              
        
        public static void Update(BorrowerWithUser user, string password)
        {
            if (password != null)
                user.User.Password = PasswordService.CreateHash(password);
            else
                user.User.Password = AuthService.GetUserByPersonId(user.User.PersonId).Password;

            UserRepository.UpdateUser(user.User.PersonId, user.User);
            BorrowerService.UpdateBorrower(user.Borrower);
        }
        
        public static bool EmailExists(string inputEmail)
        {
            if (Repository.Repository.UserRepository.UserExists(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool HasUserPermissions(int roleId)
        {
            if (roleId >= 1)
                return true;

            return false;
        }

        public static bool HasAdminPermissions(int roleId)
        {
            if (roleId == 2)
                return true;

            return false;
        }

        public static bool BorrowerIsUser(BorrowerWithUser b, string personId)
        {
            if (b.User.PersonId == personId)
                return true;

            return false;
        }
        
    }
}
