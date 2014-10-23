using System;
using AsrkRf.Rpl.Common;

namespace Cloud
{
    public class CloudSubdivision// : ICloud
    {
        public string IdSubdivision { get; set; }
        public string SubdivisionName { get; set; }
        public string SubdivisionShortName { get; set; }
        public string IdRegion { get; set; }

        public CloudSubdivision Parent { get; set; }

        public void Print(string message)
        {
            Console.WriteLine("From script: " + message);
        }

        public CloudSubdivision CreateParent()
        {
            return new CloudSubdivision();
        }
    }
}
