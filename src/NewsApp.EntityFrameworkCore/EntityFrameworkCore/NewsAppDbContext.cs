using Microsoft.EntityFrameworkCore;
using NewsApp.Noticias;
using NewsApp.Listas;
using NewsApp.Alertas;
using System;
using System.Security.Cryptography.X509Certificates;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace NewsApp.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class NewsAppDbContext :
    AbpDbContext<NewsAppDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    #region Entidades de dominio
    public DbSet<Noticia> Noticias { get; set; }
    public DbSet<Lista> Listas { get; set; }
    public DbSet<Alerta> Alertas { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }

    #endregion

    public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        // MANEJO DE COLECCIONES DE string
        var stringListConverter = new ValueConverter<ICollection<string>, string>(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

        var stringListComparer = new ValueComparer<ICollection<string>>(
           (c1, c2) => c1.SequenceEqual(c2),
           c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
           c => (ICollection<string>)c.ToList());

        /* Configure your own tables/entities inside here */



        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(NewsAppConsts.DbTablePrefix + "YourEntities", NewsAppConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});


    // Entidad Noticia

    builder.Entity<Noticia>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Noticias", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.Titulo).IsRequired().HasMaxLength(128);
    }
    );

    // Entidad Lista

    builder.Entity<Lista>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Listas", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.Nombre).IsRequired().HasMaxLength(128);
    });

    // Entidad Alerta
    builder.Entity<Alerta>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Alertas", NewsAppConsts.DbSchema);
        b.ConfigureByConvention();
    });

    // Entidad Notificación
    builder.Entity<Notificacion>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Notificaciones", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
    });

    }
}
