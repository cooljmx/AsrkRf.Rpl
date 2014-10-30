using AsrkRf.Rpl.Common;
using FluentNHibernate.Mapping;
using System;
namespace FireBird.Entity
{
	public class PODRAZDELENIE : IFirebird
	{
		public virtual decimal BARCHIV { get; set; } /* Original name BARCHIV*/
		public virtual decimal DIRECTOR_ID { get; set; } /* Original name DIRECTOR_ID*/
		public virtual decimal ID_CLIENT { get; set; } /* Original name ID_CLIENT*/
		public virtual decimal ID_CLIENT_DBS { get; set; } /* Original name ID_CLIENT_DBS*/
		public virtual decimal ID_CLIENT_EIS { get; set; } /* Original name ID_CLIENT_EIS*/
		public virtual decimal ID_PARENT { get; set; } /* Original name ID_PARENT*/
		public virtual decimal ID_PODRAZDELENIE { get; set; } /* Original name ID_PODRAZDELENIE*/
		public virtual decimal ID_REGION { get; set; } /* Original name ID_REGION*/
		public virtual decimal ID_RK_PLACE { get; set; } /* Original name ID_RK_PLACE*/
		public virtual decimal ID_SP_RK_SUBSYSTEM { get; set; } /* Original name ID_SP_RK_SUBSYSTEM*/
		public virtual decimal IS_MOBILE { get; set; } /* Original name IS_MOBILE*/
		public virtual int IS_RKP { get; set; } /* Original name IS_RKP*/
		public virtual string PODRAZDNAME { get; set; } /* Original name PODRAZDNAME*/
		public virtual string PODRAZDNAME_SOKR { get; set; } /* Original name PODRAZDNAME_SOKR*/
		public virtual int RPL_ID_SERVER { get; set; } /* Original name RPL_ID_SERVER*/
		public virtual string SNAME { get; set; } /* Original name SNAME*/
	}
	public class PODRAZDELENIEMap : ClassMap<PODRAZDELENIE>
	{
		public PODRAZDELENIEMap()
		{
			Table("PODRAZDELENIE");
			Id(x => x.ID_PODRAZDELENIE).Column("ID_PODRAZDELENIE").GeneratedBy.TriggerIdentity();
			Map(x => x.ID_PARENT).Column("ID_PARENT");
			Map(x => x.ID_REGION).Column("ID_REGION");
			Map(x => x.DIRECTOR_ID).Column("DIRECTOR_ID");
			Map(x => x.ID_CLIENT).Column("ID_CLIENT");
			Map(x => x.ID_SP_RK_SUBSYSTEM).Column("ID_SP_RK_SUBSYSTEM");
			Map(x => x.ID_RK_PLACE).Column("ID_RK_PLACE");
			Map(x => x.ID_CLIENT_DBS).Column("ID_CLIENT_DBS");
			Map(x => x.ID_CLIENT_EIS).Column("ID_CLIENT_EIS");
			Map(x => x.IS_RKP).Column("IS_RKP");
			Map(x => x.RPL_ID_SERVER).Column("RPL_ID_SERVER");
			Map(x => x.PODRAZDNAME).Column("PODRAZDNAME");
			Map(x => x.PODRAZDNAME_SOKR).Column("PODRAZDNAME_SOKR");
			Map(x => x.SNAME).Column("SNAME");
			Map(x => x.IS_MOBILE).Column("IS_MOBILE");
			Map(x => x.BARCHIV).Column("BARCHIV");
		}
	}
}

