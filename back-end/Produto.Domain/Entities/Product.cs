namespace Produto.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }

        public double Value { get; private set; }

        public string ImageURL { get; private set; }

        public Product(long id, string name, double value, string imageURL) : base(id)
        {
            Name = name;
            Value = value;
            ImageURL = imageURL;
        }

        public Product(string name, double value, string imageURL) : this(0, name, value, imageURL)
        { }

        protected Product()
        { }
    }
}
