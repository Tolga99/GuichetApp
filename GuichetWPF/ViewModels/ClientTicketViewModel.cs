using GuichetWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace GuichetWPF.ViewModels
{
    public class ClientTicketViewModel
    {
        int i = 0;

        public ObservableCollection<CategoryModel> Categories { get; set; }
        public ICommand cmdClick { get; set; }
        public ICommand cmdSearch { get; set; }
        public ICommand cmdVisu { get; set; }
        public ICommand cmdBack { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public SessionModel sessionModel;
        public String rech { get; set; }
        public int idSess { get; set; }
        public int idCat { get; set; }

        public CategoryModel Actuel { get; set; }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async void CreateTicket()
        {
            //var content = new StringContent('"' + Actuel.Id.ToString() + '"', Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
              //  using (var response = await httpClient.PostAsync("http://localhost:53454/api/Film/name", content))
                using (var response = await httpClient.GetAsync("http://localhost:50221/ticket/newticket/"+idSess+"/"+Actuel.Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var ff = JsonConvert.DeserializeObject<TicketModel>(apiResponse);
                    //Films.Clear();
                    if (ff == null)
                    {
                        Console.WriteLine("Pas de ticket");
                    }
                    //else Films.Add(new FilmModel(ff.Id, ff.Posterpath, ff.Title, ff.Runtime, GenreImage(ff.FilmTypelist), ff.CommentsD));
                }
            }
        }
        private void GetTicket()
        {
            //Categories.Count();
            if (Actuel != null)
            {
               /* Actuel.Title.ToString();
                FilmWindow fw = new FilmWindow();
                fw.DataContext = new CommentViewModel(Actuel);
                fw.Show();*/

            }
        }

        public ClientTicketViewModel()
        {
          /*  cmdClick = new DelegateCommand((a) => NextPage());
            cmdBack = new DelegateCommand((a) => BackPage());
            cmdSearch = new DelegateCommand((a) => Search());
            cmdVisu = new DelegateCommand((a) => Visualise());*/
            Categories = new ObservableCollection<CategoryModel>();
        }
        public ClientTicketViewModel(SessionModel sess)
        {
            /*  cmdClick = new DelegateCommand((a) => NextPage());
              cmdBack = new DelegateCommand((a) => BackPage());
              cmdSearch = new DelegateCommand((a) => Search());
              cmdVisu = new DelegateCommand((a) => Visualise());*/
            sessionModel = sess;
            foreach(var c in sess.Categories)
            {
                Categories.Add(c);
            }
            
        }
    }
}