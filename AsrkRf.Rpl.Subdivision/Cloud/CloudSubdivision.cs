using AsrkRf.Rpl.Common;

namespace AsrkRf.Rpl.Subdivision.Cloud
{
    public class CloudSubdivision : ICloud
    {
        public long IdSubdivision { get; set; }
        public string SubdivisionName { get; set; }
        public string SubdivisionShortName { get; set; }
        public long IdRegion { get; set; }

        public CloudSubdivision Parent { get; set; }
    }
}
