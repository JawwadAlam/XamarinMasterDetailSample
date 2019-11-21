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
    public partial class GhibliFilmDetail : ContentPage
    {
        private GhibliFilmDetailViewModel viewModel;

        public GhibliFilmDetail(GhibliFilmDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
    }
}