using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using System.Security.Cryptography;
using System.Text;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public class UserManager 
    {

        private readonly IUserManagerDAL user;
        public UserManager() { }
        public UserManager(IUserManagerDAL user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
        }
        public bool AddCreateAccount(UserDTO userDTO)
        {
            return user.AddUserAccount(userDTO);
        }
        public User GetCurrentUserByUsername(string username)
        {
            return user.GetCurrentUserByUsername(username);
        }
        public List<UserDTO> GetAllAccounts()
        {
            return user.GetAllAccounts();
        }
       
        public User Login(string username, string password)
        {
            User currentUser = user.GetCurrentUserByUsername(username); // Call the method via IUser
            if(currentUser != null)
            {
                var userhashedpass = HashedPassword($"{password}{currentUser.Salt.Trim()}");

                if (username == currentUser.Username && userhashedpass == currentUser.PasswordHash)
                {
                    return currentUser;
                }
            }
            
            return null;
        }
        

        public static string HashedPassword(string password)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedPasswordBytes = hash.ComputeHash(passwordBytes);
                return Convert.ToHexString(hashedPasswordBytes);

            }
        }
        public bool IsLoginValid(string username, string password)
        {

            User Obj = user.GetCurrentUserByUsername(username);
            if (Obj != null)
            {

                var userhashedpass = HashedPassword($"{password}{Obj.Salt.Trim()}");
                Console.WriteLine(Obj.Salt);
                if (userhashedpass == Obj.PasswordHash && Obj.RoleID == 1)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool IsLoginValidVisitorCase(string username, string password)
        {

            User Obj = user.GetCurrentUserByUsername(username);
            if (Obj != null)
            {
                if (Obj.UserID != 0 )
                {
                    var userhashedpass = HashedPassword($"{password}{Obj.Salt.Trim()}");
                    Console.WriteLine(Obj.Salt);
                    if (userhashedpass == Obj.PasswordHash && Obj.RoleID == 2)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

        

        
    }
}
