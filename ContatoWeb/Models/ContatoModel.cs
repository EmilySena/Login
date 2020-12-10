using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ContatoWeb.Models
{
    public class ContatoModel : IDisposable
    {
        private SqlConnection connection;

        public ContatoModel()
        {
            string strConn = "Data Source=OPN02\\SQLEXPRESS; Initial Catalog=BDContato; Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Contato contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Contato VALUES (@nome, @email)";

            cmd.Parameters.AddWithValue("@nome", contato.Nome);
            cmd.Parameters.AddWithValue("@email", contato.Email);

            cmd.ExecuteNonQuery();
        }
        public void Update(Contato contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Contato SET Nome=@nome, Email=@email WHERE IdContato=@id";

            cmd.Parameters.AddWithValue("@nome", contato.Nome);
            cmd.Parameters.AddWithValue("@email", contato.Email);
            cmd.Parameters.AddWithValue("@id", contato.IdContato);

            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Contato WHERE IdContato=@id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
        public List<Contato> Read()
        {

            List<Contato> lista = new List<Contato>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Contato";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Contato contato = new Contato();
                contato.IdContato = (int)reader["IdContato"];
                contato.Nome = (string)reader["Nome"];
                contato.Email = (string)reader["Email"];

                lista.Add(contato);
            }

            return lista;
        }

        //public void Dispose() => throw new NotImplementedException();
    }
}