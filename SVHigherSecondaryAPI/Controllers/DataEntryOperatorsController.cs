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

        // GET: api/DataEntryOperators
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

        // GET: api/DataEntryOperators/5
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

        // GET: api/DataEntryOperators/5
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


        // PUT: api/DataEntryOperators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDataEntryOperator(int id, DataEntryOperatorBE dataEntryOperator)
        {
           
            if (id != dataEntryOperator.DataEntryOperatorID)
            {
                return BadRequest();
            }

            DataEntryOperator objDE = db.DataEntryOperators.Find(id);

            objDE.DataEntryOperatorName = dataEntryOperator.DataEntryOperatorName;
            objDE.CreatedBy = dataEntryOperator.CreatedBy;
            objDE.CreatedDate = dataEntryOperator.CreatedDate;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataEntryOperatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DataEntryOperators
        [ResponseType(typeof(DataEntryOperatorBE))]
        public IHttpActionResult PostDataEntryOperator(DataEntryOperatorBE dataEntryOperator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DataEntryOperator objDE = new DataEntryOperator
            {
                DataEntryOperatorName = dataEntryOperator.DataEntryOperatorName,
                CreatedDate = dataEntryOperator.CreatedDate,
                CreatedBy = dataEntryOperator.CreatedBy
            };
            db.DataEntryOperators.Add(objDE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dataEntryOperator.DataEntryOperatorID }, dataEntryOperator);
        }

        // DELETE: api/DataEntryOperators/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataEntryOperatorExists(int id)
        {
            return db.DataEntryOperators.Count(e => e.DataEntryOperatorID == id) > 0;
        }
    }
}