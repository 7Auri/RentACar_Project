using Castle.DynamicProxy;
using RentACar.Core.CrossCuttingConcerns.Caching;
using RentACar.Core.Utilities.Interceptors;
using RentACar.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace RentACar.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
