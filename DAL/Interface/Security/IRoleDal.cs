using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRoleDal
    {
        RoleDTO GetByID(int id);
        List<RoleDTO> GetAll();
        RoleDTO Create(RoleDTO dto);

        RoleDTO Update(RoleDTO dto);
        bool Delete(int id);
    }
}
