using MangalWeb.Model;
using MangalWeb.Service;
using MangalWeb.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangalWeb.Controllers
{
    public class StateController : BaseController
    {
        StateService _stateService = new StateService();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateEdit(StateViewModel state)
        {
            state.CreatedBy = Convert.ToInt32(Session["UserLoginId"]);
            state.UpdatedBy = Convert.ToInt32(Session["UserLoginId"]);
            try
            {
                if (state.ID <= 0)
                {
                    var data = _stateService.StateNameExists(state.StateName);
                    if (data != null)
                    {
                        ModelState.AddModelError("StateName", "State Name Already Exists");
                        return Json(state);
                    }
                    _stateService.SaveRecord(state);
                }
                else
                {
                    _stateService.SaveRecord(state);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Json(state);
        }


        public ActionResult GetStateById(int ID)
        {
            string operation = Session["Operation"].ToString();
            ButtonVisiblity(operation);
            var state = new StateViewModel();
            state = _stateService.SetStateMasterDataOnEdit(ID);
            state.operation = operation;
            ViewBag.CountryList = new SelectList(_stateService.GetCountryMasterList(), "CountryID", "CountryName");
            return View("State", state);
        }

        #region Delete
        // GETDelete/5
        public ActionResult Delete(int id)
        {
            string data = "";
            if (_stateService.CheckStateExistinCity(id) > 0)
            {
                data = "Record Cannot Be Deleted Already In Use!";

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var deleterecord = _stateService.DeleteStateRecord(id);
                return Json(JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region doesStateNameExist
        public JsonResult doesStateNameExist(string StateName)
        {
            var data = _stateService.StateNameExists(StateName);
            var result = "";
            //Check if state name already exists
            if (data != null)
            {
                if (StateName.ToLower() == data.ToLower().ToString())
                {
                    result = "State Name Already Exists";
                }
                else
                {
                    result = "";
                }
            }
            return Json(result);
        }
        #endregion

        #region State
        public ActionResult State()
        {
            ButtonVisiblity("Index");
            var model = new StateViewModel();
            ViewBag.CountryList = new SelectList(_stateService.GetCountryMasterList(), "CountryID", "CountryName");
            return View(model);
        }
        #endregion

        #region GetStateTable
        public ActionResult GetStateTable(string Operation)
        {
            Session["Operation"] = Operation;
            //ButtonVisiblity(Operation);
            return PartialView("_StateList", _stateService.GetStateMaster());
        }
        #endregion
    }
}