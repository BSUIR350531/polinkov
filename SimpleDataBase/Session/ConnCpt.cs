using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Domain;

namespace Session
{
    public class ConnCpt
    {
        OleDbConnection connection;
        OleDbCommand command;

        private void ConnectTo()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=/movieRentDataBase.accdb;Persist Security Info=False");
            command = connection.CreateCommand();
        }

        public ConnCpt()
        {
            ConnectTo();
        }

        public void Insert(Film f)
        {
            try
            {
                command.CommandText = "INSERT INTO TFilms (FilmTitle, FilmGenre, FilmCountry, FilmProducer, FilmYear, InfoRent, InRent, OverRent) VALUES('" + f.FilmTitle + "', '" + f.FilmGenre + "', '" + f.FilmCountry + "', '" + f.FilmProducer + "', '" + f.FilmYear + "', '" + f.InfoRent + "', '" + f.InRent + "', '" + f.OverRent + "')";
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
