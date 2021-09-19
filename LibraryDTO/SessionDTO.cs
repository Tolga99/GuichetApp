using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryDTO
{
    class SessionDTO
    {
        private static int NextId;
        private int id;
        private String name;
        private ICollection<CategoryDTO> categories;
        private UserDTO admin;
        private ICollection<TicketDTO> tickets;
        private int range;

        public SessionDTO()
        {
            Id = Interlocked.Increment(ref NextId);
        }
        public SessionDTO(String nom, UserDTO user,int max)
        {
            Id = Interlocked.Increment(ref NextId);
            Admin = user;
            Name = nom;
            Categories = new HashSet<CategoryDTO>();
            Tickets = new HashSet<TicketDTO>();
            Range = max;

        }
        public int Id { get => id; set => id = value; }
        public UserDTO Admin { get => admin; set => admin = value; }
        public ICollection<CategoryDTO> Categories { get => categories; set => categories = value; }
        public ICollection<TicketDTO> Tickets { get => tickets; set => tickets = value; }
        public string Name { get => name; set => name = value; }
        public int Range { get => range; set => range = value; }

        /* public TicketDTO CreateTicket(int cat)
         {
             var bar = (from x in Categories.OfType<CategoryDTO>() where x.Id == cat select x)
                .FirstOrDefault();

             TicketDTO ticket = new TicketDTO(bar.Offset);
             return ticket;
         }*/
        public int getOffset(int cat)
        {
            return Categories.ElementAt(cat).Offset;
        }
    }
}
