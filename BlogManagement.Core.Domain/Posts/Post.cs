using BlogManagement.Core.Domain.Comments;
using BlogManagement.Core.Domain.Visits;
using Golrang.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Core.Domain.Posts
{
    public class Post: BaseEntity
    {
        public int BlogId {get;set;}
         public string Title {get;set;}
        public string Description{get;set;}
        public ICollection<Comment> Comments { get; set; }
         public ICollection<Visit> Visits { get; set; }
    }
}
