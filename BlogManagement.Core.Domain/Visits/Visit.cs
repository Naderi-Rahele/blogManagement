using System;
using Golrang.Framework.Domain;

namespace BlogManagement.Core.Domain.Visits
{
    public class Visit :BaseEntity
    {
       public int PostId{get;set;} 
       public DateTime CreatedOn {get;set;}
    }
}