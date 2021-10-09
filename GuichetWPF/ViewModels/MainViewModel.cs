using GuichetWPF.Views;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace GuichetWPF.ViewModels
{
    public class MainViewModel
    {
        int i = 0;
        public ICommand cmdClient { get; set; }
        public ICommand cmdUser { get; set; }



        public int idSess { get; set; }
        public int idCat { get; set; }

        private async void ClientWindow()
        {
            ClientWindow ti = new ClientWindow();
            ti.Show();

                /* Actuel.Title.ToString();
                 FilmWindow fw = new FilmWindow();
                 fw.DataContext = new CommentViewModel(Actuel);
                 fw.Show();*/
        }
        private async void UserWindow()
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
                /* Actuel.Title.ToString();
                 FilmWindow fw = new FilmWindow();
                 fw.DataContext = new CommentViewModel(Actuel);
                 fw.Show();*/
        }

        public MainViewModel()
        {
              cmdClient = new DelegateCommand((a) => ClientWindow());
              cmdUser = new DelegateCommand((a) => UserWindow());
        }
    }
}