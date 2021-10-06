using System;
using System.Collections.Generic;
using System.Text;

namespace GuichetWPF.Models
{
    public class TicketModel
    {
        private int num;
        private DateTime date;
        private int id;
        private int flag; //0=ATTENTE       1=UTILISER


        public TicketModel(int idn, int n, int fl, DateTime dt)
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