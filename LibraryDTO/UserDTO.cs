using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibraryDTO
{
    public class UserDTO : LightUserDTO
    {
        private ICollection<LightSessionDTO> sessionsd;


        public UserDTO() : base()
        {
            Sessionsd = new HashSet<LightSessionDTO>();
        }
        public UserDTO(int idU, String pass, String prenom) : base(idU,pass,prenom)
        {
            Sessionsd = new HashSet<LightSessionDTO>();
        }
        public UserDTO(int idU,String pass, String prenom, String email, String num,ICollection<LightSessionDTO> sess) : base(idU,pass,prenom,email,num)
        {
            Sessionsd = sess;
        }

        public ICollection<LightSessionDTO> Sessionsd { get => sessionsd; set => sessionsd = value; }
    }
}
