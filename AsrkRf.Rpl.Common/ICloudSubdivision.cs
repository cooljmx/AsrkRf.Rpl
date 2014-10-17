namespace AsrkRf.Rpl.Common
{
    public interface ICloudSubdivision
    {
        long IdSubdivision { get; set; }
        string SubdivisionName { get; set; }
        string SubdivisionShortName { get; set; }
        long IdRegion { get; set; }

        ICloudSubdivision Parent { get; set; }
    }
}
