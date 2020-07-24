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
    public class StateService
    {
        StateRepository _stateRepository = new StateRepository();

        public List<tblStateMaster> GetStateMaster()
        {
            var list = _stateRepository.GetAllStateMaster();
            return list;
        }

        public StateViewModel SetStateMasterDataOnEdit(int Id)
        {
            var state = _stateRepository.SetStateMasterDataOnEdit(Id);
            return state;
        }

        public List<tbl_CountryMaster> GetCountryMasterList()
        {
            var countrylist = _stateRepository.GetCountryMaster();
            return countrylist;
        }

        public string StateNameExists(string Name)
        {
            var statename = _stateRepository.GetStateNameExists(Name);
            return statename;
        }

        public tblStateMaster DeleteStateRecord(int Id)
        {
            var tblstate = _stateRepository.DeleteStateRecord(Id);
            return tblstate;
        }

        public int CheckStateExistinCity(int StateId)
        {
            int stateid = _stateRepository.GetCityNameExists(StateId);
            return stateid;
        }

        public int StateViewModel(int StateId)
        {
            int stateid = _stateRepository.GetCityNameExists(StateId);
            return stateid;
        }

        public bool SaveRecord(StateViewModel model)
        {
            var countrylist = _stateRepository.AddorUpdateRecord(model);
            return countrylist;
        }

    }
}
