using DataLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.DataLayer.Entities
{
    public class User : BaseEntity
    {

        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }


        #region Relations
        public UserRole Role { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        #endregion

    }

    #region Enum
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
    #endregion
}
