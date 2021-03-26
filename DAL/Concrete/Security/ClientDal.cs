using DAL.Interface;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class ClientDal : IClientDal
    {
        private string connectionString;
        public ClientDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public ClientDTO Create(ClientDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClientDTO GetByID(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Clients where client_id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    return new ClientDTO { client_id = (int)reader["client_id"], device_id = (int)reader["device_id"], login = reader["login"].ToString() };
                }
                else
                {
                    return null;
                }

            }
        }

        public ClientDTO GetByLogin(string login)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Clients where login = @login";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login", login);
                conn.Open();
                var reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    return new ClientDTO { client_id = (int)reader["client_id"], device_id = (int)reader["device_id"], login = reader["login"].ToString() };
                }
                else
                {
                    return null;
                }

            }
        }

        public bool Login(string login, string password)
        {
            var pwd = this.GetPassword(login);

            return (pwd.SequenceEqual(password));
        }

        private string GetPassword(string login)
        {
            /*
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Clients where login = @login";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login", login);
                conn.Open();
                var reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    return reader["pass"].ToString();
                }
                else
                {
                    return null;
                }

            }
            */
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Clients where login = @login";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login", login);
                conn.Open();
                var reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    return reader["pass"].ToString();
                }
                else
                {
                    return null;
                }

            }
        }
        public ClientDTO Update(ClientDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
