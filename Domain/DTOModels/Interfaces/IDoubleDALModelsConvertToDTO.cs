using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Interfaces
{
    public interface IDoubleDALModelsConvertToDTO<DTOModelOne, DALModelOne, DALModelTwo>
    {
        public DTOModelOne ConvertToDTO(DALModelOne modelOne, DALModelTwo modelTwo);
    }
}
