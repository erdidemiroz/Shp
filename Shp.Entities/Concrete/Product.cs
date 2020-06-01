using Newtonsoft.Json;
using Shp.Core.Entities;

namespace Shp.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }

        [JsonIgnore] public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
