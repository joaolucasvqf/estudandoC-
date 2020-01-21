using System;
using System.Collections.Generic;
using System.Text;
using XGame.Domain.Arguments.Plataforma;

namespace XGame.Domain.Interfaces.Services
{
    class IServicePlataforma
    {
        AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest);
    }
}
