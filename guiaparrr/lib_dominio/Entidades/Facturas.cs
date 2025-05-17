using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Facturas
    {
        [Key] public int Id { get; set; }
        public string? NombreCliente { get; set; }
        public decimal Total { get; set; }
        public string? Nota { get; set; }
        public DateTime Fecha { get; set; }
        


        

        
    }
}
