using System;
using Geolocation;

namespace DPRN3_U1_EA_JHRM
{
    class Program
    {
        static void Main(string[] args)
        {
            //velocidad constate de 50km/h
            double velocidadConst = 50;
            double minutos = 60;

            //tarifa de 50 pesos por cada 2 km de recorrido
            double tarifaBase = 50;

            //****************Atributos usuario 1***************************************
            Usuario user1 = new Usuario();
            user1.OrigenLatitud = 20.628179005605872;
            user1.OrigenLongitud = -87.07239270745;
            user1.DestinoLatitud = 21.063852720380865;
            user1.DestinoLongitud = -86.8746208288232;
            //Fecha y hora de salida
            user1.FechaSalida = DateTime.Now;
            //Inicializa los valores de latitud y longitud en Geolocation
            //Coordinate origen = new Coordinate(user1.OrigenLatitud, user1.OrigenLongitud);
            user1.Origen = new Coordinate(user1.OrigenLatitud, user1.OrigenLongitud);
            //Coordinate destino = new Coordinate(user1.DestinoLatitud, user1.DestinoLongitud);
            user1.Destino = new Coordinate(user1.DestinoLatitud, user1.DestinoLongitud);

            //Calcular distancia entre origen y destino y convertirla de millas a km
            user1.Distancia = GeoCalculator.GetDistance(user1.Origen, user1.Destino, 1) * 1.609344;

            //convertir distancia de millas a km
            //double distanciaKM = distancia * 1.609344;
            //redondear distancia en KM
            //double distanciaKMRedondeado = Math.Round(user1.Distancia, 2);

            //string direccionCardinal = GeoCalculator.GetDirection(user1.Origen, user1.Destino);
            //Calcular dirección cardinal
            user1.DireccionCardinal = GeoCalculator.GetDirection(user1.Origen, user1.Destino);


            //double horaLlegada = user1.Distancia / velocidadConst * minutos;
            //calcular hora estimada de llegada
            user1.HoraLlegada = user1.Distancia / velocidadConst * minutos;

            //calcular costo de viaje
            //costoViaje = user1.Distancia / 2 * tarifaBase;
            user1.CostoViaje = user1.Distancia / 2 * tarifaBase;

            // redondeo de costo de viaje
            //double costoViajeRedondeado = Math.Round(user1.CostoViaje, 2);
            //redondedo
            //recorrido = Math.Round(user1.HoraLlegada, 2);

            //******************Usuario 1***************************************


            //****************Atributos usuario 2***************************************
            Usuario user2 = new Usuario();
            user2.OrigenLatitud = 20.631417767762144;
            user2.OrigenLongitud = -87.07215522552474;
            user2.DestinoLatitud = 20.242789823902815;
            user2.DestinoLongitud = -87.42783760103327;
            //Fecha y hora de salida
            user2.FechaSalida = DateTime.Now;
            //Inicializa los valores de latitud y longitud en Geolocation
            user2.Origen = new Coordinate(user2.OrigenLatitud, user2.OrigenLongitud);
            user2.Destino = new Coordinate(user2.DestinoLatitud, user2.DestinoLongitud);

            //Calcular distancia entre origen y destino y convertirla de millas a km
            user2.Distancia = GeoCalculator.GetDistance(user2.Origen, user2.Destino, 1) * 1.609344;

            //Calcular dirección cardinal
            user2.DireccionCardinal = GeoCalculator.GetDirection(user2.Origen, user2.Destino);

            //calcular hora estimada de llegada
            user2.HoraLlegada = user2.Distancia / velocidadConst * minutos;

            //calcular costo de viaje
            user2.CostoViaje = user2.Distancia / 2 * tarifaBase;

            //******************Usuario 2***************************************


            //Impresion de viaje usuario 1
            Console.WriteLine("Viaje de usuario 1");
            Console.WriteLine("Dirección cardinal:" + user1.DireccionCardinal);
            Console.WriteLine("Distancia en KM: "+ user1.Distancia);
            Console.WriteLine("Costo total de viaje: "+ user1.CostoViaje);
            Console.WriteLine("Fecha y hora de salida: "+ user1.FechaSalida);
            Console.WriteLine("Fecha y hora estimada de llegada: "+ user1.FechaSalida.AddMinutes(user1.HoraLlegada));
            Console.WriteLine("Tiempo estimado de recorrido en minutos: "+ user1.HoraLlegada);

            //Impresion de viaje usuario 2
            Console.WriteLine("Viaje de usuario 2");
            Console.WriteLine("Dirección cardinal:" + user2.DireccionCardinal);
            Console.WriteLine("Distancia en KM: " + user2.Distancia);
            Console.WriteLine("Costo total de viaje: " + user2.CostoViaje);
            Console.WriteLine("Fecha y hora de salida: " + user2.FechaSalida);
            Console.WriteLine("Fecha y hora estimada de llegada: " + user2.FechaSalida.AddMinutes(user2.HoraLlegada));
            Console.WriteLine("Tiempo estimado de recorrido en minutos: " + user2.HoraLlegada);

        }

        class Usuario
         {   
             //Ingresar la longitud de origen
             protected double origenLatitud;
             public double OrigenLatitud
             {
                 set { this.origenLatitud = value; }
                 get { return this.origenLatitud; }
             }

             //Ingresar la longitud de origen
             protected double origenLongitud;
             public double OrigenLongitud
             {
                 set { this.origenLongitud = value; }
                 get { return this.origenLongitud; }
             }

              //Ingresar la latitud de destino
             protected double destinoLatitud;
             public double DestinoLatitud
             {
                 set { this.destinoLatitud = value; }
                 get { return this.destinoLatitud; }
             }

             //Ingresar la longitud de destino
             protected double destinoLongitud;
             public double DestinoLongitud
             {
                 set { this.destinoLongitud = value; }
                 get { return this.destinoLongitud; }
             }

            //Ingresar fechar y hora de salida
            protected DateTime fechaSalida;
            public DateTime FechaSalida
            {
                set { this.fechaSalida = value; }
                get { return this.fechaSalida; }
            }

            //Ingresar coordenadas origen
            protected Coordinate origen;
            public Coordinate Origen
            {
                set { this.origen = value; }
                get { return this.origen; }
            }

            //Ingresar coordenadas destino
            protected Coordinate destino;
            public Coordinate Destino
            {
                set { this.destino = value; }
                get { return this.destino; }
            }

            //Ingresar distancia
            protected double distancia;
            public double Distancia
            {
                set { this.distancia = value; }
                get { return this.distancia; }
            }

            //Ingresar dirección cardinal de destino
            protected string direccionCardinal;
            public string DireccionCardinal
            {
                set { this.direccionCardinal = value; }
                get { return this.direccionCardinal; }
            }

            //Ingresar hora de llegada
            protected double horaLlegada;
            public double HoraLlegada
            {
                set { this.horaLlegada = value; }
                get { return this.horaLlegada; }
            }

            //Ingresar costo de viaje
            protected double costoViaje;
            public double CostoViaje
            {
                set { this.costoViaje = value; }
                get { return this.costoViaje; }
            }
        }



    }
}
