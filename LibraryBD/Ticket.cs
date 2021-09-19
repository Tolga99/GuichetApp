using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibraryBD
{
    public class Ticket
    {
        //private static int NextId;
        private int num;
        private DateTime date;
        private int id;
        private int flag; //0=ATTENTE       1=UTILISER
        
        public Ticket()
        {
            Num = 0;
            Date = DateTime.Now;
            //Id = Interlocked.Increment(ref NextId);
            Flag = 0;
        }
        public Ticket(int idT,int n)
        {
            Date = DateTime.Now;
            //Id = Interlocked.Increment(ref NextId);
            Id = idT;
            Flag = 0;
            Num = n + Id;
        }
        public Ticket(int idT,int n, int fl)
        {
            Date = DateTime.Now;
            //Id = Interlocked.Increment(ref NextId);
            Id = idT;
            Flag = fl;
            Num = n + Id;
        }

        public int Num { get => num; set => num = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Id { get => id; set => id = value; }
        public int Flag { get => flag; set => flag = value; }

    }
}
