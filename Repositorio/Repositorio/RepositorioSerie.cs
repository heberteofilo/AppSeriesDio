using AppSeriesDio.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Repositorio
{
    public class RepositorioSerie : IRepositorio<Serie>
    {
        private List<Serie> ListaSerie { get; set; } = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            var atualizarItem = ListaSerie.Find(p => p.Id == id);
            if (atualizarItem != null)
            {
                ListaSerie.Remove(atualizarItem);
                ListaSerie.Add(entidade);
            }
        }

        public void Excluir(int id)
        {
            var removeItem = ListaSerie.Find(p => p.Id == id);
            ListaSerie.Remove(removeItem);
        }

        public void Inserir(Serie entidade)
        {
            ListaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            var proximoId = ListaSerie.Count;
            return proximoId + 1;
        }

        public Serie RetornaPorId(int id)
        {
            var listaSerie = ListaSerie.Find(p => p.Id == id);
            return listaSerie;
        }
    }
}
