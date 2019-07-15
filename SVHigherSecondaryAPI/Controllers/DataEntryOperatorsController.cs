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

        // Method : 1 test
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


        // Method : 2
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

        // Method : 3
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

        // Method : 4
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

       
     
    }
}