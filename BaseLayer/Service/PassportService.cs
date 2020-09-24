using BaseLayer.DTO;
using BaseLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Service
{
    public class PassportService
    {
        public int CheckPassport(string passportNumber)
        {
            var passportRepository = new PassportRepository();
            return passportRepository.CheckPassport(passportNumber);
        }

        public PassportModel GetPassportData(string passportNumber)
        {
            var passportRepository = new PassportRepository();
            return passportRepository.GetPassportData(passportNumber);
        }
    }
}
