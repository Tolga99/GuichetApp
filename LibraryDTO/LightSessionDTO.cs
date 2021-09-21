using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDTO
{
    public class LightSessionDTO
    {
        private int id;
        private String name;
        private LightUserDTO admin;
        private int range;

        public LightSessionDTO()
        {
        }
        public LightSessionDTO(int idS,String nom, LightUserDTO user, int max)
        {
            Id = idS;
            Admin = user;
            Name = nom;
            Range = max;

        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Range { get => range; set => range = value; }
        public LightUserDTO Admin { get => admin; set => admin = value; }
        public override string ToString()
        {
            return "Name : " + Name + "\nAdmin : " + Admin.Surname + "\nRange : " + Range;
        }
    }
}
