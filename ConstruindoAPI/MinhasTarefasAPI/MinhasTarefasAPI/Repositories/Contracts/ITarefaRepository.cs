﻿using Microsoft.AspNetCore.Identity;
using MinhasTarefasAPI.Models;
using System;
using System.Collections.Generic;

namespace MinhasTarefasAPI.Repositories.Contracts
{
    public interface ITarefaRepository
    {
        List<Tarefa> Sincronizacao(List<Tarefa> tarefas);
        List<Tarefa> Restauracao(ApplicationUser usuario, DateTime dataUltimaSincronizacao);
    }
}
