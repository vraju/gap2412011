using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies;
        }

        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
            {
                   movies.Add(movie);
            }


         
        }
    

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var list = new List<Movie>(movies);
            list.Sort((movie1, movie2) => movie2.title.CompareTo(movie1.title));
            return list;
        }


        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            var list = new List<Movie>(movies);

            return list.FindAll(movie => (movie.production_studio.Equals(ProductionStudio.Pixar)));

        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            var list = new List<Movie>(movies);

            return list.FindAll(movie => (movie.production_studio.Equals(ProductionStudio.Pixar) || movie.production_studio.Equals(ProductionStudio.Disney)));
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            var list = new List<Movie>(movies);
            list.Sort((movie1, movie2) => movie1.title.CompareTo(movie2.title));
            return list;
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var list = new List<Movie>(movies);
            list.Sort(new MovieStudioYearComparitor());
            return list;
        }



        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            var list = new List<Movie>(movies);

            return list.FindAll( movie => (!movie.production_studio.Equals(ProductionStudio.Pixar) ));
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            var list = new List<Movie>(movies);

            return list.FindAll(movie => (movie.date_published.Year > year));
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            var list = new List<Movie>(movies);

            return list.FindAll(movie => (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear));
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            var list = new List<Movie>(movies);

            return list.FindAll(movie => (movie.genre.Equals(Genre.kids)));
        }

        public IEnumerable<Movie> all_action_movies()
        {
            var list = new List<Movie>(movies);

            return list.FindAll(movie => (movie.genre.Equals(Genre.action)));

        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var list = new List<Movie>(movies);
            list.Sort((movie1, movie2) => movie2.date_published.CompareTo(movie1.date_published));
            return list;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var list = new List<Movie>(movies);
            list.Sort((movie1, movie2) => movie1.date_published.CompareTo(movie2.date_published));
            return list;
        }
    }

    public class MovieStudioYearComparitor : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            if (x.production_studio.name.Equals(y.production_studio.name))
            {
                return x.date_published.Year.CompareTo(y.date_published.Year);
            }
            else
            {
                return x.production_studio.name.CompareTo(y.production_studio.name);

            }


        }
    }


}