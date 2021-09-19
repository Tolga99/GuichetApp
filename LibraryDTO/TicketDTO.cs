using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibraryDTO
{
    public class TicketDTO
    {
       // private static int NextId;
        private int num;
        private DateTime date;
        private int id;
        private int flag; //0=ATTENTE       1=UTILISER

     /*   public TicketDTO()
        {
            Num = 0;
            Date = DateTime.Now;
            Id = Interlocked.Increment(ref NextId);
            Flag = 0;
        }
        public TicketDTO(int n)
        {
            Date = DateTime.Now;
            Id = Interlocked.Increment(ref NextId);
            Flag = 0;
            Num = n + Id;
        }*/
        public TicketDTO(int idn,int n, int fl,DateTime dt)
        {
            Date = dt;
            Id = idn;
            Flag = fl;
            Num = n;
        }
        public int Num { get => num; set => num = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Id { get => id; set => id = value; }
        public int Flag { get => flag; set => flag = value; }

        public override string ToString()
        {
            return "Num : " + Num + "\nId : " + Id + "\nFlag : " + Flag;
        }
    }
}
