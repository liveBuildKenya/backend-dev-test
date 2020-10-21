using Jambopay.Core.Domain.Customers;

namespace Jambopay.Web.Framework.Authentication
{
    public interface IJsonWebTokenService
    {
        string GenerateJSONWebToken(Customer customer);
    }
}
