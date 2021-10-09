using GuichetWPF.Models;
using GuichetWPF.Views;
using LibraryDTO;
using Microsoft.VisualStudio.PlatformUI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace GuichetWPF.ViewModels
{
    public class ClientSessionsViewModel
    {
        int i = 0;

        public ObservableCollection<SessionModel> Sessions { get; set; }
        public ICommand cmdRefresh { get; set; }
        public ICommand cmdEnter { get; set; }
        public SessionModel ActualSession;

        public event PropertyChangedEventHandler PropertyChanged;
        public String rech { get; set; }
        public int idSess { get; set; }
        public int idCat { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public async void GetAllSessions()
        {
            //var content = new StringContent('"' + Actuel.Id.ToString() + '"', Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                //  using (var response = await httpClient.PostAsync("http://localhost:53454/api/Film/name", content))
                using (var response = await httpClient.GetAsync("http://localhost:50221/session/sessions"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var ss = JsonConvert.DeserializeObject<List<SessionDTO>>(apiResponse);

                    //Films.Clear();
                    if (ss == null)
                    {
                        Console.WriteLine("Pas de sessions");
                    }
                    else
                    {
                        foreach(var sess in ss)
                        {
                            Sessions.Add(new SessionModel(sess.Id,sess.Name,sess.Admin.Surname,sess.Range,ConvertCategories(sess.Categories)));
                        }
                    }
                    //else Films.Add(new FilmModel(ff.Id, ff.Posterpath, ff.Title, ff.Runtime, GenreImage(ff.FilmTypelist), ff.CommentsD));
                }
            }
        }
        public void EnterSession()
        {
            Sessions.Count();
            if (ActualSession != null)
            {
                TicketInterface ti = new TicketInterface();
                ti.DataContext = new ClientTicketViewModel(ActualSession);
                ti.Show();
            }

        }

        public ClientSessionsViewModel()
        {
            cmdEnter = new DelegateCommand((a) => EnterSession());
            cmdRefresh = new DelegateCommand((a) => GetAllSessions());
            Sessions = new ObservableCollection<SessionModel>();
            GetAllSessions();
        }
        public ICollection<CategoryModel> ConvertCategories(ICollection<CategoryDTO> cat)
        {
            ICollection<CategoryModel> category = new List<CategoryModel>();
            foreach(var c in cat)
            {
                category.Add(new CategoryModel(c.Id, c.Name, c.Offset));
            }
            return category;

        }
    }
}