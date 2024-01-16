using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using HorseMoney.Infrastructure.Identity;
using System.Reflection.Emit;
using System.Linq.Expressions;

namespace HorseMoney.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.GetProperty("IsDeleted") != null)
            {
                builder.Entity(entityType.Name).HasQueryFilter(GetIsDeletedRestriction(entityType.ClrType));
            }
        }

        base.OnModelCreating(builder);
    }

    private static LambdaExpression GetIsDeletedRestriction(Type type)
    {
        var param = Expression.Parameter(type, "t");
        var body = Expression.Equal(Expression.Property(param, "IsDeleted"), Expression.Constant(false));
        return Expression.Lambda(body, param);
    }
}