using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Interfaces
{
    public interface IThreeDalModelsConvertToDTO<DTOModel, DALModelOne, DALModelTwo, DALModelThree>
    {
        public DTOModel CovnertToDTO(DALModelOne modelOne, DALModelTwo modelTwo, DALModelThree modelThree);
    }
}
