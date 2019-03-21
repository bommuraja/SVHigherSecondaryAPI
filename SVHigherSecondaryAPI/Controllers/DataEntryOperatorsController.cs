using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SVHigherSecondaryAPI.Models;

namespace SVHigherSecondaryAPI.Controllers
{
    public class DataEntryOperatorsController : ApiController
    {
        private SVEntitiesDataModel db = new SVEntitiesDataModel();

        //1 GET: api/DataEntryOperators
        public List<DataEntryOperatorBE> GetDataEntryOperators()
        {
            List<DataEntryOperatorBE> objBEList = new List<DataEntryOperatorBE>();
            foreach (var item in db.DataEntryOperators)
            {
                objBEList.Add(
                    new DataEntryOperatorBE
                    {
                        DataEntryOperatorID = item.DataEntryOperatorID,
                        DataEntryOperatorName = item.DataEntryOperatorName,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy
                    }
                );
            }
            return objBEList;
        }     

        //2 GET: api/DataEntryOperators/5
        [Route("api/Operators/{id}")]
        public List<DataEntryOperatorBE> GetDataEntryOperators(int id)
        {
            List<DataEntryOperatorBE> objBEList = new List<DataEntryOperatorBE>();
            foreach (var item in db.DataEntryOperators)
            {
                objBEList.Add(
                    new DataEntryOperatorBE
                    {
                        DataEntryOperatorID = item.DataEntryOperatorID,
                        DataEntryOperatorName = item.DataEntryOperatorName,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy
                    }
                );
            }
            return objBEList;
        }

        //3
        [Route("api/DropOperator/{id}")]
        public bool GetRemoveOperatorDetails(int id)
        {
            DataEntryOperator dataEntryOperator = db.DataEntryOperators.Find(id);
            if (dataEntryOperator == null)
            {
                return false;
            }
            try
            {
                db.DataEntryOperators.Remove(dataEntryOperator);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        //4 GET: api/DataEntryOperators/5
        [ResponseType(typeof(DataEntryOperator))]
        public DataEntryOperatorBE GetDataEntryOperator(int id)
        {
            DataEntryOperator dataEntryOperator = db.DataEntryOperators.Find(id);
            DataEntryOperatorBE objBE = new DataEntryOperatorBE();
            if (dataEntryOperator != null)
            {
                objBE = new DataEntryOperatorBE
                {
                    DataEntryOperatorID = dataEntryOperator.DataEntryOperatorID,
                    DataEntryOperatorName = dataEntryOperator.DataEntryOperatorName,
                    CreatedDate = dataEntryOperator.CreatedDate,
                    CreatedBy = dataEntryOperator.CreatedBy
                };
            }
            return objBE;
        }

        //5 POST: api/DataEntryOperators
        [ResponseType(typeof(DataEntryOperatorBE))]
        public IHttpActionResult PostDataEntryOperator(DataEntryOperatorBE dataEntryOperator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dataEntryOperator.DataEntryOperatorID > 0)
            {
                DataEntryOperator objDE = db.DataEntryOperators.Find(dataEntryOperator.DataEntryOperatorID);

                objDE.DataEntryOperatorName = dataEntryOperator.DataEntryOperatorName;
                objDE.CreatedBy = dataEntryOperator.CreatedBy;
                objDE.CreatedDate = dataEntryOperator.CreatedDate;
                db.SaveChanges();
               
            }
            else
            {
                DataEntryOperator objDE = new DataEntryOperator
                {
                    DataEntryOperatorName = dataEntryOperator.DataEntryOperatorName,
                    CreatedDate = dataEntryOperator.CreatedDate,
                    CreatedBy = dataEntryOperator.CreatedBy
                };
                db.DataEntryOperators.Add(objDE);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = dataEntryOperator.DataEntryOperatorID }, dataEntryOperator);
        }

        //6 DELETE: api/DataEntryOperators/5
        [ResponseType(typeof(DataEntryOperatorBE))]
        public IHttpActionResult DeleteDataEntryOperator(int id)
        {
            DataEntryOperator dataEntryOperator = db.DataEntryOperators.Find(id);
            if (dataEntryOperator == null)
            {
                return NotFound();
            }

            db.DataEntryOperators.Remove(dataEntryOperator);
            db.SaveChanges();

            DataEntryOperatorBE objBE = new DataEntryOperatorBE
            {
                DataEntryOperatorID = dataEntryOperator.DataEntryOperatorID,
                DataEntryOperatorName = dataEntryOperator.DataEntryOperatorName,
                CreatedBy = dataEntryOperator.CreatedBy,
                CreatedDate = dataEntryOperator.CreatedDate
            };

            return Ok(objBE);
        }

        //7
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //8
        private bool DataEntryOperatorExists(int id)
        {
            return db.DataEntryOperators.Count(e => e.DataEntryOperatorID == id) > 0;
        }
    }
}