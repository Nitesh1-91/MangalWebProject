using MangalWebProject.Models;
using MangalWebProject.Models.Entity;
using MangalWebProject.Models.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangalWebProject.Controllers
{
    public class ProductRateController : BaseController
    {
        DataManager dd = new DataManager();

        [HttpPost]
        public ActionResult Insert(ProductRateViewModel objViewModel)
        {
            ModelState.Remove("Id");
            if (objViewModel.ID == 0)
            {
                if (InsertData(objViewModel))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(3, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (InsertData(objViewModel))
                {
                    return Json(2, JsonRequestBehavior.AllowGet);
                }
            }
            return View("ProductRate", objViewModel);
        }

        #region Insert Data

        public bool InsertData(ProductRateViewModel productratevm)
        {
            bool retVal = false;
            productratevm.CreatedBy = Convert.ToInt32(Session["UserLoginId"]);
            productratevm.UpdatedBy = Convert.ToInt32(Session["UserLoginId"]);
            Mst_ProductRate tblProductRate = new Mst_ProductRate();
            Mst_ProductRateDetails tblProductRateDetails = new Mst_ProductRateDetails();
            try
            {
                if (productratevm.ID <= 0)
                {
                    tblProductRate.Pr_Date = Convert.ToDateTime(productratevm.ProductRateDate);
                    tblProductRate.Pr_Product = productratevm.Product;
                    tblProductRate.Pr_RecordCreated = DateTime.Now;
                    tblProductRate.Pr_RecordCreatedBy = productratevm.CreatedBy;
                    tblProductRate.Pr_RecordUpdated = DateTime.Now;
                    tblProductRate.Pr_RecordUpdatedBy = productratevm.UpdatedBy;
                    dd._context.Mst_ProductRate.Add(tblProductRate);
                    dd._context.SaveChanges();

                    int PID = dd._context.Mst_ProductRate.Max(x => x.Pr_Id);

                    foreach (var p in productratevm.ProductRateList)
                    {

                        var prdrate = new Mst_ProductRateDetails
                        {
                            Prd_FkId = PID,
                            Prd_Purity = p.Purity,
                            Prd_GrossRate = p.GrossRate,
                            Prd_Deductions = p.DeductionsType,
                            Prd_DeductionsAmount = p.DeductionAmount,
                            Prd_NetRate = p.NetRate,
                            Prd_RecordCreatedBy = Convert.ToInt32(Session["UserLoginId"]),
                            Prd_RecordCreated = DateTime.Now,
                            Prd_RecordUpdatedBy = Convert.ToInt32(Session["UserLoginId"]),
                            Prd_RecordUpdated = DateTime.Now,
                        };
                        dd._context.Mst_ProductRateDetails.Add(prdrate);
                        dd._context.SaveChanges();
                    }
                }
                else
                {
                    //update the data in Charge Details table
                    var productObj = dd._context.Mst_ProductRate.Where(x => x.Pr_Id == productratevm.ID).FirstOrDefault();
                    //update the data in product rate table
                    productObj.Pr_Date = Convert.ToDateTime(productratevm.ProductRateDate);
                    productObj.Pr_Product = productratevm.Product;
                    productObj.Pr_RecordUpdatedBy = Convert.ToInt32(Session["UserLoginId"]);
                    productObj.Pr_RecordUpdated = DateTime.Now;

                    List<Mst_ProductRateDetails> NewProductRateList = new List<Mst_ProductRateDetails>();

                    //update the data in Charge Details table
                    foreach (var p in productratevm.ProductRateList)
                    {
                        var FindRateobject = dd._context.Mst_ProductRateDetails.Where(x => x.Prd_Id == p.ID && x.Prd_FkId == productratevm.ID).FirstOrDefault();
                        if (FindRateobject == null)
                        {
                            var ratetrnnew = new Mst_ProductRateDetails
                            {
                                Prd_FkId = productratevm.ID,
                                Prd_Purity = p.Purity,
                                Prd_GrossRate = p.GrossRate,
                                Prd_Deductions = p.DeductionsType,
                                Prd_DeductionsAmount = p.DeductionAmount,
                                Prd_NetRate = p.NetRate,
                                Prd_RecordCreated = DateTime.Now,
                                Prd_RecordCreatedBy = Convert.ToInt32(Session["UserLoginId"]),
                                Prd_RecordUpdatedBy = Convert.ToInt32(Session["UserLoginId"]),
                                Prd_RecordUpdated = DateTime.Now
                            };
                            dd._context.Mst_ProductRateDetails.Add(ratetrnnew);
                        }
                        else
                        {
                            FindRateobject.Prd_Purity = p.Purity;
                            FindRateobject.Prd_GrossRate = p.GrossRate;
                            FindRateobject.Prd_Deductions = p.DeductionsType;
                            FindRateobject.Prd_DeductionsAmount = p.DeductionAmount;
                            FindRateobject.Prd_NetRate = p.NetRate;
                            FindRateobject.Prd_RecordUpdatedBy = Convert.ToInt32(Session["UserLoginId"]);
                            FindRateobject.Prd_RecordUpdated = DateTime.Now;
                        }
                        NewProductRateList.Add(FindRateobject);
                    }
                    #region product rate details remove
                    //take the loop of table and check from list if found in list then not remove else remove from table itself
                    var trnobjlist = dd._context.Mst_ProductRateDetails.Where(x => x.Prd_FkId == productratevm.ID).ToList();
                    if (trnobjlist != null)
                    {
                        foreach (Mst_ProductRateDetails item in trnobjlist)
                        {
                            if (NewProductRateList.Contains(item))
                            {
                                continue;
                            }
                            else
                            {
                                dd._context.Mst_ProductRateDetails.Remove(item);
                            }
                        }
                        dd._context.SaveChanges();
                    }
                    #endregion product trn remove
                }
                retVal = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }

        #endregion Insert Data

        public ActionResult GetProductRateById(int ID)
        {
            string operation = Session["Operation"].ToString();
            ButtonVisiblity(operation);
            var productRatevm = new ProductRateViewModel();
            var Productrate = dd._context.Mst_ProductRate.Where(x => x.Pr_Id == ID).FirstOrDefault();
            productRatevm.ProductRateDate = Productrate.Pr_Date.ToShortDateString();
            var Producttrndatalist = dd._context.Mst_ProductRateDetails.Where(x => x.Prd_FkId == ID).ToList();
            ViewBag.PurityList = new SelectList(dd._context.Mst_PurityMaster.Where(x=>x.PurityType==Productrate.Pr_Product).ToList(), "Id", "PurityName");
            productRatevm = ToViewModelProductRate(Productrate, Producttrndatalist);
            return View("ProductRate", productRatevm);
        }

        public ProductRateViewModel ToViewModelProductRate(Mst_ProductRate product, ICollection<Mst_ProductRateDetails> ProductTrnList)
        {
            var rateviewmodel = new ProductRateViewModel
            {
                Product = product.Pr_Product,
                ProductRateDate = product.Pr_Date.ToShortDateString(),
                ID = product.Pr_Id,
            };
            List<ProductRateDetailsVM> ProductTrnViewModelList = new List<ProductRateDetailsVM>();
            foreach (var c in ProductTrnList)
            {
                var rateTrnViewModel = new ProductRateDetailsVM();
                rateTrnViewModel.ID = c.Prd_Id;
                rateTrnViewModel.Purity = c.Prd_Purity;
                var puritystr = dd._context.Mst_PurityMaster.Where(x => x.id == c.Prd_Purity).Select(x => x.PurityName).FirstOrDefault();
                rateTrnViewModel.PurityStr = puritystr;
                rateTrnViewModel.GrossRate = c.Prd_GrossRate;
                rateTrnViewModel.DeductionsType = c.Prd_Deductions;
                rateTrnViewModel.DeductionTypeStr = c.Prd_Deductions == 1 ? "Amount" : "Diamond";
                rateTrnViewModel.DeductionAmount = c.Prd_DeductionsAmount;
                rateTrnViewModel.NetRate = c.Prd_NetRate;
                ProductTrnViewModelList.Add(rateTrnViewModel);
            }
            rateviewmodel.ProductRateList = ProductTrnViewModelList;
            return rateviewmodel;
        }



        // GETDelete/5
        public ActionResult Delete(int id)
        {
            var ratetrndata = dd._context.Mst_ProductRateDetails.Where(x => x.Prd_FkId == id).ToList();
            //Delete the data from Installation Type Data
            if (ratetrndata != null)
            {
                foreach (var ratetrn in ratetrndata)
                {
                    dd._context.Mst_ProductRateDetails.Remove(ratetrn);
                }
                dd._context.SaveChanges();
            }
            var deleterecord = dd._context.Mst_ProductRate.Where(x => x.Pr_Id == id).FirstOrDefault();
            if (deleterecord != null)
            {
                dd._context.Mst_ProductRate.Remove(deleterecord);
                dd._context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductRate()
        {
            ButtonVisiblity("Index");
            var model = new ProductRateViewModel();
            model.ProductRateList = new List<ProductRateDetailsVM>();
            ViewBag.PurityList = new SelectList(dd._context.Mst_PurityMaster.ToList(), "Id", "PurityName");
            return View(model);
        }

        public JsonResult GetPurity(int id)
        {
            var data = new SelectList(dd._context.Mst_PurityMaster.Where(x => x.PurityType == id).ToList(), "Id", "PurityName");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductRateTable(string Operation)
        {
            Session["Operation"] = Operation;
            var model = new ProductRateViewModel();
            List<ProductRateViewModel> list = new List<ProductRateViewModel>();
            var tablelist = dd._context.Mst_ProductRate.ToList();
            foreach (var item in tablelist)
            {
                model = new ProductRateViewModel();
                model.ID = item.Pr_Id;
                model.ProductRateDate = item.Pr_Date.ToShortDateString();
                model.ProductStr = item.Pr_Product == 1 ? "Gold" : "Diamond";
                list.Add(model);
            }
            return PartialView("_ProductRateList", list);
        }
    }
}
