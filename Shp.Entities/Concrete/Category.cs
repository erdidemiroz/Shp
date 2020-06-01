using System.Collections.Generic;
using Shp.Core.Entities;

namespace Shp.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
