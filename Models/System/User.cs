using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.System
{
    using Models.EnumEntity;

    public class User
    {
       public int ID { get; set; }

       public string UserName { get; set; }

       public string PassWord{ get; set; }

       public string NickName{ get; set; }

       public int Level { get; set; }

       public Gender Gender { get; set; }

       public string Email { get; set; }

       public string UserImageUrl { get; set; }
    }
}
