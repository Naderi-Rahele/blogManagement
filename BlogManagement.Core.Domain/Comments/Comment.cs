using Golrang.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Core.Domain.Comments
{
    public class Comment: BaseEntity
    {
        public int PostId { get; set; }
        public string Title {get;set;}
        public string Desciption { get; set; }
    }
}
