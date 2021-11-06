
namespace BeeManagerLibrary.Models
{
    class TransactionObject : BaseEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

    }
}
