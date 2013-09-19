using System.Security.Principal;

namespace SampleWebApp.Common.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(IPrincipal principal)
        {
            IsAuthenticated = principal.Identity.IsAuthenticated;
        }

        public bool IsAuthenticated { get; private set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
    }
}
