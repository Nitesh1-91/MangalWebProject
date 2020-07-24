using MangalWebProject.Models;
using MangalWebProject.Models.Entity;
using MangalWebProject.Models.EntityManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangalWebProject.Controllers
{
    public class DocumentUploadController : BaseController
    {
        #region Constructor

        DataManager dd = new DataManager();

        #endregion

        #region DocumentUpload
        // GET: DocumentUpload
        public ActionResult DocumentUpload()
        {
            ButtonVisiblity("Index");
            var model = new DocumentUploadViewModel();
            model.DocumentUploadList = new List<DocumentUploadViewModel>();
            ViewBag.DocumentTypeList = new SelectList(dd._context.Mst_DocumentType.ToList(), "Id", "Name");
            ViewBag.DocumentList = new SelectList(dd._context.Mst_DocumentMaster.ToList(), "Doc_Id", "Doc_DocumentName");
            var transactionid = dd._context.Trn_DocumentUpload.Any() ? dd._context.Trn_DocumentUpload.Max(x => x.TransactionId) + 1 : 1;
            model.TransactionNumber = "D0000" + transactionid;
            model.DocDate = DateTime.Now.ToShortDateString();
            return View(model);
        }
        #endregion

        #region GetCustomerDetails

        public ActionResult GetCustomerDetails()
        {
            return PartialView("_CustomerDetails", dd._context.Trans_KYCDetails.ToList());
        }

        #endregion GetCustomerDetails

        #region GetCustomerById

        public ActionResult GetCustomerById(int KycId)
        {
            try
            {
                ButtonVisiblity("Index");
                var tblkyc = dd._context.Trans_KYCDetails.Where(x => x.ID == KycId).FirstOrDefault();
                var model = new DocumentUploadViewModel();
                model.CustomerId = tblkyc.CustomerID;
                model.ApplicationNo = tblkyc.ApplicationNo;
                model.LoanAccountNo = "1";
                ViewBag.DocumentTypeList = new SelectList(dd._context.Mst_DocumentType.ToList(), "Id", "Name");
                ViewBag.DocumentList = new SelectList(dd._context.Mst_DocumentMaster.ToList(), "Doc_Id", "Doc_DocumentName");
                model.DocumentUploadList = new List<DocumentUploadViewModel>();
                var transactionid = dd._context.Trn_DocumentUpload.Any() ? dd._context.Trn_DocumentUpload.Max(x => x.TransactionId) + 1 : 1;
                model.TransactionNumber = "D0000" + transactionid;
                model.DocDate = DateTime.Now.ToShortDateString();
                return View("DocumentUpload", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion GetCustomerById

        #region Insert

        [HttpPost]
        public ActionResult Insert(DocumentUploadViewModel objViewModel)
        {
            try
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
                objViewModel.DocumentUploadList = new List<DocumentUploadViewModel>();
                ViewBag.DocumentTypeList = new SelectList(dd._context.Mst_DocumentType.ToList(), "Id", "Name");
                ViewBag.DocumentList = new SelectList(dd._context.Mst_DocumentMaster.ToList(), "Doc_Id", "Doc_DocumentName");
                return View("DocumentUpload", objViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Insert

        #region Insert Data

        public bool InsertData(DocumentUploadViewModel DocUploadViewModel)
        {
            bool retVal = false;
            DocUploadViewModel.CreatedBy = Convert.ToInt32(Session["UserLoginId"]);
            DocUploadViewModel.UpdatedBy = Convert.ToInt32(Session["UserLoginId"]);
            Trn_DocumentUpload tblDocUpload = new Trn_DocumentUpload();
            try
            {
                //chargeViewModel.DocumentUploadList =(List<DocumentUploadViewModel>)Session["DocumentUploadList"];
                //save the data in Document Upload Details table
                foreach (var p in DocUploadViewModel.DocumentUploadList)
                {
                    //Stream fs = p.UploadedFile.InputStream;
                    //BinaryReader br = new BinaryReader(fs);
                    //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    //Image1.ImageUrl = "data:image/png;base64," + base64String;
                    int trnasid =Convert.ToInt32(DocUploadViewModel.TransactionNumber);
                    var docuptrn = new Trn_DocumentUpload
                    {
                        TransactionId = 1,
                        TransactionNumber = DocUploadViewModel.TransactionNumber,
                        DocDate =Convert.ToDateTime(DocUploadViewModel.DocDate),
                        CustomerId = DocUploadViewModel.CustomerId,
                        ApplicationNo = DocUploadViewModel.ApplicationNo,
                        LoanAccountNo = DocUploadViewModel.LoanAccountNo,
                        DocumentTypeId = p.DocumentTypeId,
                        DocumentId = p.DocumentId,
                        ExpiryDate=Convert.ToDateTime(p.ExpiryDate),
                        //UploadDocName= bytes,
                        Comments = DocUploadViewModel.Comments,
                        BranchId=1,
                        FinancialYearId=1,
                        CompId=1,
                        Status ="P",
                        RecordCreatedBy = Convert.ToInt32(Session["UserLoginId"]),
                        RecordCreated = DateTime.Now,
                        RecordUpdatedBy = Convert.ToInt32(Session["UserLoginId"]),
                        RecordUpdated = DateTime.Now,
                    };
                    dd._context.Trn_DocumentUpload.Add(docuptrn);
                    dd._context.SaveChanges();
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

        #region GetDcoument
        public JsonResult GetDcoument(int id)
        {
            var data = new SelectList(dd._context.Mst_DocumentMaster.Where(x => x.Doc_DocumentType == id).ToList(), "Doc_Id", "Doc_DocumentName");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult GetDocUploadTable(string Operation)
        {
            Session["Operation"] = Operation;
            ButtonVisiblity(Operation);
            List<DocumentUploadViewModel> list = new List<DocumentUploadViewModel>();
            var model = new DocumentUploadViewModel();
            var tablelist = dd._context.Trn_DocumentUpload.ToList().Select(x=>x);
            foreach (var item in tablelist)
            {
                model = new DocumentUploadViewModel();
                model.ID = item.TransactionId;
                model.TransactionId = item.TransactionId;
                model.TransactionNumber = item.TransactionNumber;
                model.DocDate =Convert.ToDateTime(item.DocDate).ToShortDateString();
                model.ApplicationNo = item.ApplicationNo;
                model.CustomerId = item.CustomerId;
                model.LoanAccountNo = item.LoanAccountNo;
                list.Add(model);
            }
            return PartialView("_DocumentUploadList", list);
        }

        #region GetDocUploadDetailsById

        public ActionResult GetDocUploadDetailsById(int ID)
        {
            try
            {
                DocumentUploadViewModel documentUploadViewModel = new DocumentUploadViewModel();
                string operation = Session["Operation"].ToString();
                //get document upload table
                var purchasetrndatalist = dd._context.Trn_DocumentUpload.Where(x => x.TransactionId == ID).ToList();
                documentUploadViewModel = ToViewModelDocUpload(purchasetrndatalist);
                documentUploadViewModel.operation = operation;
                ViewBag.DocumentTypeList = new SelectList(dd._context.Mst_DocumentType.ToList(), "Id", "Name");
                ViewBag.DocumentList = new SelectList(dd._context.Mst_DocumentMaster.ToList(), "Doc_Id", "Doc_DocumentName");
                return View("DocumentUpload", documentUploadViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion GetDocUploadDetailsById

        #region ToViewModelDocUpload
        public DocumentUploadViewModel ToViewModelDocUpload(List<Trn_DocumentUpload> DocUploadTrnList)
        {
            var model = new DocumentUploadViewModel
            {
                TransactionNumber = DocUploadTrnList[0].TransactionNumber,
                DocDate =Convert.ToDateTime(DocUploadTrnList[0].DocDate).ToShortDateString(),
                CustomerId = DocUploadTrnList[0].CustomerId,
                ApplicationNo = DocUploadTrnList[0].ApplicationNo,
                LoanAccountNo = DocUploadTrnList[0].LoanAccountNo,
                ID = DocUploadTrnList[0].TransactionId,
            };

            List<DocumentUploadViewModel> DocTrnViewModelList = new List<DocumentUploadViewModel>();
            foreach (var c in DocUploadTrnList)
            {
                var TrnViewModel = new DocumentUploadViewModel
                {
                    DocumentTypeId =(int)c.DocumentTypeId,
                    DocumentTypeName=dd._context.Mst_DocumentType.Where(x=>x.Id==c.DocumentTypeId).Select(x=>x.Name).FirstOrDefault(),
                    DocumentName = dd._context.Mst_DocumentMaster.Where(x => x.Doc_Id == c.DocumentId).Select(x => x.Doc_DocumentName).FirstOrDefault(),
                    DocumentId = (int)c.DocumentId,
                    ExpiryDate =Convert.ToDateTime(c.ExpiryDate).ToShortDateString(),
                    UploadDocName =c.FileName,
                };
                DocTrnViewModelList.Add(TrnViewModel);
            }
            model.DocumentUploadList = DocTrnViewModelList;
            return model;
        }
        #endregion

        #region Delete

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                var trndata = dd._context.Trn_DocumentUpload.Where(x => x.TransactionId == id).ToList();
                //Delete the data from Installation Type Data
                if (trndata != null)
                {
                    foreach (var doctrn in trndata)
                    {
                        dd._context.Trn_DocumentUpload.Remove(doctrn);
                    }
                    dd._context.SaveChanges();
                }
                return Json(JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Delete

    }
}