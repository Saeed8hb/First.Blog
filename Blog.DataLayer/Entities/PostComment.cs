using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DataLayer.Entities
{
    public class PostComment : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Text { get; set; }

        #region Relation
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion
    }
}
