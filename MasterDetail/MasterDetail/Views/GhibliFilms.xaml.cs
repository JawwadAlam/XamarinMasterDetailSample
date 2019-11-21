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
    }
}