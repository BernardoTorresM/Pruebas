using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pruebas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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

        private static readonly DateTime fechaActual = DateTime.Today;

        private void EnCambioDeFecha(object sender, SelectionChangedEventArgs e)
        {
            DateTime fecha = (DateTime)selectorFecha.SelectedDate;
            if (ImprimirValidacion(fecha))
            {
                ImprimirLapso(fecha);
            }
        }

        public static int ValidarRangoFecha(DateTime fecha)
        {
            if (fecha.Year < 1700 || fecha.Year > 2100)
            {
                return 1;
            }else if (fecha > fechaActual)
            {
                return 2;
            }else if (fecha.Year < 1760)
            {
                return 3;
            }
            return 0;
        }

        private bool ImprimirValidacion(DateTime fecha)
        {
            int rangoValidado = ValidarRangoFecha(fecha);

            switch (rangoValidado)
            {
                case 1:
                    textoExplicativo.Text = "";
                    textoMalo.Content = "Ups! Fuera de rango.";
                    //Console.WriteLine("Ups! Fuera de rango.");
                    return false;
                case 2:
                    textoExplicativo.Text = "";
                    textoMalo.Content = "Ups! No sé adivinar el futuro.";
                    //Console.WriteLine("Ups! No sé adivinar el futuro.");
                    return false;
                case 3:
                    textoExplicativo.Text = "";
                    textoMalo.Content = "Ups! La industria todavía no surgía como tal.";
                    //Console.WriteLine("Ups! La industria todavía no surgía como tal.");
                    return false;
                case 0:
                    textoMalo.Content = "";
                    return true;
            }

            return false;
        }

        private void ImprimirLapso(DateTime fecha)
        {
            int lapso = CalcularFecha(fecha);

            switch (lapso)
            {
                case 1:
                    textoExplicativo.Text = fechas[0];
                    //Console.WriteLine(fechas[0]);
                    break;
                case 2:
                    textoExplicativo.Text = fechas[1];
                    //Console.WriteLine(fechas[1]);
                    break;
                case 3:
                    textoExplicativo.Text = fechas[2];
                    //Console.WriteLine(fechas[2]);
                    break;
                case 4:
                    textoExplicativo.Text = fechas[3];
                    //Console.WriteLine(fechas[3]);
                    break;
                case 0:
                    textoExplicativo.Text = "Período de transición entre evoluciones industriales.";
                    //Console.WriteLine("Período de transición entre evoluciones industriales.");
                    break;
            }
        }

        private int CalcularFecha(DateTime fecha)
        {
            int year = fecha.Year;

            if (year >= 1760 && year <= 1830)
            {
                return 1;
            } else if (year >= 1850 && year <= 1914)
            {
                return 2;
            } else if (year >= 1960 && year <= 1970)
            {
                return 3;
            } else if (year >= 2011 && year <= 2020)
            {
                return 4;
            }
            return 0;
        }
    }
}
