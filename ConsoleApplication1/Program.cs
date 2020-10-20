using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static string[] fechas = {
            // entre 1760 y 1830 
            "Un día del período de la Industria 1.0 que se caracterizó por la predominancia de las industrias metalúrgica, textil y por el ferrocarril como principal medio de transporte, que utilizaba el carbón como fuente de energía. Por su parte, el telégrafo y el teléfono revolucionaron la forma en la que las comunicaciones eran concebidas hasta ese momento.",
            // entre 1850 y 1914 
            "Un día del período de la Industria 2.0 el cual supuso el desarrollo de las industrias química, eléctrica y automovilística. El coche y más tarde el avión, nacieron al albor de los cambios en este segundo periodo, que se extendió durante más de un siglo. Estos medios cambiaron el carbón por el petróleo como fuente de energía.",
            // entre 1960 y 1970 
            "Un día del período de la Industria 3.0 caracterizada por el uso de la electrónica, las tecnologías de la información y las telecomunicaciones. Estos cambios permitieron la automatización de los procesos de producción y el surgimiento de Internet, que sin duda, ha supuesto una importante innovación en nuestro modo de ver y entender la vida y sobre todo la comunicación. Las energías alternativas y renovables, la nuclear y el petróleo se han erigido durante estos años como las principales fuentes de energía.",
            // entre 2011 y 2020 
            "Un día del período de la Industria 4.0, esta nueva revolución no ha hecho sino multiplicar la velocidad, el alcance y el impacto de las herramientas que surgieron en el periodo anterior, mediante la conexión de los mundos digital, físico y biológico. Fábricas inteligentes, lugares de producción en los que los dispositivos están conectados entre sí con el objetivo de difuminar las barreras entre la demanda, el diseño, la fabricación y el suministro."
        };

        private static DateTime fechaActual = DateTime.Today;

        static void Main(string[] args)
        {
            bool menuLoop = true;
            do
            {
                Console.WriteLine("Introduce una fecha de la revolución industrial");
                int dia = Convert.ToInt32(Console.ReadLine());
                int mes = Convert.ToInt32(Console.ReadLine());
                int year = Convert.ToInt32(Console.ReadLine());

                DateTime fecha = convertirFecha(dia,mes,year);

                if (imprimirValidacion(fecha) == true)
                    imprimirLapso(fecha);
                
            } while (menuLoop == true);
        }

        public static DateTime convertirFecha(int dia, int mes, int year)
        {
            DateTime fecha = new DateTime(dia, mes, year);
            return fecha;
        }

        /* 
        Recibe una fecha y válida que no sea mayor a la fecha actual (2), 
        que no esté fuera del rango de la tira de 1700 a 2100 (1) o que sea
        menor al año 1760 (3). En caso de ser valida retorna 0.
        */
        public static int validarRangoFecha(DateTime fecha)
        {
            if (fecha.Year < 1700 || fecha.Year > 2100)
                return 1;
            if (fecha > fechaActual)
                return 2;
            if (fecha.Year < 1760)
                return 3;
            return 0;
        }

        public static bool imprimirValidacion(DateTime fecha)
        {
            int rangoValidado = validarRangoFecha(fecha);

            switch (rangoValidado)
            {
                case 1:
                    Console.WriteLine("Ups! Fuera de rango.");
                    return false;
                case 2:
                    Console.WriteLine("Ups! No sé adivinar el futuro.");
                    return false;
                case 3:
                    Console.WriteLine("Ups! La industria todavía no surgía como tal.");
                    return false;
                case 0:
                    return true;
            }

            return false;
        }

        /*
        Esta función solo recibirá fechas válidas que sucedan en la revolución industrial 
        (1760 - 2020)
        Recibe una fecha. Calcula el lapso al que pertenece la fecha. En caso de no pertenecer
        a ningún lapso significa que es una transición industrial.
        */
        public static int calcularFecha(DateTime fecha)
        {
            int year = fecha.Year;

            if (year >= 1760 && year <= 1830)
                return 1;
            if (year >= 1850 && year <= 1914)
                return 2;
            if (year >= 1960 && year <= 1970)
                return 3;
            if (year >= 2011 && year <= 2020)
                return 4;
            return 0;
        }

        public static void imprimirLapso(DateTime fecha)
        {
            int lapso = calcularFecha(fecha);

            switch (lapso)
            {
                case 1:
                    Console.WriteLine(fechas[0]);
                    break;
                case 2:
                    Console.WriteLine(fechas[1]);
                    break;
                case 3:
                    Console.WriteLine(fechas[2]);
                    break;
                case 4:
                    Console.WriteLine(fechas[3]);
                    break;
                case 0:
                    Console.WriteLine("Período de transición entre evoluciones industriales.");
                    break;
            }
        }
    }
}
