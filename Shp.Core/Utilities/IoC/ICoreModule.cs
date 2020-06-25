using Microsoft.Extensions.DependencyInjection;

namespace Shp.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
