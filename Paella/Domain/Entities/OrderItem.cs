namespace Paella.Domain.Entities
{
    public class OrderItem
    {
        public int Quantity { get; }

        public Product Product { get; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}