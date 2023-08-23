using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Exceptions
{
	public class IncorrectPasswordException : StatusException
	{
		public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
		public override string DefinedMessage => "Incorrect password";
	}
}
