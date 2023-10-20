﻿using Microsoft.EntityFrameworkCore;
using NewsApp.Noticias;
using NewsApp.Listas;
using NewsApp.Usuarios;
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
    public DbSet<Fuente> Fuentes { get; set; }
    public DbSet<Lista> Listas { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<IdiomaPreferencia> IdiomasPreferencia { get; set; }
    public DbSet<UltimaVisita> UltimasVisitas { get; set; }

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

        

    /* Configure your own tables/entities inside here */



    //builder.Entity<YourEntity>(b =>
    //{
    //    b.ToTable(NewsAppConsts.DbTablePrefix + "YourEntities", NewsAppConsts.DbSchema);
    //    b.ConfigureByConvention(); //auto configure for the base class props
    //    //...
    //});

    // Entidad Fuente
    builder.Entity<Fuente>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Fuentes", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
    });

    // Entidad Noticia

    builder.Entity<Noticia>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Noticias", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.Titulo).IsRequired().HasMaxLength(128);
        b.Property(x => x.Autor).IsRequired().HasMaxLength(128);
    }
    );

    // Entidad Etiqueta
    builder.Entity<Etiqueta>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Etiquetas", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.CadenaClave).IsRequired().HasMaxLength(128);
    });

    // Entidad Lista

    builder.Entity<Lista>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Listas", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.Nombre).IsRequired().HasMaxLength(128);
    });

    // Entidad Pais

    builder.Entity<Pais>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Paises", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.Codigo).IsRequired().HasMaxLength(2);
    });

    // Entidad IdiomaPrefencia

    builder.Entity<IdiomaPreferencia>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "IdiomasPreferencia", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.Idioma).IsRequired().HasMaxLength(2);
    });

    // Entidad Usuario

        builder.Entity<Usuario>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "Usuarios", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.NombreUsuario).IsRequired().HasMaxLength(128);
        b.Property(x => x.Email).IsRequired().HasMaxLength(128);
    });

    // Entidad UltimaVisita

    builder.Entity<UltimaVisita>(b =>
    {
        b.ToTable(NewsAppConsts.DbTablePrefix + "UltimasVisitas", NewsAppConsts.DbSchema);
        b.ConfigureByConvention(); //auto configure for the base class props
        b.Property(x => x.NombreUsuario).IsRequired().HasMaxLength(128);
        b.Property(x => x.UrlNoticia).IsRequired().HasMaxLength(128);
        b.Property(x => x.Fecha).IsRequired();
    });

    }
}