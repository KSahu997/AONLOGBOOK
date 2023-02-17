using AONLOGBOOK.SHARED.CModels;
using Microsoft.EntityFrameworkCore;

namespace AONLOGBOOK.API.Models
{

    public class CustomContext : DbContext
    {
        public CustomContext()
        {
        }

        public CustomContext(DbContextOptions<CustomContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TblLogbookDetailSchemaMOD> TblLogbookDetailSchemaMODs { get; set; }

        public virtual DbSet<LogData> TblLogData { get; set; }
        public virtual DbSet<LogDataReport> TblLogDataReports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TblLogbookDetailSchemaMOD>(entity =>
            //{
            //    entity.HasNoKey();
            //});

            modelBuilder.Entity<TblLogbookDetailSchemaMOD>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tbl_FormSchema");

                entity.ToTable("tbl_Logbook_detail_Schema");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                //entity.Property(e => e.LogbookId)
                //    .HasMaxLength(50)
                //    .IsUnicode(false);
                entity.Property(e => e.CalulationParams)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Calulation_Params");
                entity.Property(e => e.Element)
                     .HasMaxLength(50)
                     .IsUnicode(false);
                entity.Property(e => e.DataType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Display_Name");
                entity.Property(e => e.RefCol)
                   .HasMaxLength(50)
                   .IsUnicode(false);
                //entity.Property(e => e.Unit).HasMaxLength(50);
                entity.Property(e => e.LMax)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("L_Max");
                entity.Property(e => e.LMin)
                    .HasDefaultValueSql("((0))")
                    .HasColumnName("L_Min");

                entity.Property(e => e.Operator).HasMaxLength(5);
                entity.Property(e => e.Prscn).HasColumnName("prscn");


                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UOM");

            });
            modelBuilder.Entity<LogData>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("tbl_Logdata");

                //entity.Property(e => e.Id)
                //    .HasColumnName("id")
                //    .HasDefaultValueSql("(newid())");
                entity.Property(e => e.Uom).HasColumnName("UOM");
                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

               // entity.Property(e => e.date).HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.LogbookId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Logbook_Id");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_Id");

                entity.Property(e => e.Shift)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ParamName)
                  .HasColumnName("ParamName");
                entity.Property(e => e.Val)
                    .HasColumnName("Val");

                entity.Property(e => e.SubDeptId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Sub_deptId");
                entity.Property(e => e.MarkforDeletion)
                   .HasMaxLength(50)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<LogDataReport>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("tbl_logbookDataReport");

                
                entity.Property(e => e.ParamName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
              
                entity.Property(e => e.ShiftPrefix)
                  .HasMaxLength(2)
                  .IsUnicode(false)
                  .HasColumnName("Shift_prefix");

                    entity.Property(e => e.Sl)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sl");

              
                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }
}
