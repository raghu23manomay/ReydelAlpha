using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Data;
using System.Data.Entity;

namespace ReyDel.Models
{
    public class ReydeldbContext :DbContext
    {
        static ReydeldbContext()
        {
            Database.SetInitializer<ReydeldbContext>(null);

        }
        public ReydeldbContext() : base("Name=ReydeldbContext")
        {
        }
        public DbSet<MaterialGradeMaster> MaterialGradeMasters { get; set; }
        public DbSet<REIMaster> REIMasters { get; set; }
        public DbSet<ColourMaster> ColourMasters { get; set; }
        public DbSet<SupportFunctionMaster> SupportFunctionMasters { get; set; }
        public DbSet<ChangeTypeMaster> ChangeTypeMasters { get; set; }

        public DbSet<RejectionReasonMaster> RejectionReasonMasters { get; set; }
        public DbSet<RejectionReasonTypeMaster> RejectionReasonTypeMasters { get; set; }
        public DbSet<ExcelImportTypeMaster> ExcelImportTypeMasters { get; set; }
        public DbSet<ChangeTypeConfiguration> ChangeTypeConfigurations { get; set; }
        public DbSet<Production_Entry> ProductionEntry { get; set; }
        public DbSet<DownTime_Entry> DownTime_Entry { get; set; }
    }
}