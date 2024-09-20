using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Operations
{
    /// <summary>
    /// Получение данных для пациента
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IPatientDataOperation<T>
    {
        Task<T> GetByPatient(int patientId);
    }
}
