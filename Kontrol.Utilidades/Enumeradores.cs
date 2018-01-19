using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrol.Utilidades
{

    public enum Crud
    {
        consultar = 1,
        insertar = 2,
        actualizar = 3,
        eliminar = 4,
        jsconsultar = 5,
        error = 100
    }

    public class Enumeradores
    {

        public static T ParseEnum<T>(string value, T error)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                return error;
            }

        }

    }
}
