﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibraryBD
{
    public class User
    {
        private int id;
        private String password;
        private String surname;
        private String mail;
        private String phoneNumber;
        private ICollection<Session> sessions;

        public User()
        {
            Id = 0;
            Password = "/";
            Surname = "/";
            Mail = "/";
            PhoneNumber = "/";
            Sessions = new HashSet<Session>();
        }
        public User(int idU, String pass, String prenom)
        {
            Id = idU;
            Password = pass;
            Surname = prenom;
            Mail = "/";
            PhoneNumber = "/";
            Sessions = new HashSet<Session>();
        }
        public User(int idU, String pass, String prenom, String email, String num)
        {
            Id = idU;
            Password = pass;
            Surname = prenom;
            Mail = email;
            PhoneNumber = num;
            Sessions = new HashSet<Session>();
        }

        public string Password { get => password; set => password = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Mail { get => mail; set => mail = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Id { get => id; set => id = value; }
        public ICollection<Session> Sessions { get => sessions; set => sessions = value; }
    }
}
