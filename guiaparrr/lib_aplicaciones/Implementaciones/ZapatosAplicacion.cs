using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class ZapatosAplicacion : IZapatosAplicacion
    {
        private IConexion? Iconexion = null;

        public ZapatosAplicacion(IConexion iconexion)
        {
            this.Iconexion = iconexion;
        }

        public void Configurar(string StringConexion)
        {
            this.Iconexion!.StringConexion = StringConexion;
        }

        public List<Zapatos> Listar()
        {
            return Iconexion!.Zapatos.ToList();
        }

        public Zapatos? PorId(int Id)
        {
            return Iconexion!.Zapatos.FirstOrDefault(actual => actual.Id == Id);
        }

        public Zapatos Guardar(Zapatos mesa)
        {
            Iconexion!.Zapatos.Add(mesa);
            Iconexion.SaveChanges();
            return mesa;
        }

        public bool Eliminar(int Id)
        {
            var mesa = Iconexion!.Zapatos.FirstOrDefault(actual => actual.Id == Id);

            if (mesa != null)
            {
                Iconexion.Zapatos.Remove(mesa);
                Iconexion.SaveChanges();
                return true;
            }

            return false;
        }


        public Zapatos Actualizar(Zapatos Zapatos)
        {
            Zapatos.NombreCliente = "nombre modificado";

            var entry = this.Iconexion!.Entry<Zapatos>(Zapatos);
            entry.State = EntityState.Modified;
            this.Iconexion.SaveChanges();
            return Zapatos;
        }
    }
}
