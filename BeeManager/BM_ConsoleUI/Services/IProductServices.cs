namespace BM_ConsoleUI.Services
{
    public interface IProductServices
    {
        int GetProductIdByName(string name);
        string GetProductNameById(int id);
    }
}