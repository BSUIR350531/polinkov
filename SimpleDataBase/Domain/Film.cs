using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Film
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        string filmTitle;

        public string FilmTitle
        {
            get { return filmTitle; }
            set { filmTitle = value; }
        }
        string filmGenre;

        public string FilmGenre
        {
            get { return filmGenre; }
            set { filmGenre = value; }
        }
        string filmCountry;

        public string FilmCountry
        {
            get { return filmCountry; }
            set { filmCountry = value; }
        }
        string filmProducer;

        public string FilmProducer
        {
            get { return filmProducer; }
            set { filmProducer = value; }
        }
        string filmYear;

        public string FilmYear
        {
            get { return filmYear; }
            set { filmYear = value; }
        }
        string infoRent;

        public string InfoRent
        {
            get { return infoRent; }
            set { infoRent = value; }
        }
        string inRent;

        public string InRent
        {
            get { return inRent; }
            set { inRent = value; }
        }
        string overRent;

        public string OverRent
        {
            get { return overRent; }
            set { overRent = value; }
        }
    }
}
