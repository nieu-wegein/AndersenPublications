using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Exceptions
{
	public abstract class StatusException : Exception
	{
		public abstract HttpStatusCode StatusCode { get; }
		public abstract string DefinedMessage { get; }
	}
}
