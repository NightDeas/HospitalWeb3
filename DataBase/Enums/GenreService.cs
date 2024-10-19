using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Enums
{
    public static class GenreService
    {
        public static string GetGenreString(int genreId)
        {
            switch (genreId)
            {
                case (int)Genres.Male:
                    return "Мужской";
                case (int)Genres.Female:
                    return "Женский";
            }
            throw new NotImplementedException();
        }
    }
}
