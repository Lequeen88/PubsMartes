using PubsMartes.Domain.core;
using System;

namespace PubsMartes.Domain.Entities
{
    public class jobs : BaseEntity
    {
        public jobs() 
        {
            List<int> ints = new List<int>();

            List<string> strings = new List<string>();

        }
        public int job_id { get; set; }

        public string? job_desc { get; set; }

        public int min_lvl { get; set; }

        public int max_lvl { get; set;}
    }
}
