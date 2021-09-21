using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryBD
{
    public class Session
    {
        private int id;
        private String name;
        private ICollection<Category> categories;
        private User admin;
        private ICollection<Ticket> tickets;
        private int range;

        public Session()
        {
        }
        public Session(int idS, String nom,User user,int max)
        {
            Id = idS;
            Admin = user;
            Name = nom;
            Categories = new HashSet<Category>();
            Tickets = new HashSet<Ticket>();
            Range = max;

        }
        public int Id { get => id; set => id = value; }
        public User Admin { get => admin; set => admin = value; }
        public ICollection<Category> Categories { get => categories; set => categories = value; }
        public ICollection<Ticket> Tickets { get => tickets; set => tickets = value; }
        public string Name { get => name; set => name = value; }
        public int Range { get => range; set => range = value; }

        public Ticket CreateTicket(int cat)
        {
            var bar = (from x in Categories.OfType<Category>() where x.Id == cat select x)
               .FirstOrDefault();

            Ticket ticket = new Ticket(1,bar.Offset); //ne pas utiliser
            return ticket;
        }
        public int getOffset(int cat)
        {
            return Categories.ElementAt(cat).Offset;
        }
    }
}
