using System;

namespace DesafioManipulae.Domain
{
    public class VideoList
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public int Duracao { get; set; }
        public DateTime PublicadoEm { get; set; }
    }
}