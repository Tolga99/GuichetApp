using LibraryBD;
using LibraryDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBLL
{
    public class SessionMethods
    {
        public AccessMethods access;
        public SessionMethods()
        {
            access = new AccessMethods();
        }
        public void CreateSession(String username, String nameSess, int max=1000)
        {
            var query = access.GetUserByName(username);
            User user = new User();
            foreach (User us in query)
                user = us;
            Session sess = new Session(access.FindSessionLastId(), nameSess, user, max);
            access.SaveSession(sess);
        }
        public ICollection<SessionDTO> GetAllFullSessions()
        {
            var query = access.GetAllFullSessions();
            ICollection<SessionDTO> list = new HashSet<SessionDTO>();
            foreach(Session sess in query)
            {
                ICollection<CategoryDTO> listCat = new HashSet<CategoryDTO>();
                ICollection<TicketDTO> listTic = new HashSet<TicketDTO>();

                foreach (Category cate in sess.Categories)
                {
                    listCat.Add(new CategoryDTO(cate.Id, cate.Name, cate.Offset));
                }
                foreach(Ticket tick in sess.Tickets)
                {
                    listTic.Add(new TicketDTO(tick.Id, tick.Num, tick.Flag,tick.Date));
                }
                list.Add(new SessionDTO(sess.Id, sess.Name, 
                    new LightUserDTO(sess.Admin.Id,sess.Admin.Password,sess.Admin.Surname,sess.Admin.Mail,sess.Admin.PhoneNumber),
                    sess.Range, listCat, listTic));
            }
            return list;
        }
        public SessionDTO GetSessionById(int id)
        {
            var query = access.GetSessionById(id);
            SessionDTO sessD = new SessionDTO();
            //ICollection<SessionDTO> list = new HashSet<SessionDTO>();
            foreach (Session sess in query)
            {
                ICollection<CategoryDTO> listCat = new HashSet<CategoryDTO>();
                ICollection<TicketDTO> listTic = new HashSet<TicketDTO>();

                foreach (Category cate in sess.Categories)
                {
                    listCat.Add(new CategoryDTO(cate.Id, cate.Name, cate.Offset));
                }
                foreach (Ticket tick in sess.Tickets)
                {
                    listTic.Add(new TicketDTO(tick.Id, tick.Num, tick.Flag, tick.Date));
                }
                sessD = new SessionDTO(sess.Id, sess.Name,
                    new LightUserDTO(sess.Admin.Id, sess.Admin.Password, sess.Admin.Surname, sess.Admin.Mail, sess.Admin.PhoneNumber),
                    sess.Range, listCat, listTic);
            }
            return sessD;
        }
        public int GetNbCategoriesOfSessionById(int id)
        {
            int Number = 0;
            var query = access.GetCategoriesOfSessionById(id);
            foreach(var sess in query)
            {
                Number=sess.Categories.Count;
            }
            return Number;
        }
        public int GetNbCategoriesOfSessionByName(String name)
        {
            int Number = 0;
            var query = access.GetCategoriesOfSessionByName(name);
            foreach (var sess in query)
            {
                Number = sess.Categories.Count;
            }
            return Number;
        }
    }
}
