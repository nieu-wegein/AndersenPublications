using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Exceptions
{
	public class EmailExistsException : StatusException
	{
		public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
		public override string DefinedMessage => "A user with that email address already exists";
	}
}
