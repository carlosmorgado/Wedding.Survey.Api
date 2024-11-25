using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Wedding.Survey.Core;
using Wedding.Survey.Core.SurveyAnswers;
using Wedding.Survey.Infrastructure.EntityConfiguration;

namespace Wedding.Survey.Infrastructure;
public class SurveyContext : DbContext, ISurveyContext
{
    public SurveyContext(DbContextOptions<SurveyContext> options)
        : base(options)
    {
    }

    public DbSet<SurveyAnswer> Answers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		new SurveyAnswerEntityTypeConfiguration().Configure(modelBuilder.Entity<SurveyAnswer>());
	}

	public override int SaveChanges()
	{
		foreach (var tradeEntry in this.ChangeTracker.Entries<SurveyAnswer>())
		{
			if (tradeEntry.State == EntityState.Added)
			{
				tradeEntry.Entity.CreationDate = DateTimeOffset.UtcNow;
			}
		}

		return base.SaveChanges();
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		foreach (var tradeEntry in this.ChangeTracker.Entries<SurveyAnswer>())
		{
			if (tradeEntry.State == EntityState.Added)
			{
				tradeEntry.Entity.CreationDate = DateTimeOffset.UtcNow;
			}
		}

		return await base.SaveChangesAsync(cancellationToken);
	}
}
