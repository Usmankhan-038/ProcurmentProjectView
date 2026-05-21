namespace ProcurmentProjectView.Config
{
    public class ApiEndPoints
    {
        public static string Login() => "/api/User/Login";
        public static string ProductList() => "/api/Product/get-product";
        public static string PrDetail() => "/api/PurchasedRequisition/get-pr-detail";
    }
}
