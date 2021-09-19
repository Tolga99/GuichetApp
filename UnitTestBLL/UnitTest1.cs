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
        [SetUp]
        public void Setup()
        {
            ticketMethods = new TicketMethods();
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
            TicketDTO ticket = ticketMethods.CreateTicket(idsess);
            Console.WriteLine(ticket);
        }
    }
}