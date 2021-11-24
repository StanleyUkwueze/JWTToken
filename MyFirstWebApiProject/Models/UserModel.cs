using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApiProject.NewFolder
{
    public class UserModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Lastname { get; set; }
        public string FirstName { get; set; }
        public string  Title { get; set; }
        public string Position { get; set; }
    } 
}
