using Castle.DynamicProxy;
using RentACar.Core.Extensions;
using RentACar.Core.Utilities.Interceptors;
using RentACar.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Business.Constants;

namespace RentACar.Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
