using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class AuditoriaAplicacion : IAuditoriaAplicacion
    {
        private IConexion? Iconexion = null;

        public AuditoriaAplicacion(IConexion iconexion)
        {
            this.Iconexion = iconexion;
        }

        public void Configurar(string StringConexion)
        {
            this.Iconexion!.StringConexion = StringConexion;
        }

        public List<Auditoria> Listar()
        {
            return Iconexion!.Auditoria.ToList();
        }

        public Auditoria? PorId(int Id)
        {
            return Iconexion!.Auditoria.FirstOrDefault(actual => actual.id == Id);
        }

        public Auditoria Guardar(Auditoria mesa)
        {
            Iconexion!.Auditoria.Add(mesa);
            Iconexion.SaveChanges();
            return mesa;
        }

        public bool Eliminar(int Id)
        {
            var mesa = Iconexion!.Auditoria.FirstOrDefault(actual => actual.id == Id);

            if (mesa != null)
            {
                Iconexion.Auditoria.Remove(mesa);
                Iconexion.SaveChanges();
                return true;
            }

            return false;
        }


        public Auditoria Actualizar(Auditoria Auditoria)
        {
            Auditoria.fecha = DateTime.Now;

            var entry = this.Iconexion!.Entry<Auditoria>(Auditoria);
            entry.State = EntityState.Modified;
            this.Iconexion.SaveChanges();
            return Auditoria;
        }

       
    }
}
