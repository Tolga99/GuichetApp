using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryDTO
{
    public class SessionDTO : LightSessionDTO
    {
        private ICollection<CategoryDTO> categories;
        private ICollection<TicketDTO> tickets;

        public SessionDTO() : base()
        {
        }
        public SessionDTO(int idS,String nom, LightUserDTO user,int max) : base(idS,nom,user,max)
        {
            Categories = new HashSet<CategoryDTO>();
            Tickets = new HashSet<TicketDTO>();
        }
        public SessionDTO(int idS, String nom, LightUserDTO user, int max,ICollection<CategoryDTO> cats, ICollection<TicketDTO> ticks) : base(idS,nom,user,max)
        {
            Categories = cats;
            Tickets = ticks;
        }
        public ICollection<CategoryDTO> Categories { get => categories; set => categories = value; }
        public ICollection<TicketDTO> Tickets { get => tickets; set => tickets = value; }

        public int getOffset(int cat)
        {
            return Categories.ElementAt(cat).Offset;
        }
    }
}
