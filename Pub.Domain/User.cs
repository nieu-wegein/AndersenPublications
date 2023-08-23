using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Domain
{
	public class User
	{
		public Guid Id { get; set; }

		[Required]
		[MinLength(2)]
		public string FirstName { get; set; } 

		[Required]
		[MinLength(2)]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(8)]
		public string Password { get; set; }


		public List<Publication>? Publications { get; set; }

	}
}
