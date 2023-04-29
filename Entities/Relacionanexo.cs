using System;
using System.Collections.Generic;

namespace ProyectoExcel.Entities
{
    public partial class Relacionanexo
    {
        public int Id { get; set; }
        public string? Seccion { get; set; }
        public string? Clave { get; set; }
        public string? NombreAnexo { get; set; }
        public string? Articulo { get; set; }
        public string? Aplica { get; set; }
    }
}
