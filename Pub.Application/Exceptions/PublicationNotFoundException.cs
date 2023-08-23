using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Exceptions
{
	public class PublicationNotFoundException : StatusException
	{
		public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
		public override string DefinedMessage => "Publication does not exist";
	}
}
