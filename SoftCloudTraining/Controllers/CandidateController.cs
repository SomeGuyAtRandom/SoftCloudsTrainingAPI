using SoftCloudTraining.DAL;
using SoftCloudTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftCloudTraining.Controllers
{
    public class CandidateController : ApiController
    {
        private ICandidateDb db;

        public CandidateController()
        {
            this.db = new CandidateDbCtx();

        }
        // GET: api/Candidate
        public IEnumerable<Candidate> Get()
        {
            return this.db.Get();
        }

        // GET: api/Candidate/5
        public Candidate Get(int id)
        {
            return this.db.Get(id); 
        }

        // POST: api/Candidate
        public HttpResponseMessage Post([FromBody]Candidate candidate)
        {
            try
            {
                this.db.Insert(candidate);
                var response = Request.CreateResponse(HttpStatusCode.Created, candidate);
                response.Headers.Location = new Uri(Request.RequestUri, string.Format("softclouds/candidate/{0}", candidate.id));
                return response;

            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        // PUT: api/Candidate/5
        public HttpResponseMessage Put(int id, [FromBody]Candidate candidate)
        {
            try
            {
                // For copy to reasons?
                candidate.id = id;
                this.db.Update(candidate);
                var response = Request.CreateResponse(HttpStatusCode.OK, candidate);
                return response;

            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        // DELETE: api/Candidate/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                this.db.Delete(id);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch 
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}
