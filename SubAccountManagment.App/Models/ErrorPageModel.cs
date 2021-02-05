namespace SubAccountManagement.App.Models
{
    public class ErrorPageModel
    {
        public ErrorPageModel(object errorPage)
        {
            ErrorPage = errorPage;
        }

        public object ErrorPage { get; set; }
    }
}