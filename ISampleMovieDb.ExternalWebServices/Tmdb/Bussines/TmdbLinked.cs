using System;
using System.Collections.Generic;
using System.Text;

namespace ISampleMovieDb.ExternalWebServices.Tmdb.Bussines
{
    public static class TmdbLinked
    {
        private const string Api_Key = "YOUR_API_KEY"; //The movie database
        private const string Base_Url = "https://api.themoviedb.org/";

        public static string GetPopular(int page)
        {
            return String.Format("{0}3/movie/popular?api_key={1}&language=en-US&page={2}", Base_Url, Api_Key,page);
        }

        public static string GetImages(string url)
        {
            return String.Format("{0}t/p/w500{1}", Base_Url, url);
        }

        public static string GetGenres()
        {
            return String.Format("{0}3/genre/movie/list?api_key={1}&language=en-US", Base_Url, Api_Key);
        }
    }
}
