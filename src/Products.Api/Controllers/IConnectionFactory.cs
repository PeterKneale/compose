using System.Data;

namespace Products.Api.Controllers
{
    public interface IConnectionFactory
    {
        IDbConnection Get();
    }
}