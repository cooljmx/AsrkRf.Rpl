using AsrkRf.Rpl.Common;
using FluentNHibernate.Mapping;
namespace FireBird.Entity
{
	public class Podrazdelenie : IFirebird
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
			Table("PODRAZDELENIE");
			Id(x => x.IdPodrazdelenie).Column("ID_PODRAZDELENIE").GeneratedBy.TriggerIdentity();
			Map(x => x.IdParent).Column("ID_PARENT");
			Map(x => x.IdRegion).Column("ID_REGION");
			Map(x => x.DirectorId).Column("DIRECTOR_ID");
			Map(x => x.IdClient).Column("ID_CLIENT");
			Map(x => x.IdSpRkSubsystem).Column("ID_SP_RK_SUBSYSTEM");
			Map(x => x.IdRkPlace).Column("ID_RK_PLACE");
			Map(x => x.IdClientDbs).Column("ID_CLIENT_DBS");
			Map(x => x.IdClientEis).Column("ID_CLIENT_EIS");
			Map(x => x.IsRkp).Column("IS_RKP");
			Map(x => x.RplIdServer).Column("RPL_ID_SERVER");
			Map(x => x.Podrazdname).Column("PODRAZDNAME");
			Map(x => x.PodrazdnameSokr).Column("PODRAZDNAME_SOKR");
			Map(x => x.Sname).Column("SNAME");
			Map(x => x.IsMobile).Column("IS_MOBILE");
			Map(x => x.Barchiv).Column("BARCHIV");
		}
	}
}

