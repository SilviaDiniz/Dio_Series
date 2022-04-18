using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie> //busca da classe serie
    {
        private List<Serie> listaSerie = new List<Serie>();

		public void Atualizar(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Excluir(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Inserir(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> ListaSerie()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornaId(int id)
		{
			return listaSerie[id];
		}
    }
}