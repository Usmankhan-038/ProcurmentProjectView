namespace ProcurmentProjectView.Config
{
    public class ApiEndPoints
    {
        public static string Login() => "/api/User/Login";
        public static string ProductList() => "/api/Product/get-product";
        public static string AddProduct() => "/api/Product/add-Product";
        public static string GetProductById(int id) => $"/api/Product/get-product-by-Id?Id={id}";
        public static string deleteProduct() => "/api/Product/delete-product";
        public static string PrDetail() => "/api/PurchasedRequisition/get-pr-detail";
    }
}
