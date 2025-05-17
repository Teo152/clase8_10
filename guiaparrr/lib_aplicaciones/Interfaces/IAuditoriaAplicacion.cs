using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IAuditoriaAplicacion
    {
        void Configurar(string StringConexion);
        List<Auditoria> Listar();
        Auditoria? PorId(int Id);
        Auditoria Guardar(Auditoria Auditoria);
        bool Eliminar(int Id);
        Auditoria Actualizar(Auditoria Auditoria);
    }
}
