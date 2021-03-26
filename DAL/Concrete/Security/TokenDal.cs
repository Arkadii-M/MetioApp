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
    public class TokenDal : ITokenDal
    {
        private string connectionString;
        public TokenDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public TokenDTO Create(TokenDTO dto)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Tokens(id,token,expire_date) values(@id,@token,@expire_date)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", dto.id);
                comm.Parameters.AddWithValue("@token", dto.token);
                comm.Parameters.AddWithValue("@expire_date", dto.expire_date);
                conn.Open();
                comm.ExecuteNonQuery();
            }
            return this.GetByID(dto.id);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TokenDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TokenDTO GetByID(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Tokens where id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = comm.ExecuteReader();
                
                if (reader.Read())
                {
                    return new TokenDTO { id = (int)reader["id"],token = new Guid(reader["token"].ToString()),expire_date = Convert.ToDateTime(reader["expire_date"].ToString()) };
                }
                else
                {
                    return null;
                }

            }
        }

        public List<TokenDTO> GetByToken(Guid token)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Tokens where token = @token";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@token", token);
                conn.Open();
                var reader = comm.ExecuteReader();
                var res = new List<TokenDTO>();
                while(reader.Read())
                {
                    res.Add(new TokenDTO { id = (int)reader["id"], token = new Guid(reader["token"].ToString()), expire_date = Convert.ToDateTime(reader["expire_date"].ToString()) });
                }
                return res;

            }
        }

        public TokenDTO Update(TokenDTO dto)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "UPDATE Tokens SET token=@token,expire_date = @expire_date where id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@token", dto.token);
                comm.Parameters.AddWithValue("@expire_date", dto.expire_date);
                comm.Parameters.AddWithValue("@id", dto.id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
            return this.GetByID(dto.id);
        }
    }
}
