using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class CommentModel
    {
        public bool success { get; set; }
        public Comment data { get; set; }
    }
    public class CommentByProduct
    {
        public bool success { get; set; }
        public List<Comment> data { get; set; }
    }
    public class CommentRequest
    {
        public Guid productid { get; set; }
        public Guid userid { get; set; }
        public int rating { get; set; }
        public string content { get; set; }
    }
    public class DataComment
    {
        public Guid id { get; set; }
        public Guid productid { get; set; }
        public Guid userid { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
        public int rating { get; set; }
        public string content { get; set; }
    }
    public class DeleteComment
    {
        public bool success { get; set; }
        public bool data { get; set; }
    }
}
