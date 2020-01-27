using System.Net;

namespace VbgcServerApi.Infrastructure.BusinessRules
{
    public class UsernamePasswordIncorrectException : BusinessRulesException
    {
        private const string message = "Username or password is incorrect";

        public UsernamePasswordIncorrectException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
