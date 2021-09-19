using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibraryBD
{
    public class User
    {
        private static int NextId;
        private int id;
        private String name;
        private String surname;
        private String mail;
        private String phoneNumber;

        public User()
        {
            Id = Interlocked.Increment(ref NextId);
            Name = "/";
            Surname = "/";
            Mail = "/";
            PhoneNumber = "/";
        }
        public User(String nom, String prenom)
        {
            Id = Interlocked.Increment(ref NextId);
            Name = nom;
            Surname = prenom;
            Mail = "/";
            PhoneNumber = "/";
        }
        public User(String nom, String prenom, String email, String num)
        {
            Id = Interlocked.Increment(ref NextId);
            Name = nom;
            Surname = prenom;
            Mail = email;
            PhoneNumber = num;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Mail { get => mail; set => mail = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Id { get => id; set => id = value; }
    }
}
