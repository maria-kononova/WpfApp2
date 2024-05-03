using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp2
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appeal> Appeals { get; set; } = null!;
        //public virtual DbSet<Appealproblem> Appealproblems { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employeer> Employeers { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        //public virtual DbSet<Problem> Problems { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Stage> Stages { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Typequipment> Typequipments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;persist security info=False;user=root;password=228338118;database=mydb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Appeal>(entity =>
            {
                entity.ToTable("appeal");

                entity.HasIndex(e => e.Client, "appeal_client_idx");

                entity.HasIndex(e => e.Equipment, "appeal_equipment_idx");

                entity.HasIndex(e => e.Status, "appeal_status_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Client).HasColumnName("client");

                entity.Property(e => e.DateEnd).HasColumnName("dateEnd");

                entity.Property(e => e.DateStart).HasColumnName("dateStart");

                entity.Property(e => e.Equipment).HasColumnName("equipment");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Problem).HasColumnName("problem");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Appeals)
                    .HasForeignKey(d => d.Client)
                    .HasConstraintName("appeal_client");

                entity.HasOne(d => d.EquipmentNavigation)
                    .WithMany(p => p.Appeals)
                    .HasForeignKey(d => d.Equipment)
                    .HasConstraintName("appeal_equipment");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Appeals)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("appeal_status");
            });

            /*modelBuilder.Entity<Appealproblem>(entity =>
            {
                entity.HasKey(e => new { e.Appeal, e.Problem })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("appealproblem");

                entity.HasIndex(e => e.Problem, "problem_appeal_idx");

                entity.Property(e => e.Appeal).HasColumnName("appeal");

                entity.Property(e => e.Problem).HasColumnName("problem");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .HasColumnName("comment");

                entity.HasOne(d => d.AppealNavigation)
                    .WithMany(p => p.Appealproblems)
                    .HasForeignKey(d => d.Appeal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appeal_problem");

                entity.HasOne(d => d.ProblemNavigation)
                    .WithMany(p => p.Appealproblems)
                    .HasForeignKey(d => d.Problem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("problem_appeal");
            });*/

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.HasIndex(e => e.User, "user_client_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateBrithday).HasColumnName("dateBrithday");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(45)
                    .HasColumnName("surname");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("user_client");
            });

            modelBuilder.Entity<Employeer>(entity =>
            {
                entity.ToTable("employeer");

                entity.HasIndex(e => e.Post, "emp_post_idx");

                entity.HasIndex(e => e.User, "emp_user_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Post).HasColumnName("post");

                entity.Property(e => e.Surname)
                    .HasMaxLength(45)
                    .HasColumnName("surname");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.Employeers)
                    .HasForeignKey(d => d.Post)
                    .HasConstraintName("emp_post");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Employeers)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("emp_user");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipment");

                entity.HasIndex(e => e.Type, "equipment_type_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(45)
                    .HasColumnName("serialNumber");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("equipment_type");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("material");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasMaxLength(45)
                    .HasColumnName("cost");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            /*modelBuilder.Entity<Problem>(entity =>
            {
                entity.ToTable("problem");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Solution)
                    .HasMaxLength(200)
                    .HasColumnName("solution");
            });*/

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchase");

                entity.HasIndex(e => e.Employeer, "purchase_emp_idx");

                entity.HasIndex(e => e.Material, "purchase_material_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Employeer).HasColumnName("employeer");

                entity.Property(e => e.Material).HasColumnName("material");

                entity.HasOne(d => d.EmployeerNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.Employeer)
                    .HasConstraintName("purchase_emp");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.Material)
                    .HasConstraintName("purchase_material");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => new { e.Stage, e.Material })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("resources");

                entity.HasIndex(e => e.Material, "material_stage_idx");

                entity.Property(e => e.Stage).HasColumnName("stage");

                entity.Property(e => e.Material).HasColumnName("material");

                entity.Property(e => e.Count)
                    .HasMaxLength(45)
                    .HasColumnName("count");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("material_stage");

                entity.HasOne(d => d.StageNavigation)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.Stage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stage_material");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("stage");

                entity.HasIndex(e => e.Appeal, "stage_appeal_idx");

                entity.HasIndex(e => e.Employeer, "stage_emp_idx");

                entity.HasIndex(e => e.Status, "stage_status_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Appeal).HasColumnName("appeal");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .HasColumnName("comment");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Employeer).HasColumnName("employeer");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.AppealNavigation)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.Appeal)
                    .HasConstraintName("stage_appeal");

                entity.HasOne(d => d.EmployeerNavigation)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.Employeer)
                    .HasConstraintName("stage_emp");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("stage_status");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Typequipment>(entity =>
            {
                entity.ToTable("typequipment");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Role, "user_role_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Login)
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
