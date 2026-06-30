namespace ProcurmentProjectView.Config
{
    public class ApiEndPoints
    {
        public static string Login() => "/api/User/Login";
        public static string ProductList() => "/api/Product/get-product";
        public static string AddProduct() => "/api/Product/add-Product";
        public static string GetProductById(int id) => $"/api/Product/get-product-by-Id?Id={id}";
        public static string UpdateProductById(int id) => $"/api/Product/update-product?prodId={id}";
        public static string deleteProduct() => "/api/Product/delete-product";
        public static string PrDetail() => "/api/PurchasedRequisition/get-pr-detail";
        public static string GetAllPrRequest() => "/api/PurchasedRequisition/get-all-pr-request";
        public static string AddPurchasedRequisition() => "/api/PurchasedRequisition";
        public static string UpdatePurchasedRequisition(int id) => $"/api/PurchasedRequisition/update-pr?prId={id}";
        public static string GetAllPurchasedRequisition() => "/api/PurchasedRequisition/get-all-pr-request";
        public static string GetPurchasedRequisitionById(int id) => $"/api/PurchasedRequisition/get-pr-request-byId?prId={id}";
        public static string DeletePurchasedRequisition(int id) => $"/api/PurchasedRequisition/delete-pr-request?prId={id}";


    }
}
