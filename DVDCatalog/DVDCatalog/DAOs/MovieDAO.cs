﻿using DVDCatalog.Models;
namespace DVDCatalog.DAOs
{
    public class MovieDAO
    {
        public MovieDAO() { }

        public MovieDAO(MovieModel movie)
        {
            Title = movie.Title;
            Description = movie.Description;
            Genre = movie.Genre;
            Director = movie.Director;
            DateReleased = movie.DateReleased;
            MovieStar = movie.MovieStar;
            Rating = movie.Rating;
        }

        public MovieDAO(string title, string description, string genre, string director, DateTime dateReleased, string movieStar, double rating)
        {
            Title = title;
            Description = description;
            Genre = genre;
            Director = director;
            DateReleased = dateReleased;
            MovieStar = movieStar;
            Rating = rating;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public DateTime DateReleased { get; set; }

        public string MovieStar { get; set; }

        public double Rating { get; set; }
    }
}
