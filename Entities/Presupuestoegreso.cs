using System;
using System.Collections.Generic;

namespace ProyectoExcel.Entities
{
    public partial class Presupuestoegreso
    {
        public int IdPresupuestoEgreso { get; set; }
        public string? Secretaria { get; set; }
        public string? Direccion { get; set; }
        public string? IPreEstim { get; set; }
        public string? IPreMod { get; set; }
        public string? IPreDev { get; set; }
        public string? IPreReca { get; set; }
        public string? EPreOrigApro { get; set; }
        public string? E1aAmpPres { get; set; }
        public string? E2aAmpPres { get; set; }
        public string? E3aAmpPres { get; set; }
        public string? ETotAmp { get; set; }
        public string? EPreModif { get; set; }
        public string? EPreComp { get; set; }
        public string? EPreDev { get; set; }
        public string? EPreEjer { get; set; }
        public string? EPreErog { get; set; }
        public string? EPreCons { get; set; }
        public string? EPrePorEjer { get; set; }
        public string? FechaCorte { get; set; }
    }
}
