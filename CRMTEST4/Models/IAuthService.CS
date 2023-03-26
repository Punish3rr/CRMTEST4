//namespace CRMTEST4.Models
//{
//    public interface IAuthService
//    {
//        bool IsAuthenticated { get; set; }
//    }

//    public class AuthService : IAuthService
//    {
//        public bool IsAuthenticated { get; set; }
//    }
//}



//namespace CRMTEST4.Models
//{
//    public interface IAuthService
//    {
//        bool IsAuthenticated { get; set; }
//        Task<bool> AuthenticatedAsync();
//    }

//    public class AuthService : IAuthService
//    {


//        public bool IsAuthenticated { get; set; }

//        public Task<bool> AuthenticatedAsync()
//        {
//            return Task.FromResult(IsAuthenticated);
//        }
//    }
//}


namespace CRMTEST4.Models
{
    public interface IAuthService
    {
        bool IsAuthenticated { get; set; }
        Task<bool> AuthenticatedAsync();
    }

    public class AuthService : IAuthService
    {
        private bool isAuthenticatedSet = false;
        private bool isAuthenticated = false;
        private string isAuthenticatedStr = null;

        public bool IsAuthenticated
        {
            get
            {
                if (isAuthenticatedSet)
                {
                    return isAuthenticated;
                }
                else if (isAuthenticatedStr != null)
                {
                    isAuthenticated = bool.Parse(isAuthenticatedStr);
                    isAuthenticatedSet = true;
                    return isAuthenticated;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                isAuthenticated = value;
                isAuthenticatedStr = value.ToString();
                isAuthenticatedSet = true;
            }
        }

        public Task<bool> AuthenticatedAsync()
        {
            return Task.FromResult(IsAuthenticated);
        }
    }
}




