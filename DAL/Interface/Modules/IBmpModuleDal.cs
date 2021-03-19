using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IBmpModuleDal
    {
        BmpModuleDTO GetByID(int id);
        List<BmpModuleDTO> GetAll();
        BmpModuleDTO Create(BmpModuleDTO dto);

        BmpModuleDTO Update(BmpModuleDTO dto);
        bool Delete(int id);
    }
}
