using SoftCloudTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCloudTraining.DAL
{
    interface ICandidateDb
    {
        IEnumerable<Candidate> Get();
        Candidate Get(int id);
        void Insert(Candidate candidate);
        void Delete(int id);
        void Update(Candidate candidate);
        void Save();
    }
}
