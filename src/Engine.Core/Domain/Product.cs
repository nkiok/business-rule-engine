using System;

namespace Engine.Core.Domain
{
    public class Product
    {
        public Guid Id { get; }

        public bool Physical { get; }

        public ProductType Type { get; }

        public string Description { get; }

        public Product(Guid id, bool physical, ProductType type, string description)
        {
            Id = id;

            Physical = physical;

            Type = type;

            Description = description;
        }
    }
}