using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Zapatos
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal precio { get; set; }

        public int? Facturas { get; set; }

        [ForeignKey("Facturas")] public Facturas? _Facturas { get; set; }
    }
}
