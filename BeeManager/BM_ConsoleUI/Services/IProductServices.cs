namespace BM_ConsoleUI.Services
{
    public interface IProductServices
    {
        string GetProductNameById(int id);
        void GetProducts();
    }
}