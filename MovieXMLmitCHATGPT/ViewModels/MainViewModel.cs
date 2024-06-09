using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieXMLmitCHATGPT.Models;
using MovieXMLmitCHATGPT.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieXMLmitCHATGPT.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private MovieRepository _movieRepository;
        public MainViewModel()
        {
            
        }

        public MainViewModel(MovieRepository mv)
        {
            _movieRepository = mv;

        }

        [ObservableProperty]
        ObservableCollection<Movie> _movies = new ObservableCollection<Movie>();

        [ObservableProperty]
        private string _id;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _director;

        [ObservableProperty]
        private string _year;

        [RelayCommand]
        private void ExecuteLoadMovies()
        {
            List<Movie> movies = _movieRepository.GetAll();
            foreach (Movie movie in movies)
            {
                Movies.Add(movie);
            }
        }

        [RelayCommand]
        private void ExecuteAddMovie()
        {
            var movie = new Movie
            {
                Id = Convert.ToInt32(Id),
                Title = Title,
                Director = Director,
                Year = Convert.ToInt32(Year)
            };
            _movieRepository.Add(movie);
            ExecuteLoadMovies();
        }
        [RelayCommand]
        private void ExecuteUpdateMovie()
        {
            var movie = new Movie
            {
                Id = Convert.ToInt32(Id),
                Title = Title,
                Director = Director,
                Year = Convert.ToInt32(Year)
            };
            _movieRepository.Update(movie);
            ExecuteLoadMovies();
        }

        [RelayCommand]
        private void ExecuteDeleteMovie(string id)
        {
            int id2 = Convert.ToInt32(id);
            _movieRepository.Delete(id2);
            ExecuteLoadMovies();
        }

    }
}
