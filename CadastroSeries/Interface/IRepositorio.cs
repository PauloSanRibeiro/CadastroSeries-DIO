﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries.Interface
{
    public interface IRepositorio<T>
    {

        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T enidade);

        void Exclui(int id);

        void Atualiza(int id, T entidade);

        int ProximoId();



    }
}
