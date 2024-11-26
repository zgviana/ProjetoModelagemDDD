using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
