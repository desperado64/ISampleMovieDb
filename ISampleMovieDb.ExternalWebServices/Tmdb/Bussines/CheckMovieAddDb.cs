using ISampleMovieDb.Business.Abstract;
using ISampleMovieDb.Business.DependencyResolvers.Ninject;
using ISampleMovieDb.Entities.Concrete;
using ISampleMovieDb.ExternalWebServices.Tmdb.Model;
using ISampleMovieDb.ExternalWebServices.Tmdb.Model.Movie;
using ISampleMovieDb.ExternalWebServices.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ISampleMovieDb.ExternalWebServices.Tmdb.Bussines
{
    public static class CheckMovieAddDb
    {
        private static int count = 1;
        private static int duration = 60 * 60 * 1000;

        public static void CheckAndAdd()
        {
            Thread thread = new Thread(xCheckMovieAddDb);
           thread.Start(); 
        }

        private static void xCheckMovieAddDb(object obj)
        {
            Timer timer = new Timer(new TimerCallback(DoSomething),null,0,duration);

            
        }

        private static void DoSomething(object state)
        {
            IMovieService movieService = InstanceFactory.GetInstance<IMovieService>();


            Popular popular = JsonParse.Get<Popular>(TmdbLinked.GetPopular(count));

            foreach (var item in popular.results)
            {
                Movie movie = movieService.Get(x => x.TmdbID == item.id);
                if (movie != null)
                {
                    SetMovie(movie, item);
                    movieService.Update(movie);
                }
                else
                {
                    var m = new Movie();
                    SetMovie(m, item);
                    movieService.Add(m);
                }


            }

            count++;
        }

        private static void SetMovie(Movie movie, Result item)
        {
            movie.Adult = item.adult;
            movie.PosterPath = TmdbLinked.GetImages(item.poster_path);
            movie.Overview = item.overview;
            movie.ReleaseDate = item.release_date;
            movie.Genres = MergeGenres(item.genre_ids);
            movie.TmdbID = item.id;
            movie.OriginalTitle = item.original_title;
            movie.OriginalLanguage = item.original_language;
            movie.Title = item.title;
            movie.BackdropPath = TmdbLinked.GetImages(item.backdrop_path);
            movie.Popularity = item.popularity.ToString();
            movie.VoteCount = item.vote_count;
            movie.Video = item.video;
            movie.VoteAverage = item.vote_average;
        }

        private static string MergeGenres(int[] genre_ids)
        {

            Genres genres = JsonParse.Get<Genres>(TmdbLinked.GetGenres());
            List<string> names = new List<string>();
            foreach (var item in genre_ids)
            {
                NameId nameId = genres.genres.Find(x => x.id == item);
                if (nameId != null)
                {
                    names.Add(nameId.name);
                }
            }

            return String.Join(",", names.ToArray());
        }
    }
}
