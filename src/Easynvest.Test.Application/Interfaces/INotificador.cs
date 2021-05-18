using Easynvest.Test.Application.Notificacoes;
using System.Collections.Generic;

namespace Easynvest.Test.Application.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
