using Microsoft.EntityFrameworkCore;

namespace PortfolioBuilder.Data
{
    public partial class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=AzurePortfolio");
        public virtual DbSet<Models.CareerRecord> CareerRecords { get; set; }
        public virtual DbSet<Models.SkillsRecord> SkillsRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Models.CareerRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.careerIcon).HasMaxLength(255);
                entity.Property(e => e.careerJobTitle).IsRequired().HasMaxLength(150);
                entity.Property(e => e.careerRoleTitle).IsRequired().HasMaxLength(150);
                entity.Property(e => e.careerShortDescription).HasMaxLength(150);
                entity.Property(e => e.careerLongDescription).IsRequired();
                entity.Property(e => e.careerStateDate).IsRequired();
                entity.Property(e => e.careerEndDate);
            });

            model.Entity<Models.SkillsRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.skillTitle).HasMaxLength(255);
                entity.Property(e => e.skillDescription).HasMaxLength(1000);
                entity.Property(e => e.skillProvider).HasMaxLength(255);
                entity.Property(e => e.skillDateAchieved);
                entity.HasOne(d => d.careerRecord)
                    .WithMany(p => p.skills)
                    .HasForeignKey(d => d.careerRecordId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SkillsRecord_CareerRecord");
            });
            OnModelCreatingPartial(model);
        }
        partial void OnModelCreatingPartial(ModelBuilder model);
    }
}
