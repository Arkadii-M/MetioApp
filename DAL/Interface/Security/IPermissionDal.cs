using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPermissionDal
    {
        PermissionDTO GetByID(int id);
        List<PermissionDTO> GetAll();
        PermissionDTO Create(PermissionDTO dto);

        PermissionDTO Update(PermissionDTO dto);
        bool Delete(int id);
    }
}
