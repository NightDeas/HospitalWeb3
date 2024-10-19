using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Interfaces
{
    public interface IModelSingleConvert<DTOModel, DALModel>
    {
        public DALModel ConvertToDAL(DTOModel model);
        public DTOModel ConvertToDTO(DALModel model);
    }
}
