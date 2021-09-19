using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBD
{
    public class AccessMethods
    {
        private GuichetContext GC;

        public AccessMethods()
        {
            DbContextOptionsBuilder<GuichetContext> optionsBuilder = new DbContextOptionsBuilder<GuichetContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\t_olg\\Desktop\\Tolga\\Ov\\eGuichetA\\Ticket.db ;Cache=Shared");
            GC = new GuichetContext(optionsBuilder.Options);
        }
        public AccessMethods(GuichetContext gc)
        {
            GC = gc;
        }
        public IQueryable<Session> GetSessionById(int id)
        {
            var query = from b in GC.Sessions.Include(a => a.Tickets).Include(a => a.Categories)
                        where b.Id == id
                        select b;
            return query;
        }
        public IQueryable<Session> GetAllTicketsOfSession(int id)
        {
            var query = from b in GC.Sessions.Include(a=> a.Tickets)
                             where b.Id == id
                        select b;
            return query;
        }
        public IQueryable<Session> GetCategoriesOfSession(int idSess)
        {
            var query = from b in GC.Sessions.Include(a => a.Categories)
                             where b.Id == idSess
                        select b;
            return query;
        }
        public void SaveTicket(Ticket ticket)
        {
            GC.Tickets.Add(ticket);
            GC.SaveChanges();
        }
        public void SaveCategories(ICollection<Category> cats)
        {
            foreach(Category cat in cats)
            {
                GC.Categories.Add(cat);
            }
            GC.SaveChanges();
        }
        public void SaveSession(Session sess)
        {
            GC.Sessions.Add(sess);
            GC.SaveChanges();
        }
        public IQueryable<Ticket> GetTicket(int num)
        {
            var query = from b in GC.Tickets
                        where b.Num == num
                        select b;
            return query;
        }
        public void SaveState()
        {
            GC.SaveChanges();
        }
        public int FindTicketLastId() 
        {
            if (GC.Tickets.Count() == 0)
            {
                return 1;
            }
            else
            {
                int max = GC.Tickets.Max(i => i.Id);
                return max + 1;
            }
        }
        /* public IQueryable<Film> GetFilmWActorsById(int ID) //Retourne un film grace a son id   && InsertComment && GetListActorsByIdFilm
         {

             var query = from b in CC.Films.Include(a => a.Actors)
                         where b.FilmId == ID
                         select b;

             return query;
         }
         public IQueryable<Film> GetFilmWComById(int ID) //Retourne un film grace a son id   && InsertComment && GetListActorsByIdFilm
         {

             var query = from b in CC.Films.Include(a => a.Comments)
                         where b.FilmId == ID
                         select b;

             return query;
         }
         public IQueryable<Film> GetFullFilmByIdFilm(int ID) //Retourne un film detaillé grace a son id
         {
             var query = from b in CC.Films.Include(a => a.Actors).Include(c => c.FilmTypelist).Include(e => e.Comments)//AJOUTER SYSTEM.LINQ
                         where b.FilmId == ID
                         select b;
             return query;

         }
         public IQueryable<Film> GetAllFilms() //Retourne un film detaillé grace a son id
         {
             var query = from b in CC.Films.Include(a => a.Actors).Include(c => c.FilmTypelist).Include(e => e.Comments)//AJOUTER SYSTEM.LINQ
                         orderby b.Title
                         select b;
             return query;
         }
         public IQueryable<Film> GetFullFilmByTitle(string title) //Retourne un film detaillé grace a son id
         {
             var query = from b in CC.Films.Include(c => c.FilmTypelist).Include(e => e.Comments).Include(e => e.Actors)//AJOUTER SYSTEM.LINQ
                         where b.Title.ToLower() == title.ToLower()
                         select b;
             return query;
         }
         public IQueryable<Film> GetFilmWTypesByIdFilm(int id) //GetListFilmTypesByIdFilm
         {
             var query = from b in CC.Films.Include(a => a.FilmTypelist)//AJOUTER SYSTEM.LINQ
                         where b.FilmId == id
                         select b;

             return query;
         }
         public int FindLastId() //Comments
         {
             if (CC.Comments.Count() == 0)
             {
                 return 1;
             }
             else
             {
                 int max = CC.Comments.Max(i => i.Id);//AJOUTER SYSTEM.LINQ
                 return max + 1;
             }
         }
         public void AddComment(Film film, Comment cmt)
         {
             CC.Comments.Add(cmt);
             film.Comments.Add(cmt);
             CC.SaveChanges();
         }
         public IQueryable<Actor> GetActorById(int Id)
         {
             var query = from b in CC.Actors.Include(a => a.Films)//AJOUTER SYSTEM.LINQ
                         where b.ActorId == Id
                         select b;

             return query;
         }
         public IQueryable<Comment> GetComments(int Id)
         {
             var query = from b in CC.Comments//AJOUTER SYSTEM.LINQ
                         where b.IdFilm == Id
                         select b;

             return query;
         }*/
    }
}