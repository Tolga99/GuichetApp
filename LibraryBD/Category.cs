﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibraryBD
{
    public class Category
    {
        private static int NextId;
        private int id;
        private String name;
        private int offset;

        public Category(String nom,int of)
        {
            Id = Interlocked.Increment(ref NextId);
            Name = nom;
            Offset = of;

        }
        public Category()
        {
            Name = "x";
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int Offset { get => offset; set => offset = value; }
    }
}
