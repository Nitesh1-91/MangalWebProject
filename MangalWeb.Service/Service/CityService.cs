using MangalWeb.Model;
using MangalWeb.Model.Entity;
using MangalWeb.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalWeb.Service.Service
{
   public class CityService
    {
        CityRepository _cityRepository = new CityRepository();

        public List<tblCityMaster> GetCityMaster()
        {
            var list = _cityRepository.GetAllCityMaster();
            return list;
        }

        public CityViewModel SetCityMasterDataOnEdit(int Id)
        {
            var state = _cityRepository.SetCityMasterDataOnEdit(Id);
            return state;
        }

        public List<tbl_CountryMaster> GetCountryMasterList()
        {
            var countrylist = _cityRepository.GetCountryMaster();
            return countrylist;
        }

        public List<tblStateMaster> GetStateMasterList()
        {
            var countrylist = _cityRepository.GetStateMaster();
            return countrylist;
        }

        public string StateNameExists(string Name)
        {
            var cityname = _cityRepository.GetCityNameExists(Name);
            return cityname;
        }

        public tblCityMaster DeleteCityRecord(int Id)
        {
            var tblcity = _cityRepository.DeleteCityRecord(Id);
            return tblcity;
        }

        public bool SaveRecord(CityViewModel model)
        {
            var city = _cityRepository.AddorUpdateRecord(model);
            return city;
        }
    }
}
