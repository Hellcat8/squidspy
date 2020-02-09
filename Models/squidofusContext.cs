using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace squidspy.Models
{
    public partial class squidofusContext : DbContext
    {
        public squidofusContext()
        {
        }

        public squidofusContext(DbContextOptions<squidofusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arme> Arme { get; set; }
        public virtual DbSet<ArmeCaracteristique> ArmeCaracteristique { get; set; }
        public virtual DbSet<ArmeCondition> ArmeCondition { get; set; }
        public virtual DbSet<ArmeEffect> ArmeEffect { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassBuild> ClassBuild { get; set; }
        public virtual DbSet<ClassBuildDetail> ClassBuildDetail { get; set; }
        public virtual DbSet<ClassDetail> ClassDetail { get; set; }
        public virtual DbSet<Consommable> Consommable { get; set; }
        public virtual DbSet<ConsommableEffect> ConsommableEffect { get; set; }
        public virtual DbSet<Craft> Craft { get; set; }
        public virtual DbSet<CraftArme> CraftArme { get; set; }
        public virtual DbSet<CraftConsommable> CraftConsommable { get; set; }
        public virtual DbSet<CraftEquipement> CraftEquipement { get; set; }
        public virtual DbSet<CraftRessource> CraftRessource { get; set; }
        public virtual DbSet<Equipement> Equipement { get; set; }
        public virtual DbSet<EquipementCondition> EquipementCondition { get; set; }
        public virtual DbSet<EquipementEffect> EquipementEffect { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Ressource> Ressource { get; set; }
        public virtual DbSet<RessourceEffect> RessourceEffect { get; set; }
        public virtual DbSet<Spell> Spell { get; set; }
        public virtual DbSet<SpellDetail> SpellDetail { get; set; }
        public virtual DbSet<SpellEffect> SpellEffect { get; set; }
        public virtual DbSet<TypeArme> TypeArme { get; set; }
        public virtual DbSet<TypeCaracteristique> TypeCaracteristique { get; set; }
        public virtual DbSet<TypeConsommable> TypeConsommable { get; set; }
        public virtual DbSet<TypeEffect> TypeEffect { get; set; }
        public virtual DbSet<TypeEquipement> TypeEquipement { get; set; }
        public virtual DbSet<TypeRessource> TypeRessource { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=midnightpurple;database=squidofus", x => x.ServerVersion("5.7.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arme>(entity =>
            {
                entity.HasKey(e => e.IdArme)
                    .HasName("PRIMARY");

                entity.ToTable("arme");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_arme_to_craft_idx");

                entity.HasIndex(e => e.IdImage)
                    .HasName("fk_arme_to_image_idx");

                entity.HasIndex(e => e.IdTypeArme)
                    .HasName("fk_arme_to_type_arme_idx");

                entity.Property(e => e.IdArme)
                    .HasColumnName("id_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdImage)
                    .HasColumnName("id_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeArme)
                    .HasColumnName("id_type_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.Arme)
                    .HasForeignKey(d => d.IdCraft)
                    .HasConstraintName("fk_arme_to_craft");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.Arme)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("fk_arme_to_image");

                entity.HasOne(d => d.IdTypeArmeNavigation)
                    .WithMany(p => p.Arme)
                    .HasForeignKey(d => d.IdTypeArme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arme_to_type_arme");
            });

            modelBuilder.Entity<ArmeCaracteristique>(entity =>
            {
                entity.HasKey(e => e.IdArmeCaracteristique)
                    .HasName("PRIMARY");

                entity.ToTable("arme_caracteristique");

                entity.HasIndex(e => e.IdArme)
                    .HasName("fk_caracteristique_to_arme_idx");

                entity.Property(e => e.IdArmeCaracteristique)
                    .HasColumnName("id_arme_caracteristique")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CriticalHitProbability)
                    .IsRequired()
                    .HasColumnName("critical_hit_probability")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.FailureProbability)
                    .IsRequired()
                    .HasColumnName("failure_probability")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdArme)
                    .HasColumnName("id_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pa)
                    .HasColumnName("pa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Portee)
                    .HasColumnName("portee")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdArmeNavigation)
                    .WithMany(p => p.ArmeCaracteristique)
                    .HasForeignKey(d => d.IdArme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_caracteristique_to_arme");
            });

            modelBuilder.Entity<ArmeCondition>(entity =>
            {
                entity.HasKey(e => e.IdArmeCondition)
                    .HasName("PRIMARY");

                entity.ToTable("arme_condition");

                entity.HasIndex(e => e.IdArme)
                    .HasName("fk_condition_arme_to_arme_idx");

                entity.Property(e => e.IdArmeCondition)
                    .HasColumnName("id_arme_condition")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasColumnName("condition")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdArme)
                    .HasColumnName("id_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdArmeNavigation)
                    .WithMany(p => p.ArmeCondition)
                    .HasForeignKey(d => d.IdArme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_condition_arme_to_arme");
            });

            modelBuilder.Entity<ArmeEffect>(entity =>
            {
                entity.HasKey(e => e.IdArmeEffect)
                    .HasName("PRIMARY");

                entity.ToTable("arme_effect");

                entity.HasIndex(e => e.IdArme)
                    .HasName("fk_arme_effect_to_arme_idx");

                entity.HasIndex(e => e.IdTypeCaracteristique)
                    .HasName("fk_arme_effect_to_type_caracteristique_idx");

                entity.HasIndex(e => e.IdTypeEffect)
                    .HasName("fk_arme_effect_to_type_effect_idx");

                entity.Property(e => e.IdArmeEffect)
                    .HasColumnName("id_arme_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect")
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdArme)
                    .HasColumnName("id_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeCaracteristique)
                    .HasColumnName("id_type_caracteristique")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeEffect)
                    .HasColumnName("id_type_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdArmeNavigation)
                    .WithMany(p => p.ArmeEffect)
                    .HasForeignKey(d => d.IdArme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arme_effect_to_arme");

                entity.HasOne(d => d.IdTypeCaracteristiqueNavigation)
                    .WithMany(p => p.ArmeEffect)
                    .HasForeignKey(d => d.IdTypeCaracteristique)
                    .HasConstraintName("fk_arme_effect_to_type_caracteristique");

                entity.HasOne(d => d.IdTypeEffectNavigation)
                    .WithMany(p => p.ArmeEffect)
                    .HasForeignKey(d => d.IdTypeEffect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arme_effect_to_type_effect");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PRIMARY");

                entity.ToTable("class");

                entity.Property(e => e.IdClass)
                    .HasColumnName("id_class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            modelBuilder.Entity<ClassBuild>(entity =>
            {
                entity.HasKey(e => e.IdClassBuild)
                    .HasName("PRIMARY");

                entity.ToTable("class_build");

                entity.HasIndex(e => e.IdClass)
                    .HasName("fk_class_build_to_class_idx");

                entity.Property(e => e.IdClassBuild)
                    .HasColumnName("id_class_build")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdClass)
                    .HasColumnName("id_class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.ClassBuild)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_build_to_class");
            });

            modelBuilder.Entity<ClassBuildDetail>(entity =>
            {
                entity.HasKey(e => e.IdClassBuildDetail)
                    .HasName("PRIMARY");

                entity.ToTable("class_build_detail");

                entity.HasIndex(e => e.IdClassBuild)
                    .HasName("fk_class_build_detail_to_class_build_idx");

                entity.Property(e => e.IdClassBuildDetail)
                    .HasColumnName("id_class_build_detail")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnName("detail")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.ExtraLineAtEnd).HasColumnName("extra_line_at_end");

                entity.Property(e => e.IdClassBuild)
                    .HasColumnName("id_class_build")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdClassBuildNavigation)
                    .WithMany(p => p.ClassBuildDetail)
                    .HasForeignKey(d => d.IdClassBuild)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_build_detail_to_class_build");
            });

            modelBuilder.Entity<ClassDetail>(entity =>
            {
                entity.HasKey(e => e.IdClassDetail)
                    .HasName("PRIMARY");

                entity.ToTable("class_detail");

                entity.HasIndex(e => e.IdClass)
                    .HasName("fk_class_detail_to_class_idx");

                entity.Property(e => e.IdClassDetail)
                    .HasColumnName("id_class_detail")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnName("detail")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdClass)
                    .HasColumnName("id_class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasColumnName("keyword")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.ClassDetail)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_detail_to_class");
            });

            modelBuilder.Entity<Consommable>(entity =>
            {
                entity.HasKey(e => e.IdConsommable)
                    .HasName("PRIMARY");

                entity.ToTable("consommable");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_consommable_to_craft_idx");

                entity.HasIndex(e => e.IdImage)
                    .HasName("fk_consommable_to_image_idx");

                entity.HasIndex(e => e.IdTypeConsommable)
                    .HasName("fk_consommable_to_type_consommable_idx");

                entity.Property(e => e.IdConsommable)
                    .HasColumnName("id_consommable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdImage)
                    .HasColumnName("id_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeConsommable)
                    .HasColumnName("id_type_consommable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.Consommable)
                    .HasForeignKey(d => d.IdCraft)
                    .HasConstraintName("fk_consommable_to_craft");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.Consommable)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("fk_consommable_to_image");

                entity.HasOne(d => d.IdTypeConsommableNavigation)
                    .WithMany(p => p.Consommable)
                    .HasForeignKey(d => d.IdTypeConsommable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consommable_to_type_consommable");
            });

            modelBuilder.Entity<ConsommableEffect>(entity =>
            {
                entity.HasKey(e => e.IdConsommableEffect)
                    .HasName("PRIMARY");

                entity.ToTable("consommable_effect");

                entity.HasIndex(e => e.IdConsommable)
                    .HasName("fk_consommable_effect_to_consommable_idx");

                entity.Property(e => e.IdConsommableEffect)
                    .HasColumnName("id_consommable_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect")
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdConsommable)
                    .HasColumnName("id_consommable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdConsommableNavigation)
                    .WithMany(p => p.ConsommableEffect)
                    .HasForeignKey(d => d.IdConsommable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consommable_effect_to_consommable");
            });

            modelBuilder.Entity<Craft>(entity =>
            {
                entity.HasKey(e => e.IdCraft)
                    .HasName("PRIMARY");

                entity.ToTable("craft");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<CraftArme>(entity =>
            {
                entity.HasKey(e => e.IdCraftArme)
                    .HasName("PRIMARY");

                entity.ToTable("craft_arme");

                entity.HasIndex(e => e.IdArme)
                    .HasName("fk_craft_to_arme_idx");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_craft_arme_to_craft_idx");

                entity.Property(e => e.IdCraftArme)
                    .HasColumnName("id_craft_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdArme)
                    .HasColumnName("id_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdArmeNavigation)
                    .WithMany(p => p.CraftArme)
                    .HasForeignKey(d => d.IdArme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_arme_to_arme");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.CraftArme)
                    .HasForeignKey(d => d.IdCraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_arme_to_craft");
            });

            modelBuilder.Entity<CraftConsommable>(entity =>
            {
                entity.HasKey(e => e.IdCraftConsommable)
                    .HasName("PRIMARY");

                entity.ToTable("craft_consommable");

                entity.HasIndex(e => e.IdConsommable)
                    .HasName("fk_craft_consommable_to_consommable_idx");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_craft_consommable_to_craft_idx");

                entity.Property(e => e.IdCraftConsommable)
                    .HasColumnName("id_craft_consommable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdConsommable)
                    .HasColumnName("id_consommable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdConsommableNavigation)
                    .WithMany(p => p.CraftConsommable)
                    .HasForeignKey(d => d.IdConsommable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_consommable_to_consommable");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.CraftConsommable)
                    .HasForeignKey(d => d.IdCraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_consommable_to_craft");
            });

            modelBuilder.Entity<CraftEquipement>(entity =>
            {
                entity.HasKey(e => e.IdCraftEquipement)
                    .HasName("PRIMARY");

                entity.ToTable("craft_equipement");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_craft_equipement_to_craft_idx");

                entity.HasIndex(e => e.IdEquipement)
                    .HasName("fk_craft_equipement_to_equipement_idx");

                entity.Property(e => e.IdCraftEquipement)
                    .HasColumnName("id_craft_equipement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEquipement)
                    .HasColumnName("id_equipement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.CraftEquipement)
                    .HasForeignKey(d => d.IdCraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_equipement_to_craft");

                entity.HasOne(d => d.IdEquipementNavigation)
                    .WithMany(p => p.CraftEquipement)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_equipement_to_equipement");
            });

            modelBuilder.Entity<CraftRessource>(entity =>
            {
                entity.HasKey(e => e.IdCraftRessource)
                    .HasName("PRIMARY");

                entity.ToTable("craft_ressource");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_craft_ressource_to_craft_idx");

                entity.HasIndex(e => e.IdRessource)
                    .HasName("fk_craft_ressource_to_ressource_idx");

                entity.Property(e => e.IdCraftRessource)
                    .HasColumnName("id_craft_ressource")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdRessource)
                    .HasColumnName("id_ressource")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.CraftRessource)
                    .HasForeignKey(d => d.IdCraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_ressource_to_craft");

                entity.HasOne(d => d.IdRessourceNavigation)
                    .WithMany(p => p.CraftRessource)
                    .HasForeignKey(d => d.IdRessource)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_craft_ressource_to_ressource");
            });

            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.HasKey(e => e.IdEquipement)
                    .HasName("PRIMARY");

                entity.ToTable("equipement");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_equipement_to_craft_idx");

                entity.HasIndex(e => e.IdImage)
                    .HasName("fk_equipement_to_image_idx");

                entity.HasIndex(e => e.IdTypeEquipement)
                    .HasName("fk_equipement_to_type_equipement_idx");

                entity.Property(e => e.IdEquipement)
                    .HasColumnName("id_equipement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdImage)
                    .HasColumnName("id_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeEquipement)
                    .HasColumnName("id_type_equipement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.Equipement)
                    .HasForeignKey(d => d.IdCraft)
                    .HasConstraintName("fk_equipement_to_craft");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.Equipement)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("fk_equipement_to_image");

                entity.HasOne(d => d.IdTypeEquipementNavigation)
                    .WithMany(p => p.Equipement)
                    .HasForeignKey(d => d.IdTypeEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipement_to_type_equipement");
            });

            modelBuilder.Entity<EquipementCondition>(entity =>
            {
                entity.HasKey(e => e.IdEquipementCondition)
                    .HasName("PRIMARY");

                entity.ToTable("equipement_condition");

                entity.HasIndex(e => e.IdEquipement)
                    .HasName("fk_condition_to_equipement_idx");

                entity.Property(e => e.IdEquipementCondition)
                    .HasColumnName("id_equipement_condition")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasColumnName("condition")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdEquipement)
                    .HasColumnName("id_equipement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEquipementNavigation)
                    .WithMany(p => p.EquipementCondition)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_condition_to_equipement");
            });

            modelBuilder.Entity<EquipementEffect>(entity =>
            {
                entity.HasKey(e => e.IdEquipementEffect)
                    .HasName("PRIMARY");

                entity.ToTable("equipement_effect");

                entity.HasIndex(e => e.IdEquipement)
                    .HasName("fk_equipement_effect_to_equipement_idx");

                entity.HasIndex(e => e.IdTypeCaracteristique)
                    .HasName("fk_equipement_effect_to_type_caracteristique_idx");

                entity.HasIndex(e => e.IdTypeEffect)
                    .HasName("fk_equipement_effect_to_type_effect_idx");

                entity.Property(e => e.IdEquipementEffect)
                    .HasColumnName("id_equipement_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect")
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdEquipement)
                    .HasColumnName("id_equipement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeCaracteristique)
                    .HasColumnName("id_type_caracteristique")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeEffect)
                    .HasColumnName("id_type_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEquipementNavigation)
                    .WithMany(p => p.EquipementEffect)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipement_effect_to_equipement");

                entity.HasOne(d => d.IdTypeCaracteristiqueNavigation)
                    .WithMany(p => p.EquipementEffect)
                    .HasForeignKey(d => d.IdTypeCaracteristique)
                    .HasConstraintName("fk_equipement_effect_to_type_caracteristique");

                entity.HasOne(d => d.IdTypeEffectNavigation)
                    .WithMany(p => p.EquipementEffect)
                    .HasForeignKey(d => d.IdTypeEffect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipement_effect_to_type_effect");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.IdImage)
                    .HasName("PRIMARY");

                entity.ToTable("image");

                entity.Property(e => e.IdImage)
                    .HasColumnName("id_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImgFilename)
                    .IsRequired()
                    .HasColumnName("img_filename")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            modelBuilder.Entity<Ressource>(entity =>
            {
                entity.HasKey(e => e.IdRessource)
                    .HasName("PRIMARY");

                entity.ToTable("ressource");

                entity.HasIndex(e => e.IdCraft)
                    .HasName("fk_ressource_to_craft_idx");

                entity.HasIndex(e => e.IdImage)
                    .HasName("fk_ressource_to_image_idx");

                entity.HasIndex(e => e.IdTypeRessource)
                    .HasName("fk_ressource_to_type_ressource_idx");

                entity.Property(e => e.IdRessource)
                    .HasColumnName("id_ressource")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdCraft)
                    .HasColumnName("id_craft")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdImage)
                    .HasColumnName("id_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTypeRessource)
                    .HasColumnName("id_type_ressource")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCraftNavigation)
                    .WithMany(p => p.Ressource)
                    .HasForeignKey(d => d.IdCraft)
                    .HasConstraintName("fk_ressource_to_craft");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.Ressource)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("fk_ressource_to_image");

                entity.HasOne(d => d.IdTypeRessourceNavigation)
                    .WithMany(p => p.Ressource)
                    .HasForeignKey(d => d.IdTypeRessource)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ressource_to_type_ressource");
            });

            modelBuilder.Entity<RessourceEffect>(entity =>
            {
                entity.HasKey(e => e.IdRessourceEffect)
                    .HasName("PRIMARY");

                entity.ToTable("ressource_effect");

                entity.HasIndex(e => e.IdRessource)
                    .HasName("fk_ressource_effect_to_ressource_idx");

                entity.Property(e => e.IdRessourceEffect)
                    .HasColumnName("id_ressource_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect")
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdRessource)
                    .HasColumnName("id_ressource")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdRessourceNavigation)
                    .WithMany(p => p.RessourceEffect)
                    .HasForeignKey(d => d.IdRessource)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ressource_effect_to_ressource");
            });

            modelBuilder.Entity<Spell>(entity =>
            {
                entity.HasKey(e => e.IdSpell)
                    .HasName("PRIMARY");

                entity.ToTable("spell");

                entity.HasIndex(e => e.IdClass)
                    .HasName("fk_spell_to_class_idx");

                entity.HasIndex(e => e.IdImage)
                    .HasName("fk_spell_to_img_idx");

                entity.Property(e => e.IdSpell)
                    .HasColumnName("id_spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdClass)
                    .HasColumnName("id_class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdImage)
                    .HasColumnName("id_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Spell)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_spell_to_class");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.Spell)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("fk_spell_to_img");
            });

            modelBuilder.Entity<SpellDetail>(entity =>
            {
                entity.HasKey(e => e.IdSpellDetail)
                    .HasName("PRIMARY");

                entity.ToTable("spell_detail");

                entity.HasIndex(e => e.IdSpell)
                    .HasName("fk_spell_detail_to_spell_idx");

                entity.Property(e => e.IdSpellDetail)
                    .HasColumnName("id_spell_detail")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdjustableRange).HasColumnName("adjustable_range");

                entity.Property(e => e.ApCost)
                    .IsRequired()
                    .HasColumnName("ap_cost")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.CriticalHitProbability)
                    .IsRequired()
                    .HasColumnName("critical_hit_probability")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.FailureEndsTurn).HasColumnName("failure_ends_turn");

                entity.Property(e => e.FailureProbability)
                    .IsRequired()
                    .HasColumnName("failure_probability")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.FreeCells).HasColumnName("free_cells");

                entity.Property(e => e.HasCriticalEffect).HasColumnName("has_critical_effect");

                entity.Property(e => e.HasGlyphInfo).HasColumnName("has_glyph_info");

                entity.Property(e => e.HasSummonInfo).HasColumnName("has_summon_info");

                entity.Property(e => e.HasTrapInfo).HasColumnName("has_trap_info");

                entity.Property(e => e.IdSpell)
                    .HasColumnName("id_spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LineOfSight).HasColumnName("line_of_sight");

                entity.Property(e => e.Linear).HasColumnName("linear");

                entity.Property(e => e.NbCastPerTurn)
                    .IsRequired()
                    .HasColumnName("nb_cast_per_turn")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.NbCastPerTurnPerPlayer)
                    .IsRequired()
                    .HasColumnName("nb_cast_per_turn_per_player")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.NbTurnsBetweenTwoCasts)
                    .IsRequired()
                    .HasColumnName("nb_turns_between_two_casts")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Range)
                    .IsRequired()
                    .HasColumnName("range")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.RequiredLvl)
                    .HasColumnName("required_lvl")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpellLvl)
                    .HasColumnName("spell_lvl")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.IdSpellNavigation)
                    .WithMany(p => p.SpellDetail)
                    .HasForeignKey(d => d.IdSpell)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_spell_detail_to_spell");
            });

            modelBuilder.Entity<SpellEffect>(entity =>
            {
                entity.HasKey(e => e.IdSpellEffect)
                    .HasName("PRIMARY");

                entity.ToTable("spell_effect");

                entity.HasIndex(e => e.IdSpellDetail)
                    .HasName("fk_spell_effect_to_spell_detail_idx");

                entity.Property(e => e.IdSpellEffect)
                    .HasColumnName("id_spell_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnName("effect")
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.Element)
                    .HasColumnName("element")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.Property(e => e.IdSpellDetail)
                    .HasColumnName("id_spell_detail")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");

                entity.HasOne(d => d.IdSpellDetailNavigation)
                    .WithMany(p => p.SpellEffect)
                    .HasForeignKey(d => d.IdSpellDetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_spell_effect_to_spell_detail");
            });

            modelBuilder.Entity<TypeArme>(entity =>
            {
                entity.HasKey(e => e.IdTypeArme)
                    .HasName("PRIMARY");

                entity.ToTable("type_arme");

                entity.Property(e => e.IdTypeArme)
                    .HasColumnName("id_type_arme")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            modelBuilder.Entity<TypeCaracteristique>(entity =>
            {
                entity.HasKey(e => e.IdTypeCaracteristique)
                    .HasName("PRIMARY");

                entity.ToTable("type_caracteristique");

                entity.Property(e => e.IdTypeCaracteristique)
                    .HasColumnName("id_type_caracteristique")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            modelBuilder.Entity<TypeConsommable>(entity =>
            {
                entity.HasKey(e => e.IdTypeConsommable)
                    .HasName("PRIMARY");

                entity.ToTable("type_consommable");

                entity.Property(e => e.IdTypeConsommable)
                    .HasColumnName("id_type_consommable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            modelBuilder.Entity<TypeEffect>(entity =>
            {
                entity.HasKey(e => e.IdTypeEffect)
                    .HasName("PRIMARY");

                entity.ToTable("type_effect");

                entity.Property(e => e.IdTypeEffect)
                    .HasColumnName("id_type_effect")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            modelBuilder.Entity<TypeEquipement>(entity =>
            {
                entity.HasKey(e => e.IdTypeEquipement)
                    .HasName("PRIMARY");

                entity.ToTable("type_equipement");

                entity.Property(e => e.IdTypeEquipement)
                    .HasColumnName("id_type_equipement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            modelBuilder.Entity<TypeRessource>(entity =>
            {
                entity.HasKey(e => e.IdTypeRessource)
                    .HasName("PRIMARY");

                entity.ToTable("type_ressource");

                entity.Property(e => e.IdTypeRessource)
                    .HasColumnName("id_type_ressource")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_520_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
