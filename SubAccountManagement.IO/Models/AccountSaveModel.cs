using SubAccountManagement.IO.Interfaces;

namespace SubAccountManagement.IO.Models
{
    public class AccountSaveModel : IAccountSaveModel
    {
        public string? Email { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}