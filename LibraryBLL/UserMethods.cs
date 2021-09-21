using LibraryBD;
using LibraryDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBLL
{
    public class UserMethods
    {
        public AccessMethods access;
        public UserMethods()
        {
            access = new AccessMethods();
        }
        public void CreateUser(String pass, String name, String email, String num)
        {
            access.SaveUser(new User(access.FindUserLastId(),pass, name, email, num));
        }
        public UserDTO GetUserbyName(String username)
        {
            var query = access.GetUserByName(username);
            UserDTO user = new UserDTO();
            
            foreach (User us in query)
            {
                ICollection<LightSessionDTO> sessions = new HashSet<LightSessionDTO>();
                foreach(Session sess in us.Sessions)
                {
                    sessions.Add(new LightSessionDTO(sess.Id,sess.Name, new LightUserDTO(sess.Admin.Id,sess.Admin.Password,sess.Admin.Surname,sess.Admin.Mail,sess.Admin.PhoneNumber), sess.Range));
                }
                user = new UserDTO(us.Id, us.Password, us.Surname, us.Mail, us.PhoneNumber,sessions);
            }
            return user; 
        }

    }
}