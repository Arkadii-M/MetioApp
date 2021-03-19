using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRainModuleDal
    {
        RainModuleDTO GetByID(int id);
        List<RainModuleDTO> GetAll();
        RainModuleDTO Create(RainModuleDTO dto);

        RainModuleDTO Update(RainModuleDTO dto);
        bool Delete(int id);
    }
}
