using System.ComponentModel.DataAnnotations;

namespace Pub.Domain
{
	public class Author
	{
		public Guid Id { get; set; }

		[Required]
		[MinLength(2)]
		public string FirstName { get; set; }

		[Required]
		[MinLength(2)]
		public string LastName { get; set; }

		public List<Publication>? Publications { get; set; }

	}
}