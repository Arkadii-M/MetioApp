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
    public class RoleDal : IRoleDal
    {
        private string connectionString;
        public RoleDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public RoleDTO Create(RoleDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetByID(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Roles where id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    return new RoleDTO { id = (int)reader["id"], role = reader["client_role"].ToString() };
                }
                else
                {
                    return null;
                }

            }
        }

        public RoleDTO Update(RoleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
