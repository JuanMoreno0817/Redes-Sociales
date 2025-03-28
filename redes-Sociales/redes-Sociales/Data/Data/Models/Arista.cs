namespace redes_Sociales.Data.Models
{
    public class Arista
    {
        public Nodo Origen { get; }
        public Nodo Destino { get; }
        public double Peso { get; }
        public string Tipo { get; }       // Ej: "Tutoría", "Investigación"
        public DateTime Fecha { get; }    // Fecha de inicio
        public int DuracionMeses { get; } // Duración en meses

        public Arista(Nodo origen, Nodo destino, double peso, string tipo, DateTime fecha, int duracionMeses)
        {
            Origen = origen;
            Destino = destino;
            Peso = peso;
            Tipo = tipo;
            Fecha = fecha;
            DuracionMeses = duracionMeses;
        }
    }
}