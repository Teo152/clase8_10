using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IZapatosAplicacion
    {
        void Configurar(string StringConexion);
        List<Zapatos> Listar();
        Zapatos? PorId(int Id);
        Zapatos Guardar(Zapatos Zapatos);
        bool Eliminar(int Id);
        Zapatos Actualizar(Zapatos Zapatos);
    }
}