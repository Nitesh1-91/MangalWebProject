using MangalWeb.Model;
using MangalWeb.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalWeb.Repository.Repository
{
   public class CityRepository
    {
        MangalDBNewEntities _context = new MangalDBNewEntities();

        public List<tblCityMaster> GetAllCityMaster()
        {
            var list = _context.tblCityMasters.ToList();
            return list;
        }

        public tblCityMaster GetCityMasterById(int Id)
        {
            var tblcity = _context.tblCityMasters.Where(x => x.CityID == Id).FirstOrDefault();
            return tblcity;
        }

        public CityViewModel SetCityMasterDataOnEdit(int Id)
        {
            var tblcity = _context.tblCityMasters.Where(x => x.CityID == Id).FirstOrDefault();
            CityViewModel citymodel = new CityViewModel();
            citymodel.ID =tblcity.CityID;
            citymodel.CityName = tblcity.CityName;
            citymodel.StateId = tblcity.StateID;
            return citymodel;
        }

        public List<tbl_CountryMaster> GetCountryMaster()
        {
            var list = _context.tbl_CountryMaster.ToList();
            return list;
        }

        public List<tblStateMaster> GetStateMaster()
        {
            var list = _context.tblStateMasters.ToList();
            return list;
        }

        public string GetCityNameExists(string CityName)
        {
            var city = _context.tblCityMasters.Where(u => u.CityName ==CityName).Select(x => x.CityName).FirstOrDefault();
            return city;
        }

        public tblCityMaster DeleteCityRecord(int Id)
        {
            var city = _context.tblCityMasters.Where(u => u.CityID == Id).FirstOrDefault();
            if (city != null)
            {
                _context.tblCityMasters.Remove(city);
                _context.SaveChanges();
            }
            return city;
        }

        public bool AddorUpdateRecord(CityViewModel model)
        {
            tblCityMaster tblcity = new tblCityMaster();
            if (model.ID <= 0)
            {
                model.ID = _context.tblCityMasters.Any() ? _context.tblCityMasters.Max(m => m.CityID) + 1 : 1;
                _context.tblCityMasters.Add(tblcity);
                tblcity.CityID = model.ID;
            }
            else
            {
                tblcity = _context.tblCityMasters.Where(x => x.CityID == model.ID).FirstOrDefault();
            }
            tblcity.CityName = model.CityName;
            tblcity.StateID = model.StateId;
            _context.SaveChanges();
            return true;
        }
    }
}
