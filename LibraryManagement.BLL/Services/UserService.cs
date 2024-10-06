//namespace InventoryManagementSystem.BLL.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly UserManager<User> _userManager;

//        public UserService(UserManager<User> userManager)
//        {
//            _userManager = userManager;
//        }

//        public async Task<IdentityResult> RegisterCustomerAsync(User user, string password)
//        {
//            var result = await _userManager.CreateAsync(user, password);
//            return result;
//        }


//        public async Task<User> LoginCustomerAsync(string email, string password, bool rememberMe)
//        {
//            var result = await _userManager.FindByEmailAsync(email);
//            if (result != null && await _userManager.CheckPasswordAsync(result, password))
//            {
//                return result;
//            }

//            return null;
//        }




//    }
//}
