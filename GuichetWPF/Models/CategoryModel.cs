using System;
using System.Collections.Generic;
using System.Text;

namespace GuichetWPF.Models
{
    public class CategoryModel
    {
        private int id;
        private String name;
        private int offset;

        public CategoryModel(int idC, String nom, int of)
        {
            Id = idC;
            Name = nom;
            Offset = of;

        }
        public CategoryModel()
        {
            Name = "x";
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int Offset { get => offset; set => offset = value; }
    }
}
