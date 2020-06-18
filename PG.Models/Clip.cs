using System;
using System.Collections.Generic;

namespace PG.Models
{
    public class Clip : BaseModel
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
