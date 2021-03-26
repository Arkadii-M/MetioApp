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
    public class DeviceDal : IDeviceDal
    {
        private string connectionString;
        public DeviceDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DeviceDTO Create(DeviceDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DeviceDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public DeviceDTO GetByID(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            using (MySqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Devices where id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = comm.ExecuteReader();
                
                if(reader.Read())
                {
                    return new DeviceDTO { id = (int)reader["id"], device_name = reader["device_name"].ToString() };
                }
                else
                {
                    return null;
                }

            }
        }

        public DeviceDTO Update(DeviceDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
