using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace NewsApp.Alertas
{
    public class AlertaAppService : NewsAppAppService, IAlertaAppService
    {
        private readonly IRepository<Alerta> _alertaRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AlertaManager _alertaManager;

        public AlertaAppService(
            IAlertaRepository alertaRepository,
            AlertaManager alertaManager,
            UserManager<IdentityUser> userManager)

        {
            _alertaRepository = alertaRepository;
            _userManager = userManager;
            _alertaManager = alertaManager;
        }

        public async Task<AlertaDto> PostAlertaAsync(string cadenaBusqueda)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var usuario = await _userManager.FindByIdAsync(userGuid.ToString());
            var alerta = await _alertaManager.CreateAsync(cadenaBusqueda, usuario);
            var respuesta = await _alertaRepository.InsertAsync(alerta, autoSave: true);
            return ObjectMapper.Map<Alerta, AlertaDto>(respuesta);
        }

    }
}