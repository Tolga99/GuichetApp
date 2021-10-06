using System;
using System.Collections.Generic;
using System.Text;

namespace GuichetWPF.Models
{
    public class SessionModel
    {
        private int id;
        private String name;
        //private LightUserDTO admin;
        private String admin;
        private int range;

        public SessionModel()
        {
        }
        public SessionModel(int idS, String nom, String user, int max)
        {
            Id = idS;
            Admin = user;
            Name = nom;
            Range = max;

        }
        /*public SessionModel(int idS, String nom, LightUserDTO user, int max)
        {
            Id = idS;
            Admin = user;
            Name = nom;
            Range = max;

        }*/
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Range { get => range; set => range = value; }
        public string Admin { get => admin; set => admin = value; }

        //public LightUserDTO Admin { get => admin; set => admin = value; }
        public override string ToString()
        {
            return "Name : " + Name + "\nAdmin : " + Admin + "\nRange : " + Range;
        }
    }
}