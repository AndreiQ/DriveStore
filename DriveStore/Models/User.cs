using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveStore.Models
{
   public class User
    {
        public string FullName { get; set; }
        public string LoginName { get; set; }
        public string DriveSize { get; set; }

        public User(string fullName, string loginName, string driveSize)
        {
            FullName = fullName;
            LoginName = loginName;
            DriveSize = driveSize;
        }
    }
}
