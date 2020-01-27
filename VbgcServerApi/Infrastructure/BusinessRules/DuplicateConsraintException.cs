using System.Net;

namespace VbgcServerApi.Infrastructure.BusinessRules
{
    public class DuplicateConsraintException : BusinessRulesException
    {
        private const string message = "Duplicate constraint";

        public DuplicateConsraintException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
