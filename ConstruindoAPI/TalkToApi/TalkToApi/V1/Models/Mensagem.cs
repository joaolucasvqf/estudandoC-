using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalkToApi.V1.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public ApplicationUser UsuarioUm { get; set; }
        public ApplicationUser UsuarioDois { get; set; }
        public ApplicationUser Dono { get; set; }
        public string Text { get; set; }
        public DateTime Criado { get; set; }

    }
}
