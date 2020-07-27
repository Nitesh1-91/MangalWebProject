using MangalWeb.Model;
using MangalWeb.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalWeb.Repository.Repository
{
    public class StateRepository
    {
        MangalDBNewEntities _context = new MangalDBNewEntities();

        public List<tblStateMaster> GetAllStateMaster()
        {
            var list = _context.tblStateMasters.ToList();
            return list;
        }

        public tblStateMaster GetStateMasterById(int Id)
        {
            var tblstate = _context.tblStateMasters.Where(x => x.StateID == Id).FirstOrDefault();
            return tblstate;
        }

        public StateViewModel SetStateMasterDataOnEdit(int Id)
        {
            var tblstate = _context.tblStateMasters.Where(x=>x.StateID==Id).FirstOrDefault();
            StateViewModel statemodel = new StateViewModel();
            statemodel.ID = tblstate.StateID;
            statemodel.StateCode = tblstate.StateCode;
            statemodel.StateName = tblstate.StateName;
            statemodel.CountryId = tblstate.countryID;
            return statemodel;
        }

        public List<tbl_CountryMaster> GetCountryMaster()
        {
            var list = _context.tbl_CountryMaster.ToList();
            return list;
        }

        public string GetStateNameExists(string StateName)
        {
            var state = _context.tblStateMasters.Where(u => u.StateName == StateName).Select(x => x.StateName).FirstOrDefault();
            return state;
        }

        public tblStateMaster DeleteStateRecord(int Id)
        {
            var state = _context.tblStateMasters.Where(u => u.StateID == Id).FirstOrDefault();
            if(state!=null)
            {
                _context.tblStateMasters.Remove(state);
                _context.SaveChanges();
            }
            return state;
        }

        public int GetCityNameExists(int StateId)
        {
            var stateid = _context.tblCityMasters.Where(u => u.StateID == StateId).Select(x => x.StateID).FirstOrDefault();
            return stateid;
        }

        public bool AddorUpdateRecord(StateViewModel model)
        {
            tblStateMaster tblstate = new tblStateMaster();
            if (model.ID <= 0)
            {
                model.ID = _context.tblStateMasters.Any() ? _context.tblStateMasters.Max(m => m.StateID) + 1 : 1;
                _context.tblStateMasters.Add(tblstate);
                tblstate.StateID = model.ID;
            }
            else
            {
                tblstate = _context.tblStateMasters.Where(x => x.StateID == model.ID).FirstOrDefault();
            }
            tblstate.StateCode = model.StateCode;
            tblstate.StateName = model.StateName;
            tblstate.countryID = model.CountryId;
            _context.SaveChanges();
            return true;
        }
    }
}