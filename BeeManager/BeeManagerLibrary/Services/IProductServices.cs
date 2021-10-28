namespace BeeManagerLibrary.Services
{
    public interface IProductServices
    {
        int GetProductIdByName(string name);
        string GetProductNameById(int id);
    }
}