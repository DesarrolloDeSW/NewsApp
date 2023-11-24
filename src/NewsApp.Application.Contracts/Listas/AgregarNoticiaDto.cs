using NewsApp.Noticias;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Listas
{
    public class AgregarNoticiaDto
    {
        public NoticiaDto Noticia { get; set; }
        public int IdLista {  get; set; }
    }
}
