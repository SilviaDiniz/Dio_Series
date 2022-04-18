using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Series.Classes;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> ListaSerie();
        T RetornaId(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();  
    }
}