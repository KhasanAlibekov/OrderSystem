using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ordersystem.DataObjects
{
    [Table("TblMessage")]
    public class Message
    {
        [Key]
        [Column("Message_ID")]
        public int MessageID { get; set; }

        [Required]
        [Column("Message_Title")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Column("Message_Content")]
        [DisplayName("Content")]
        public string Content { get; set; }

        [Column("Message_Type")]
        public MessageType Type { get; set; }

        [Column("Message_Date")]
        [DisplayName("Date")]
        public DateTime Date { get; set; }
    }

    public enum MessageType
    {
        StatusMessage,
        ImportantAnnouncement
    }
}
