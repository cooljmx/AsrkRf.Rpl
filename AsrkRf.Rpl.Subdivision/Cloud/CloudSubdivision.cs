using AsrkRf.Rpl.Common;

namespace AsrkRf.Rpl.Subdivision.Cloud
{
    public class CloudSubdivision : ICloud, ICloudSubdivision
    {
        public long IdSubdivision { get; set; }
        public string SubdivisionName { get; set; }
        public string SubdivisionShortName { get; set; }
        public long IdRegion { get; set; }

        public ICloudSubdivision Parent { get; set; }

        public CloudSubdivision()
        {
        }
    }
}
