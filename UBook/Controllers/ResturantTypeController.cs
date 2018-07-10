using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UBook.Models;

namespace UBook.Controllers
{
   
 
    public class ResturantTypeController : ApiController
    {
        private IBucket _bucket;

        public ResturantTypeController()
        {
            _bucket = ClusterHelper.GetBucket("UBook");
        }


        [HttpGet]
        [Route("api/ResturantType/getall")]
        public IHttpActionResult GetAll()
        {
            var n1ql = @"select g.* , meta(g).id from UBook g where g.type='ResturantType';";

            var query = QueryRequest.Create(n1ql);
            query.ScanConsistency(ScanConsistency.RequestPlus);
            var result = _bucket.Query<ResturantType>(query);
            return Ok(result.Rows);
        }

        [HttpGet]
        [Route("api/ResturantType/get/{id}")]
        public IHttpActionResult Get(Guid id)
        {

            var result = _bucket.Get<ResturantType>(id.ToString());
            return Ok(result.Value);
        }


        [HttpPost]
        [Route("api/ResturantType/edit")]
        public IHttpActionResult Edit(ResturantType item)
        {

            if (!item.Id.HasValue)
                item.Id = Guid.NewGuid();

            _bucket.Upsert(item.Id.ToString(), new
            {
                Name = item.Name,
                Type = item.Type
            });
            return Ok(item);
        }


        [HttpDelete]
        [Route("api/ResturantType/delete/{id}")]
        public IHttpActionResult delete(Guid id)
        {
            _bucket.Remove(id.ToString());
            return Ok(id);
        }
    }
}