using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IFacturasAplicacion
    {
        void Configurar(string StringConexion);
        List<Facturas> Listar();
        Facturas? PorId(int Id);
        Facturas Guardar(Facturas Facturas);
        bool Eliminar(int Id);
        Facturas Actualizar(Facturas Facturas);
    }
}
