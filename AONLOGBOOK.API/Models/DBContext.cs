using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AONLOGBOOK.SHARED.Models;

namespace AONLOGBOOK.API.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCompanyMaster> TblCompanyMasters { get; set; } = null!;
        public virtual DbSet<TblDeptMaster> TblDeptMasters { get; set; } = null!;
        public virtual DbSet<TblDocGenerateMaster> TblDocGenerateMasters { get; set; } = null!;
        public virtual DbSet<TblEquipmentMaster> TblEquipmentMasters { get; set; } = null!;
        public virtual DbSet<TblFormGroupMaster> TblFormGroupMasters { get; set; } = null!;
        public virtual DbSet<TblFormMaster> TblFormMasters { get; set; } = null!;
        public virtual DbSet<TblFunctionalLocationMaster> TblFunctionalLocationMasters { get; set; } = null!;
        public virtual DbSet<TblLogBookDataTable> TblLogBookDataTables { get; set; } = null!;
        public virtual DbSet<TblLogBookDataTableHeader> TblLogBookDataTableHeaders { get; set; } = null!;
        public virtual DbSet<TblLogbookDetailSchema> TblLogbookDetailSchemas { get; set; } = null!;
        public virtual DbSet<TblLogbookMaster> TblLogbookMasters { get; set; } = null!;
        public virtual DbSet<TblLookup> TblLookups { get; set; } = null!;
        public virtual DbSet<TblLookupParam> TblLookupParams { get; set; } = null!;
        public virtual DbSet<TblLookupValue> TblLookupValues { get; set; } = null!;
        public virtual DbSet<TblPlantMaster> TblPlantMasters { get; set; } = null!;
        public virtual DbSet<TblShiftMaster> TblShiftMasters { get; set; } = null!;
        public virtual DbSet<TblSubDeptMaster> TblSubDeptMasters { get; set; } = null!;
        public virtual DbSet<TblTagMaster> TblTagMasters { get; set; } = null!;
        public virtual DbSet<TblUommaster> TblUommasters { get; set; } = null!;
        public virtual DbSet<TblWorkCenterMaster> TblWorkCenterMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCompanyMaster>(entity =>
            {
                entity.ToTable("tbl_Company_Master");

                entity.HasIndex(e => e.CompanyId, "IX_tbl_Company_Master")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyName, "IX_tbl_Company_Master_1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Attachment).IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Company_Id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Company_Name");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Doc_Date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FYear)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("F_Year");

                entity.Property(e => e.GstNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GST_no");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone_no");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusF)
                    .HasColumnName("Status_F")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblDeptMaster>(entity =>
            {
                entity.ToTable("tbl_Dept_Master");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Name");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Doc_Date");

                entity.Property(e => e.FYear)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("F_Year");

                entity.Property(e => e.IsLeaf).HasColumnName("Is_Leaf");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_Id");

                entity.Property(e => e.StatusF).HasColumnName("Status_F");
            });

            modelBuilder.Entity<TblDocGenerateMaster>(entity =>
            {
                entity.ToTable("tbl_DocGenerateMaster");

                entity.Property(e => e.Abbrevation)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.DocName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RunNo).HasColumnName("Run_No");
            });

            modelBuilder.Entity<TblEquipmentMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Equipment_Master");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Company_ID");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EquipmentCode)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Equipment_Code");

                entity.Property(e => e.EquipmentName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Equipment_Name");

                entity.Property(e => e.FuncLocationId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Func_Location_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsertedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Inserted_By");

                entity.Property(e => e.InsertedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Inserted_On");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Plant_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_On");

                entity.Property(e => e.WorkCenterId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("WorkCenter_ID");
            });

            modelBuilder.Entity<TblFormGroupMaster>(entity =>
            {
                entity.HasKey(e => e.FormGroupId)
                    .HasName("PK_tbl_FprmGroupMaster");

                entity.ToTable("tbl_FormGroupMaster");

                entity.Property(e => e.FormGroupId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dept)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPT");

                entity.Property(e => e.FormGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plant)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubDept)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFormMaster>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("tbl_FormMaster");

                entity.Property(e => e.FormId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FormGroup).IsUnicode(false);

                entity.Property(e => e.FormName).IsUnicode(false);

                entity.Property(e => e.SeqSm).HasColumnName("Seq_sm");
            });

            modelBuilder.Entity<TblFunctionalLocationMaster>(entity =>
            {
                entity.ToTable("tbl_FunctionalLocation_Master");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Company_ID");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FunctionalLocation)
                    .IsUnicode(false)
                    .HasColumnName("Functional_Location");

                entity.Property(e => e.InsertedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Inserted_By");

                entity.Property(e => e.InsertedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Inserted_On");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Location_Code");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Plant_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_On");

                entity.Property(e => e.WorkCenterId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("WorkCenter_ID");
            });

            modelBuilder.Entity<TblLogBookDataTable>(entity =>
            {
                entity.ToTable("tbl_LogBookDataTable");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CretedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CretedOn).HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Header_Id");

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.LogbookId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarkforDeletion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.ParamName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plantcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("plantcode");

                entity.Property(e => e.Shift)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sl)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sl");

                entity.Property(e => e.SubDeptid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Sub_deptid");

                entity.Property(e => e.Uom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLogBookDataTableHeader>(entity =>
            {
                entity.ToTable("tbl_LogBookDataTable_Header");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.FYear)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("F_Year");

                entity.Property(e => e.LogbookId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Logbook_Id");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_Id");

                entity.Property(e => e.Shift)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusF).HasColumnName("Status_F");

                entity.Property(e => e.SubDeptId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Sub_deptId");
            });

            modelBuilder.Entity<TblLogbookDetailSchema>(entity =>
            {
                entity.ToTable("tbl_Logbook_detail_Schema");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CalulationParams)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Calulation_Params");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CretedOn).HasColumnType("datetime");

                entity.Property(e => e.Critical)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.DataType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Element)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Header_id");

                entity.Property(e => e.IsDashboardComponent)
                    .HasColumnName("isDashboardComponent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMandatory)
                    .HasColumnName("isMandatory")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LMax)
                    .HasColumnName("L_Max")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LMin)
                    .HasColumnName("L_Min")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LogbookId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Operator).HasMaxLength(5);

                entity.Property(e => e.Prscn).HasColumnName("prscn");

                entity.Property(e => e.RefCol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Seq).ValueGeneratedOnAdd();

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Special)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.Uom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UOM");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLogbookMaster>(entity =>
            {
                entity.HasKey(e => e.LogbookId)
                    .HasName("PK_tbl_ActivityMaster");

                entity.ToTable("tbl_Logbook_Master");

                entity.Property(e => e.LogbookId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company_Id");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsOper)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Inspection)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsLeaf)
                    .IsUnicode(false)
                    .HasColumnName("isLeaf")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LogbookCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Logbook_Code");

                entity.Property(e => e.LogbookName).IsUnicode(false);

                entity.Property(e => e.Mname)
                    .IsUnicode(false)
                    .HasColumnName("MName");

                entity.Property(e => e.Mode).IsUnicode(false);

                entity.Property(e => e.PlantCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prefix).IsUnicode(false);

                entity.Property(e => e.SeqSm).HasColumnName("Seq_sm");

                entity.Property(e => e.StatutoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubDepartment).IsUnicode(false);
            });

            modelBuilder.Entity<TblLookup>(entity =>
            {
                entity.ToTable("tbl_Lookup");

                entity.HasIndex(e => e.Name, "UName")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_On");
            });

            modelBuilder.Entity<TblLookupParam>(entity =>
            {
                entity.ToTable("tbl_Lookup_Param");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LookupId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Lookup_ID");

                entity.Property(e => e.Param)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_On");
            });

            modelBuilder.Entity<TblLookupValue>(entity =>
            {
                entity.ToTable("tbl_LookupValues");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LookupId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Lookup_ID");

                entity.Property(e => e.NameValue)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Name_Value");

                entity.Property(e => e.ParamValues)
                    .IsUnicode(false)
                    .HasColumnName("Param_Values");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_On");
            });

            modelBuilder.Entity<TblPlantMaster>(entity =>
            {
                entity.ToTable("tbl_Plant_Master");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company_Id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('India')");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Doc_Date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FYear)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("F_Year");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone_no");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Plant_Id");

                entity.Property(e => e.PlantName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Plant_Name");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusF).HasColumnName("Status_F");
            });

            modelBuilder.Entity<TblShiftMaster>(entity =>
            {
                entity.ToTable("tbl_Shift_Master");

                entity.HasIndex(e => new { e.CompanyId, e.ShiftPrefix, e.ShiftStart }, "Shift Prefix already exist")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Delflag).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShiftPrefix)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("Shift_prefix");

                entity.Property(e => e.ShiftStart)
                    .HasColumnType("time(4)")
                    .HasColumnName("Shift_start");
            });

            modelBuilder.Entity<TblSubDeptMaster>(entity =>
            {
                entity.ToTable("tbl_Sub_dept_Master");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Company_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Doc_Date");

                entity.Property(e => e.FYear)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("F_Year");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Plant_Id");

                entity.Property(e => e.StatusF).HasColumnName("Status_F");

                entity.Property(e => e.SubDptId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SubDpt_Id");

                entity.Property(e => e.SubDptName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SubDpt_Name");
            });

            modelBuilder.Entity<TblTagMaster>(entity =>
            {
                entity.ToTable("tbl_Tag_Master");

                entity.HasIndex(e => e.Id, "IX_tbl_Tag_Master");

                entity.HasIndex(e => e.TagName, "UTag_Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Display_Name")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TagName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tag_Name");

                entity.Property(e => e.Uom).HasColumnName("UOM");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_On");
            });

            modelBuilder.Entity<TblUommaster>(entity =>
            {
                entity.ToTable("tbl_UOMmaster");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DelFlag).HasColumnName("delFlag");

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

            modelBuilder.Entity<TblWorkCenterMaster>(entity =>
            {
                entity.ToTable("tbl_WorkCenter_Master");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Company_ID");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("Del_Flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InsertedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Inserted_By");

                entity.Property(e => e.InsertedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Inserted_On");

                entity.Property(e => e.PlantId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Plant_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on");

                entity.Property(e => e.WorkCenterName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("WorkCenter_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
