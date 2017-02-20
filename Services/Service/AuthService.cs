using Repository.EntityModel;
using Repository.Repository;


namespace Services.Service
{
    public class AuthService
    {
        public static bool Login(string email, string password)
        {
            if (UserRepository.UserExists(email))
                if (PasswordService.VerifyPassword(password, UserRepository.GetPassword(email)))
                    return true;

            return false;
        }
        
        public static user GetUser(string email)
        {
            return UserRepository.GetUserByEmail(email);
        }

        public static user GetUserByPersonId(string PersonId)
        {
            return UserRepository.GetUserByPersonId(PersonId);
        }

        public static role GetRole(string email)
        {
            return RoleRepository.GetRoleByUserEmail(email);
        }

        public static void CreateUser(user u) {
            u.Password = PasswordService.CreateHash(u.Password);
            UserRepository.CreateUser(u);
        }
    }
}
