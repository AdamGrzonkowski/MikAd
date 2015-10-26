using System;

namespace Shop.Model.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
        public int AuthorId { get; set; }

        public User User { get; set; }
        public User Author { get; set; }
    }
}