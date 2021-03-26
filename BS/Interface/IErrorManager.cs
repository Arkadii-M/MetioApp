using DTO.MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Interface
{
    interface IErrorManager
    {
        bool HasAnyError();

        void AddError(ErrorDTO error);

        ErrorDTO GetLastError();

        ErrorDTO GetErrorById(int id);
    }
}
