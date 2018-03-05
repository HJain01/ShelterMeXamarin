using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterMeDataAccess;

namespace ShelterMeBusinessLogic {
    public class ShelterInfoService {
        public List<string> getShelterInformation(string shelterName) {
            ShelterInfoData shelterInfo = new ShelterInfoData();
            List<string> shelterData = new List<string>();
            shelterData = shelterInfo.getShelterInformation(shelterName);
            return shelterData;
        }
    }
}
