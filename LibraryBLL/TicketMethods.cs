using LibraryBD;
using LibraryDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBLL
{
    public class TicketMethods
    {
        public AccessMethods access;
        public TicketMethods()
        {
            access = new AccessMethods();
        }
        public List<TicketDTO> GetAllTicketOfSession(int idsess)
        {
            List<TicketDTO> list = new List<TicketDTO>();
            var query = access.GetAllTicketsOfSession(idsess);
            foreach(var sess in query)
            {
                foreach(var tick in sess.Tickets)
                {
                    list.Add(new TicketDTO(tick.Id,tick.Num,tick.Flag,tick.Date));
                }
            }
            return list;
        }
        public TicketDTO CreateTicket(int idSess,int idCat)
        {
            Session session = new Session();
            //int range=0;
            //int nbCat = 0;
            int idT=access.FindTicketLastId();
            var query = access.GetSessionById(idSess);
            foreach(Session sess in query)
            {
                session = sess;
                //range = sess.Range;
                //nbCat = sess.Categories.Count;
            }
        
            Ticket ticket = new Ticket(idT,session.getOffset(idCat));
            session.Tickets.Add(ticket);
            access.SaveTicket(ticket);
            return new TicketDTO(ticket.Id, ticket.Num, ticket.Flag,ticket.Date);
        }
    }
}
