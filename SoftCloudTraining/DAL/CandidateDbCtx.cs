using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftCloudTraining.Models;

namespace SoftCloudTraining.DAL
{
    public class CandidateDbCtx : ICandidateDb
    {
        private static List<Candidate>candidates = new List<Candidate>();
        static int nextId = 1;
        
        static CandidateDbCtx()
        {
            Candidate c1 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 1", phone = "(800) 555-0001", qa = true, resumeId = 11, yearsOfExperience = 1 };
            Candidate c2 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 2", phone = "(800) 555-0002", qa = true, resumeId = 12, yearsOfExperience = 2 };
            Candidate c3 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 3", phone = "(800) 555-0003", qa = true, resumeId = 13, yearsOfExperience = 3 };
            Candidate c4 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 4", phone = "(800) 555-0004", qa = true, resumeId = 14, yearsOfExperience = 4 };
            Candidate c5 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 5", phone = "(800) 555-0005", qa = true, resumeId = 15, yearsOfExperience = 5 };
            Candidate c6 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 6", phone = "(800) 555-0006", qa = true, resumeId = 16, yearsOfExperience = 6 };
            Candidate c7 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 7", phone = "(800) 555-0007", qa = true, resumeId = 17, yearsOfExperience = 7 };
            Candidate c8 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 8", phone = "(800) 555-0008", qa = true, resumeId = 18, yearsOfExperience = 8 };
            Candidate c9 = new Candidate() { id = CandidateDbCtx.nextId++, developer = true, name = "Guy 9", phone = "(800) 555-0009", qa = true, resumeId = 19, yearsOfExperience = 9 };

            CandidateDbCtx.candidates.Add(c1);
            CandidateDbCtx.candidates.Add(c2);
            CandidateDbCtx.candidates.Add(c3);
            CandidateDbCtx.candidates.Add(c4);
            CandidateDbCtx.candidates.Add(c5);
            CandidateDbCtx.candidates.Add(c6);
            CandidateDbCtx.candidates.Add(c7);
            CandidateDbCtx.candidates.Add(c8);
            CandidateDbCtx.candidates.Add(c9);

        }

        public void Delete(int id)
        {
            foreach (Candidate c in candidates)
            {
                if (c.id == id)
                {
                    candidates.Remove(c);
                    return;
                }
            }
            throw new Exception("Item does not exist to delete.");
        }

        public IEnumerable<Candidate> Get()
        {
            return CandidateDbCtx.candidates;
        }

        public Candidate Get(int id)
        {
            foreach (Candidate c in candidates)
            {
                if (c.id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public void Insert(Candidate candidate)
        {
            Candidate candidateToAdd = new Candidate();
            candidateToAdd = candidate;
            candidateToAdd.id = CandidateDbCtx.nextId++;
            CandidateDbCtx.candidates.Add(candidateToAdd);
            
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Candidate candidate)
        {
            Candidate c = this.Get(candidate.id);
            if (c == null) { throw new Exception("Candidate does not exist to update"); }
            c.developer = candidate.developer;
            c.name = candidate.name;
            c.phone = candidate.phone;
            c.qa = candidate.qa;
            c.resumeId = candidate.resumeId;
            c.yearsOfExperience = candidate.yearsOfExperience;

        }
    }
}