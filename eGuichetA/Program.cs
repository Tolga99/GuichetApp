using System;
using LibraryBD;
using Microsoft.EntityFrameworkCore;

namespace eGuichetA
{
    public class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            GuichetContext guichetContext;
            DbContextOptionsBuilder<GuichetContext> optionsBuilder = new DbContextOptionsBuilder<GuichetContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\t_olg\\Desktop\\Tolga\\Ov\\eGuichetA\\Ticket.db ;Cache=Shared");

            guichetContext = new GuichetContext(optionsBuilder.Options);

            guichetContext.Database.EnsureDeleted();
            guichetContext.Database.EnsureCreated();

            String name = "Ovali";
            String surname = "Tolga";

            String mail = "mail";
            String Phone = "0497";

            User user = new User(name, surname, mail, Phone);
            guichetContext.Users.Add(user);


            int nbTick = 1000;

            Session session = new Session("Bank", user,nbTick);
            guichetContext.Sessions.Add(session);

            Category category = new Category("Deposit", (nbTick / 3) * 0);
            session.Categories.Add(category);
            guichetContext.Categories.Add(category);

            category = new Category("Withdraw", (nbTick / 3) * 1);
            session.Categories.Add(category);
            guichetContext.Categories.Add(category);

            category = new Category("Information", (nbTick / 3) * 2);
            session.Categories.Add(category);
            guichetContext.Categories.Add(category);

            guichetContext.SaveChanges();

            int cate = 2;
            Ticket ticket = session.CreateTicket(cate);
            session.Tickets.Add(ticket);
            guichetContext.Tickets.Add(ticket);
            guichetContext.SaveChanges();
            //Debut testApp
            /* Console.WriteLine("Welcome");
             Console.WriteLine("Inscription\nName :");
             String name=Console.ReadLine();
             Console.WriteLine("Prenom : ");
             String surname = Console.ReadLine();

             Console.WriteLine("Mail : ");
             String mail = Console.ReadLine();
             Console.WriteLine("Phone number");
             String Phone = Console.ReadLine();

             User user = new User(name, surname, mail, Phone);
             guichetContext.Users.Add(user);

             Console.WriteLine("Create a session\nName : ");
             Session session = new Session(Console.ReadLine(), user);
             guichetContext.Sessions.Add(session);

             Console.WriteLine("Maximum number of tickets expected : ");
             int nbTick = Int32.Parse(Console.ReadLine());

             Console.WriteLine("How many categories : ");
             int nbCat = Int32.Parse(Console.ReadLine());
             for (i = 0; i < nbCat; i++)
             {
                 Console.WriteLine("Name of category "+(i+1)+" : ");
                 Category category = new Category(Console.ReadLine(),(nbTick / nbCat)*i);
                 session.Categories.Add(category);
                 guichetContext.Categories.Add(category);
             }
             Console.WriteLine("Session is created");
             guichetContext.SaveChanges();

             Console.WriteLine("Choose your category");
             i = 1;
             foreach (var cat in session.Categories)
             {
                 Console.WriteLine(i + "." + cat.Name);
                 i++;
             }
             Console.WriteLine("-> ");
             int cate=Int32.Parse(Console.ReadLine());
             Ticket ticket = session.CreateTicket(cate);
             session.Tickets.Add(ticket);
             guichetContext.Tickets.Add(ticket);
             guichetContext.SaveChanges();
            */
        }

    }
}