using Newtonsoft.Json;

namespace Shp.Core.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
