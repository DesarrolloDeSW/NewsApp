﻿using NewsApp.BackgroundWorkers;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace NewsApp;

[DependsOn(
    typeof(NewsAppDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(NewsAppApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class NewsAppApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<NewsAppApplicationModule>();
        });
    }

    public override async Task OnApplicationInitializationAsync(
        ApplicationInitializationContext context) => await context.AddBackgroundWorkerAsync<BusquedaWorker>();
}


