using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pub.Domain.Enums;

namespace Pub.Domain
{
    public class Publication
	{
		public Guid Id { get; set; }

		[Required]
		[MaxLength(150)]
		public string Title { get; set; }

		[Required]
		public Field Field { get; set; }

		[Required]
		[Url]
		public string Url { get; set; }

		[Required]
		public DateTime PublicationDate { get; set; }

		public Guid AuthorId { get; set; }
		[ForeignKey("AuthorId")]
		public Author Author { get; set; }

		public Guid UserId { get; set; }
		[ForeignKey("UserId")]
		public User User { get; set; }

	}
}
