using Microsoft.AspNetCore.Mvc;
using Pub.Application.Exceptions;
using System.Dynamic;
using System.Net;
using System.Text.Json;

namespace Pub.Api.Middleware
{
	public class ErrorHandlingMiddleware
	{

		private readonly RequestDelegate _next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception e)
			{
				int code;
				string message;

				switch (e)
				{
					case StatusException ex: code = (int)ex.StatusCode; message = ex.DefinedMessage; break;
					default: code = (int)HttpStatusCode.InternalServerError; message = "Internal server error"; break;
				}

				var problem = new ProblemDetails
				{
					Status = code,
					Title = message,
				};

				var response = JsonSerializer.Serialize(problem);
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(response);
			}
		}
	}
}
