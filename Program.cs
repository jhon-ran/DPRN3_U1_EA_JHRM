using System;
using Geolocation;
using System.Data.SqlClient;


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
            user1.Origen = new Coordinate(user1.OrigenLatitud, user1.OrigenLongitud);
            user1.Destino = new Coordinate(user1.DestinoLatitud, user1.DestinoLongitud);

            //Calcular distancia entre origen y destino y convertirla de millas a km
            user1.Distancia = GeoCalculator.GetDistance(user1.Origen, user1.Destino, 1) * 1.609344;

            //Calcular dirección cardinal
            user1.DireccionCardinal = GeoCalculator.GetDirection(user1.Origen, user1.Destino);

            //calcular hora estimada de llegada
            user1.HoraLlegada = user1.Distancia / velocidadConst * minutos;

            //calcular costo de viaje
            user1.CostoViaje = user1.Distancia / 2 * tarifaBase;

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
            Console.WriteLine("Dirección origen latitud:" + user1.OrigenLatitud);
            Console.WriteLine("Dirección cardinal:" + user1.DireccionCardinal);
            Console.WriteLine("Distancia en KM: "+ user1.Distancia);
            Console.WriteLine("Costo total de viaje: "+ user1.CostoViaje);
            Console.WriteLine("Fecha y hora de salida: "+ user1.FechaSalida);
            Console.WriteLine("Fecha y hora estimada de llegada: "+ user1.FechaSalida.AddMinutes(user1.HoraLlegada));
            Console.WriteLine("Tiempo estimado de recorrido en minutos: "+ user1.HoraLlegada);

            //Impresion de viaje usuario 2
            Console.WriteLine();
            Console.WriteLine("Viaje de usuario 2");
            Console.WriteLine("Dirección cardinal:" + user2.DireccionCardinal);
            Console.WriteLine("Distancia en KM: " + user2.Distancia);
            Console.WriteLine("Costo total de viaje: " + user2.CostoViaje);
            Console.WriteLine("Fecha y hora de salida: " + user2.FechaSalida);
            Console.WriteLine("Fecha y hora estimada de llegada: " + user2.FechaSalida.AddMinutes(user2.HoraLlegada));
            Console.WriteLine("Tiempo estimado de recorrido en minutos: " + user2.HoraLlegada);

            //Conexión
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=localhost\\SQLEXPRESS;Database=Ubar;Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Se conectó correctamente a la Base de Datos");


            //Enviar datos
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            //Insert de datos usuario 1
            String sql1 ="INSERT INTO Viaje (origen_latitud, origen_longitud, destino_latitud, destino_longitud, fecha_hora_salida, distancia, direccion_cardinal, costo_viaje) VALUES('" + user1.OrigenLatitud + "','" + user1.OrigenLongitud + "','" + user1.DestinoLatitud + "','" + user1.DestinoLongitud + "','" + user1.FechaSalida + "','"  + user1.Distancia + "','" + user1.DireccionCardinal + "','" + user1.CostoViaje + "')";
            //insert de datos usuario 2
            String sql2 = "INSERT INTO Viaje (origen_latitud, origen_longitud, destino_latitud, destino_longitud, fecha_hora_salida, distancia, direccion_cardinal, costo_viaje) VALUES('" + user2.OrigenLatitud + "','" + user2.OrigenLongitud + "','" + user2.DestinoLatitud + "','" + user2.DestinoLongitud + "','" + user2.FechaSalida + "','" + user2.Distancia + "','" + user2.DireccionCardinal + "','" + user2.CostoViaje + "')";
            //adapter de datos usuario 1
            command = new SqlCommand(sql1, cnn);
            adapter.InsertCommand = new SqlCommand(sql1, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            //adapter de datos usuario 2
            command = new SqlCommand(sql2, cnn);
            adapter.InsertCommand = new SqlCommand(sql2, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            //Consultar datos con un id
            SqlCommand sqlquery;
            SqlDataReader dataReader;

            //Solicitar número de id
            Console.WriteLine();
            Console.WriteLine("Ingresa un número de id a buscar:");
            int busqueda = Convert.ToInt32(Console.ReadLine());

            //Ingresar número de id a buscar
            String sql = "SELECT * FROM Viaje WHERE id = " + busqueda;


            sqlquery = new SqlCommand(sql, cnn);

            dataReader = sqlquery.ExecuteReader();

            //Si hay datos, los lee
            if (dataReader.Read())
            {
                Console.WriteLine();
                Console.WriteLine("Datos de búsqueda:");
                Console.WriteLine("id: " + dataReader["id"].ToString());
                Console.WriteLine("Origen latitud: " + dataReader["origen_latitud"].ToString());
                Console.WriteLine("Origen longitud: " + dataReader["origen_longitud"].ToString());
                Console.WriteLine("Destino latitud: " + dataReader["destino_latitud"].ToString());
                Console.WriteLine("Destino longitud: " + dataReader["destino_longitud"].ToString());
                Console.WriteLine("Fecha y hora de salida: " + dataReader["fecha_hora_salida"].ToString());
                Console.WriteLine("Distancia de trayecto: " + dataReader["distancia"].ToString());
                Console.WriteLine("Distanccia en km: " + dataReader["distancia"].ToString());
                Console.WriteLine("Dirección cardinal: " + dataReader["direccion_cardinal"].ToString());
                Console.WriteLine("Costo del viaje: " + dataReader["costo_viaje"].ToString());

            }
            else { Console.WriteLine("No existe ese id"); }
 
            //se cierra el comando y la conexión
            command.Dispose();
		    cnn.Close();

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
