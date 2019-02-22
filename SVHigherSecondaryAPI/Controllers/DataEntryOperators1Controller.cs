using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SVHigherSecondaryAPI.Models;

namespace SVHigherSecondaryAPI.Controllers
{
    public class DataEntryOperators1Controller : ApiController
    {
        private SVEntitiesDataModel db = new SVEntitiesDataModel();

        // GET: api/DataEntryOperators1
        public IQueryable<DataEntryOperator> GetDataEntryOperators()
        {
            return db.DataEntryOperators;
        }

        // GET: api/DataEntryOperators1/5
        [ResponseType(typeof(DataEntryOperator))]
        public async Task<IHttpActionResult> GetDataEntryOperator(int id)
        {
            DataEntryOperator dataEntryOperator = await db.DataEntryOperators.FindAsync(id);
            if (dataEntryOperator == null)
            {
                return NotFound();
            }

            return Ok(dataEntryOperator);
        }

        // PUT: api/DataEntryOperators1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDataEntryOperator(int id, DataEntryOperator dataEntryOperator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataEntryOperator.DataEntryOperatorID)
            {
                return BadRequest();
            }

            db.Entry(dataEntryOperator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

        // POST: api/DataEntryOperators1
        [ResponseType(typeof(DataEntryOperator))]
        public async Task<IHttpActionResult> PostDataEntryOperator(DataEntryOperator dataEntryOperator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DataEntryOperators.Add(dataEntryOperator);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dataEntryOperator.DataEntryOperatorID }, dataEntryOperator);
        }

        // DELETE: api/DataEntryOperators1/5
        [ResponseType(typeof(DataEntryOperator))]
        public async Task<IHttpActionResult> DeleteDataEntryOperator(int id)
        {
            DataEntryOperator dataEntryOperator = await db.DataEntryOperators.FindAsync(id);
            if (dataEntryOperator == null)
            {
                return NotFound();
            }

            db.DataEntryOperators.Remove(dataEntryOperator);
            await db.SaveChangesAsync();

            return Ok(dataEntryOperator);
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