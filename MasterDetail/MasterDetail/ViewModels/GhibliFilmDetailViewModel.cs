using MasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.ViewModels
{
    public class GhibliFilmDetailViewModel : BaseViewModel
    {
        public Film Film { get; set; }
        public GhibliFilmDetailViewModel(Film film = null)
        {
            Title = film?.title;
            Film = film;
        }
    }
}
