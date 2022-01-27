using Avanade.Ecommerce.Mock.Storage;
using Avanade.Ecommerce.WPF.Messaging.Misc;
using Avanade.Ecommerce.WPF.Models;
using Avanade.Ecommerce.WPF.ViewModels;
using Avanade.Ecommerce.WPF.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Avanade.Ecommerce.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Window view;
        protected override void OnStartup(StartupEventArgs e)
        {
            //Mi metto in ascolto di eventuali messaggi "DialogMessage"
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);

            //Inizializzazione database fittizio
            AllocationMockStorage.Initialize();

            //Inizializzo la view di login
            view = new SignInView();

            //Inizializzo il view model associato alla login
            SignInViewModel vm = new SignInViewModel();

            //Collego il vm alla view
            view.DataContext = vm;

            //Mostro la view
            view.Show();

            base.OnStartup(e);
        }


        //metodo che scatta quando arriva un qualsiasi messaggio di tipo 
        //dialog message
        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(message.Content, message.Title);
            if (message.Title.Equals("Log-in Effettuato"))
            {
                MainWindow nextView = new MainWindow();
                //Inizializzo il view model associato alla login
                IProductRepository repositoryProduct = new ProductRepositoryMock();
                MainWindowViewModel vm = new MainWindowViewModel(repositoryProduct);

                //Collego il vm alla view
                nextView.DataContext = vm;
                nextView.Show();
                view.Close();
                view = nextView;
            }
        }
    }
}
