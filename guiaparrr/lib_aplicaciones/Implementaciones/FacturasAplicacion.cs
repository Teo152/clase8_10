using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class FacturasAplicacion: IFacturasAplicacion
    {
        private IConexion? Iconexion = null;

        public FacturasAplicacion(IConexion iconexion)
        {
           this.Iconexion = iconexion;
        }

        public void Configurar(string StringConexion)
        {
            this.Iconexion!.StringConexion = StringConexion;
        }

        public List<Facturas> Listar()
        {
            return Iconexion!.Facturas.ToList();
        }

        public Facturas? PorId(int Id)
        {
            return Iconexion!.Facturas.FirstOrDefault(actual => actual.Id == Id);
        }

        public Facturas Guardar(Facturas mesa)
        {
            Iconexion!.Facturas.Add(mesa);
            Iconexion.SaveChanges();
            return mesa;
        }

        public bool Eliminar(int Id)
        {
            var mesa = Iconexion!.Facturas.FirstOrDefault(actual => actual.Id == Id);            

            if (mesa != null)
            {
                Iconexion.Facturas.Remove(mesa);
                Iconexion.SaveChanges();
                return true;
            }

            return false;
        }


        public Facturas Actualizar(Facturas facturas)
        {
            facturas.NombreCliente = "nombre modificado";

            var entry = this.Iconexion!.Entry<Facturas>(facturas);
            entry.State = EntityState.Modified;
            this.Iconexion.SaveChanges();
            return facturas;
        }
    }
}
