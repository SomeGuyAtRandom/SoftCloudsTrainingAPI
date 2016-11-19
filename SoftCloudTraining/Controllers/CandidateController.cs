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
    /// created: 2014-11-17 Ray Andrade 
    /// 
    /// updated: 2014-11-18 Ray Andrade 
    /// 
    /// <summary>  
    ///  Purpose: Class created for training exercise.  
    /// </summary>  
    public class CandidateController : ApiController
    {
        /// local database context
        private ICandidateDb db;

        public CandidateController()
        {
            this.db = new CandidateDbCtx();

        }

        /// This constructor is designed to use as a method to inject the database context into a
        /// prodcution, test or development environment
        public CandidateController(ICandidateDb context)
        {
            this.db = context;

        }
        // GET: softclouds/candidate
        /// <summary>
        /// Used to get the complete list of candidates
        /// </summary>
        /// <returns>A List<Candidate> candidates</returns>
        public IEnumerable<Candidate> Get()
        {
            return this.db.Get();
        }

        // GET: softclouds/candidate/5
        /// <summary>
        /// Gets a cadidate object by id
        /// </summary>
        /// <param name="id">used to match the returned object</param>
        /// <returns></returns>
        public Candidate Get(int id)
        {
            return this.db.Get(id); 
        }

        // POST: softclouds/Candidate
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

        // PUT: api/Candidate/{candidate}
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
            catch(Exception ex) 
            {
                if (ex.Message.Equals("Item does not exist to delete."))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
           }
        }
    }
}
