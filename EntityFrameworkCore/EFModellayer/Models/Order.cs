namespace EFModellayer.Models
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime  OrderPlaced { get; set; }
        public DateTime? OrderFullfilld { get; set; }

        public int CustomerId { get; set; }

        public ICollection<OrderDeatil> OrderDeatils { get; set; }
    }
}
