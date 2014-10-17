using AsrkRf.Rpl.Common;
using FluentNHibernate.Mapping;

namespace AsrkRf.Rpl.Subdivision.Entities
{
    public class Podrazdelenie
    {
        [Cloud(ClassName = "CloudSubdivision", PropertyName = "IdSubdivision", Type = CloudAttributeType.Value)]
        public virtual long IdPodrazdelenie { get; set; }

        [Cloud(ClassName = "CloudSubdivision", PropertyName = "SubdivisionName", Type = CloudAttributeType.Value)]
        public virtual string PodrazdName { get; set; }

        [Cloud(ClassName = "CloudSubdivision", PropertyName = "SubdivisionShortName", Type = CloudAttributeType.Value)]
        public virtual string PodrazdNameSokr { get; set; }

        [Cloud(ClassName = "CloudSubdivision", PropertyName = "IdRegion", Type = CloudAttributeType.Value)]
        public virtual long IdRegion { get; set; }

        [Cloud(ClassName = "CloudSubdivision", PropertyName = "Parent", Type = CloudAttributeType.Class)]
        public virtual Podrazdelenie Parent { get; set; }
    }

    public class PodrazdelenieMap : ClassMap<Podrazdelenie>
    {
        public PodrazdelenieMap()
        {
            Table("podrazdelenie");
            Id(x => x.IdPodrazdelenie).Column("id_podrazdelenie");
            Map(x => x.IdRegion).Column("id_region");
            Map(x => x.PodrazdName).Column("podrazdname");
            Map(x => x.PodrazdNameSokr).Column("podrazdname_sokr");
            References(x => x.Parent).Column("id_parent");
        }
    }
}
