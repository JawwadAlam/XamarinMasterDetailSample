using MasterDetail.Models;
using MasterDetail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GhibliFilms : ContentPage
    {

        GhibliFilmsViewModel viewModel;

        public GhibliFilms()
        {
            InitializeComponent();
            BindingContext = viewModel = new GhibliFilmsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Films.Count == 0)
                viewModel.LoadFilmsCommand.Execute(null);
        }

        async void OnFilmSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var film = args.SelectedItem as Film;
            if (film == null)
                return;

            await Navigation.PushAsync(new GhibliFilmDetail(new GhibliFilmDetailViewModel(film)));

            // Manually deselect item.
            GhibliFilmsList.SelectedItem = null;
        }
    }
}