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
    public class PermissionDal : IPermissionDal
    {
        private string connectionString;
        public PermissionDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public PermissionDTO Create(PermissionDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PermissionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<PermissionDTO> GetByID(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Permissions where id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = comm.ExecuteReader();

                var to_ret = new List<PermissionDTO>();
                while (reader.Read())
                {
                    to_ret.Add( new PermissionDTO { id = (int)reader["id"], role_id = (int)reader["role_id"] });
                }

                return to_ret;

            }
        }

        public PermissionDTO Update(PermissionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
