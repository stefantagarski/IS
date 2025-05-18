namespace AdminApplication.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<ProductInOrder>? ProductsInOrders { get; set; }

    }
}