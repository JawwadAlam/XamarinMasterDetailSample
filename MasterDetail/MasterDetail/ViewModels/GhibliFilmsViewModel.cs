using MasterDetail.Models;
using MasterDetail.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail.ViewModels
{
    public class GhibliFilmsViewModel : BaseViewModel
    {
        public ObservableCollection<Film> Films { get; set; }
        public Command LoadFilmsCommand { get; set; }

        private GhibliService ServiceSource;

        public GhibliFilmsViewModel()
        {
            Title = "Ghibli Films";
            Films = new ObservableCollection<Film>();
            LoadFilmsCommand = new Command(async () => await ExecuteLoadFilmsCommand());
            ServiceSource = new GhibliService();
        }

        async Task ExecuteLoadFilmsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Films.Clear();
                var filmsResponse = await ServiceSource.GetFilmsAsync(true);
                foreach (var film in filmsResponse)
                {
                    Films.Add(film);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
