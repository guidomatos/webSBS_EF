using System;

namespace SBS.Utils
{
    public class Funciones
    {
        public static bool ValidarFecha(string fechaValidar, out DateTime fecha)
        {
            fecha = new DateTime();
            var arrayFecha = fechaValidar.Split('/');

            if (arrayFecha.Length == 3)
            {
                bool resultado;

                resultado = Int32.TryParse(arrayFecha[0], out _);
                if (!resultado) return false;

                resultado = Int32.TryParse(arrayFecha[1], out _);
                if (!resultado) return false;

                resultado = Int32.TryParse(arrayFecha[2], out _);
                if (!resultado) return false;

                var dia = Convert.ToInt32(arrayFecha[0]);
                var mes = Convert.ToInt32(arrayFecha[1]);
                var anio = Convert.ToInt32(arrayFecha[2]);

                try
                {
                    fecha = new DateTime(anio, mes, dia);
                    return true;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}