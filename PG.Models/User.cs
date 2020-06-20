using System;
using System.Collections.Generic;
using System.Text;

namespace PG.Models
{
    public class User : BaseModel
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String AvatarUrl { get; set; }
        public String About { get; set; }
    }
}
