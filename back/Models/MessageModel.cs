using System.ComponentModel.DataAnnotations;

namespace back.Models
{
	public class MessageModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public UserModel SenderUser { get; set; }

		[MaxLength(1024)]
		public string? Text { get; set; }

		//[Range(0, 10)]
		public IEnumerable<AttachmentModel?>? Attachments { get; set; }

		[Required]
		public DateTime SentAt { get; set; }
	}
}
