using System.Net;

namespace VbgcServerApi.Infrastructure.BusinessRules
{
	public class NotFoundException : BusinessRulesException
	{
		private const string message = "Record not found";

		public NotFoundException() : base(HttpStatusCode.NotFound, message) { }
	}
}
