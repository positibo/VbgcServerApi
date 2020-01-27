using Microsoft.AspNetCore.Builder;

namespace VbgcServerApi.Infrastructure.Helpers
{
	public static class SwaggerUIBuilderExtensions
	{
		public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
		{
			return app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "VbgcServer API V1");
				c.RoutePrefix = string.Empty;
				c.InjectStylesheet("/swagger-ui/custom.css");
			});
		}
	}
}
