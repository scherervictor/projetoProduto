using System;

namespace Produto.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }

        public decimal Value { get; private set; }

        public string ImageURL { get; private set; }

        public Product(long id, string name, decimal value, string imageURL) : base(id)
        {
            Name = name;
            Value = value;
            ImageURL = imageURL;
        }

        public Product(string name, decimal value, string imageURL) : this(0, name, value, imageURL)
        { }

        protected Product()
        { }

        public void Update(Product newProduct)
        {
            Name = newProduct.Name;
            Value = newProduct.Value;
            ImageURL = newProduct.ImageURL;
        }
    }
}
