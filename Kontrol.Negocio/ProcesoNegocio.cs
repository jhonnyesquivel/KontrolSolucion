using Kontrol.Datos.Seguridad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrol.Negocio
{
    public class ProcesoNegocio
    {


        public int InsertarUsuario(SegUsuarios usuario)
        {
            int resultado = 0;
            try
            {
                using (var context = new ModeloSeguridad())
                {
                    context.SegUsuarios.Add(usuario);
                    context.SaveChanges();
                    resultado = usuario.IdUsuario;
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            return resultado;


        }


        public List<SegUsuarios> SeleccionarUsuarios(int idUsuario)
        {


            if (idUsuario > 0)
            {
                return new ModeloSeguridad().SegUsuarios.Where(x => x.IdUsuario == idUsuario).ToList();
            }
            else
            {
                return new ModeloSeguridad().SegUsuarios.ToList();
            }

            //using (var context = new ModeloSeguridad())
            //{
            //    var resultado = from c in context.SegUsuarios
            //                    select new SegUsuarios
            //                    {
            //                        IdUsuario = c.IdUsuario,
            //                        PrimerNombre = c.PrimerNombre,
            //                        SegundoNombre = c.SegundoNombre,
            //                        PrimerApellido = c.PrimerApellido,
            //                        SegundoApellido = c.SegundoApellido
            //                    };

            //    int a = 0;
            //}



            //using (var context = new ModeloSeguridad())
            //{
            //    resultado = context.SegUsuarios.Select(
            //        c => new
            //        {
            //            c.IdUsuario,
            //            c.PrimerNombre,
            //            c.SegundoNombre,
            //            c.PrimerApellido,
            //            c.SegundoApellido
            //        }).ToList();
            //}
            //return resultado;

        }


    }
}
