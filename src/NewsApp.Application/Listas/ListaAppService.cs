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

namespace NewsApp.Listas
{
    public class ListaAppService : NewsAppAppService, IListaAppService
    {
        private readonly IListaRepository _listaRepository;
        private readonly ListaManager _listaManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ListaAppService(
            IListaRepository listaRepository,
            ListaManager listaManager, UserManager<IdentityUser> userManager)
        {
            _listaRepository = listaRepository;
            _listaManager = listaManager;
            _userManager = userManager;
        }

        public async Task<ICollection<ListaDto>> GetListasAsync()
        {
            var listas = await _listaRepository.GetListAsync(includeDetails:true); ;

            return ObjectMapper.Map<ICollection<Lista>, ICollection<ListaDto>>(listas);
        }
        public async Task<ListaDto> GetListaAsync(int id)
        {
            var queryable = await _listaRepository.WithDetailsAsync(x => x.Listas);

            var query = queryable.Where(x => x.Id == id);

            var lista = await AsyncExecuter.FirstOrDefaultAsync(query);

            return ObjectMapper.Map<Lista, ListaDto>(lista);

        }

        public async Task<ListaDto> PostListaAsync(CreateListaDto input)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var usuario = await _userManager.FindByIdAsync(userGuid.ToString());
            var lista = await _listaManager.CreateAsync(input.Nombre, input.Descripcion, input.ParentId, usuario);
            var respuesta = await _listaRepository.InsertAsync(lista, autoSave:true);
            return ObjectMapper.Map<Lista, ListaDto>(respuesta);
        }

        public async Task<ListaDto> UpdateListaAsync(UpdateListaDto input)
        {
            var lista = await _listaRepository.GetAsync(input.Id);

            if (input.Nombre != null)
            {
                if (lista.Nombre!= input.Nombre)
                { await _listaManager.CambiarNombreAsync(lista, input.Nombre); }
            }

            if (input.Descripcion != null)
            {
                if (lista.Descripcion != input.Descripcion)
                { await _listaManager.CambiarDescripcionAsync(lista, input.Descripcion); }
            }

            var respuesta = await _listaRepository.UpdateAsync(lista, autoSave:true);
            return ObjectMapper.Map<Lista, ListaDto>(respuesta);
        }

        public async Task<ListaDto> DeleteListaAsync(int id)
        {
            var respuesta = await _listaRepository.GetAsync(id);
            await _listaRepository.DeleteAsync(id);
            return ObjectMapper.Map<Lista, ListaDto>(respuesta);
        }
    }
}
