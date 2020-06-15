using Newtonsoft.Json;

namespace Shp.Core.Entities.Concrete
{
    public class UserOperationClaims : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        [JsonIgnore] public virtual User User { get; set; }
        [JsonIgnore] public virtual OperationClaims OperationClaim { get; set; }
    }
}
