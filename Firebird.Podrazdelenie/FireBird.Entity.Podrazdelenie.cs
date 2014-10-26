using AsrkRf.Rpl.Common;
using FluentNHibernate.Mapping;

namespace FireBird.Entity
{
	public class Podrazdelenie : CommonEntity, IFirebird
	{
		public decimal Barchiv { get; set; } /* Original name BARCHIV*/
		public decimal DirectorId { get; set; } /* Original name DIRECTOR_ID*/
		public decimal IdClient { get; set; } /* Original name ID_CLIENT*/
		public decimal IdClientDbs { get; set; } /* Original name ID_CLIENT_DBS*/
		public decimal IdClientEis { get; set; } /* Original name ID_CLIENT_EIS*/
		public decimal IdParent { get; set; } /* Original name ID_PARENT*/
		public decimal IdPodrazdelenie { get; set; } /* Original name ID_PODRAZDELENIE*/
		public decimal IdRegion { get; set; } /* Original name ID_REGION*/
		public decimal IdRkPlace { get; set; } /* Original name ID_RK_PLACE*/
		public decimal IdSpRkSubsystem { get; set; } /* Original name ID_SP_RK_SUBSYSTEM*/
		public decimal IsMobile { get; set; } /* Original name IS_MOBILE*/
		public int IsRkp { get; set; } /* Original name IS_RKP*/
		public string Podrazdname { get; set; } /* Original name PODRAZDNAME*/
		public string PodrazdnameSokr { get; set; } /* Original name PODRAZDNAME_SOKR*/
		public int RplIdServer { get; set; } /* Original name RPL_ID_SERVER*/
		public string Sname { get; set; } /* Original name SNAME*/
	}

    public class PodrazdelenieMap : ClassMap<Podrazdelenie>
    {
        public PodrazdelenieMap()
        {
            Table("Podrazdelenie");
            Id(x => x.IdPodrazdelenie).Column("ID_PODRAZDELENIE");
            Map(x => x.IdRegion).Column("ID_REGION");
        }
    }
}
