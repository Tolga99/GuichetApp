﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibraryDTO
{
    public class CategoryDTO
    {
        private int id;
        private String name;
        private int offset;

        public CategoryDTO(int idC, String nom, int of)
        {
            Id = idC;
            Name = nom;
            Offset = of;

        }
        public CategoryDTO()
        {
            Name = "x";
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int Offset { get => offset; set => offset = value; }
    }
}
