using LibraryBLL;
using LibraryDTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTestBLL
{
    public class Tests
    {
        private TicketMethods ticketMethods;
        private SessionMethods sessionMethods;
        private UserMethods userMethods;
        private CategoryMethods categoryMethods;


        [SetUp]
        public void Setup()
        {
            ticketMethods = new TicketMethods();
            sessionMethods= new SessionMethods();
            userMethods = new UserMethods();
            categoryMethods = new CategoryMethods();
        }

        [Test]
        public void TestCreateSession()
        {
            //UserDTO user = userMethods.GetUserbyName("Tolga");
            sessionMethods.CreateSession("Tolga", "Commune");
        }


        [Test]
        public void TestCheckUserSessions()
        {
            //UserDTO user = userMethods.GetUserbyName("Tolga");
            UserDTO us=userMethods.GetUserbyName("Tolga");
            foreach (LightSessionDTO a in us.Sessionsd)
                Console.WriteLine(a);

        }

        [Test]
        public void TestCheckFullSessions()
        {
            ICollection<SessionDTO> list= sessionMethods.GetAllFullSessions();
            foreach (var a in list)
                Console.WriteLine(a);
        }

        [Test]
        public void TestCreateCategories()
        {
            String[] names ={ "ids", "Permis", "Logement" };
            categoryMethods.CreateCategories("Commune", names);
        }
        [Test]
        public void TestGetAllTickets()
        {
            List<TicketDTO> list = ticketMethods.GetAllTicketOfSession(1);
            foreach (var a in list)
                Console.WriteLine(a);
        }
        [Test]
        public void TestCreateTicket()
        {
            int idsess = 1;
            TicketDTO ticket = ticketMethods.CreateTicket(idsess,1);
            Console.WriteLine(ticket);
        }
    }
}