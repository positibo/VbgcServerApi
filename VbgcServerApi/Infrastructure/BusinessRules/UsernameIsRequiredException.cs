using System.Net;

namespace VbgcServerApi.Infrastructure.BusinessRules
{
    public class UsernameIsRequiredException : BusinessRulesException
    {
        private const string message = "Username is required";

        public UsernameIsRequiredException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
