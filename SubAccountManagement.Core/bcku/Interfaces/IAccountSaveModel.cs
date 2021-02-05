namespace SubAccountManagement.IO.Interfaces
{
    public interface IAccountSaveModel
    {
        string? Email { get; set; }
        string PublicKey { get; set; }
        string PrivateKey { get; set; }
    }
}