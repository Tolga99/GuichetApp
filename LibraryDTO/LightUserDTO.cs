using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDTO
{
    public class LightUserDTO
    {
        private int id;
        private String password;
        private String surname;
        private String mail;
        private String phoneNumber;

        public LightUserDTO()
        {
            Id = 0;
            Password = "/";
            Surname = "/";
            Mail = "/";
            PhoneNumber = "/";
        }
        public LightUserDTO(int idU, String pass, String prenom)
        {
            Id = idU;
            Password = pass;
            Surname = prenom;
            Mail = "/";
            PhoneNumber = "/";
        }
        public LightUserDTO(int idU, String pass, String prenom, String email, String num)
        {
            Id = idU;
            Password = pass;
            Surname = prenom;
            Mail = email;
            PhoneNumber = num;
        }

        public string Password { get => password; set => password = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Mail { get => mail; set => mail = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Id { get => id; set => id = value; }
    }
}