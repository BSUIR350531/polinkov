using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Domain;
using System.Windows.Forms;

namespace SimpleDataBase
{
    class Conn
    {
        OleDbConnection connection;
        OleDbCommand command;

        private void ConnectTo()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=" + Path.GetDirectoryName(Application.ExecutablePath) + "/movieRentDataBase.accdb;Persist Security Info=False");
            command = connection.CreateCommand();
        }

        public Conn()
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

        public void Delete(Film f)
        {
            try
            {
                command.CommandText = "DELETE FROM TFilms WHERE ID= " + f.ID;
                command.Parameters.Add(new OleDbParameter("ID", f.ID));
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
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void Update(Film f)
        {
            try
            {
                command.CommandText = "UPDATE [TFilms] SET [TFilms].FilmTitle= '" +f.FilmTitle+ "', [TFilms].FilmGenre= '" +f.FilmGenre+ "', [TFilms].FilmCountry= '" +f.FilmCountry+ "', [TFilms].FilmProducer= '" +f.FilmProducer+ "', [TFilms].FilmYear= '" +f.FilmYear+ "', [TFilms].InfoRent= '" +f.InfoRent+ "', [TFilms].InRent= '" +f.InRent+"', [TFilms].OverRent= '" +f.OverRent+"' WHERE [TFilms].ID = " +f.ID+ "";
                command.Parameters.Add(new OleDbParameter("ID", f.ID));
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
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
