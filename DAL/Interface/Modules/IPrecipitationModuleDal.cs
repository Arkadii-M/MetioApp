using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPrecipitationModuleDal
    {
        PrecipitationModuleDTO GetByID(int id);
        List<PrecipitationModuleDTO> GetAll();
        PrecipitationModuleDTO Create(PrecipitationModuleDTO dto);

        PrecipitationModuleDTO Update(PrecipitationModuleDTO dto);
        bool Delete(int id);
    
    }
}
