using System;
using System.Collections.Generic;
using System.Text;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Plataforma
{
    public class AdicionarPlataformaRequest : IRequest
    {
        public string Nome { get; set; }
    }
}
