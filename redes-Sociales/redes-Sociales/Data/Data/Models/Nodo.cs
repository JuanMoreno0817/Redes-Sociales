namespace redes_Sociales.Data.Models
{
    public class Nodo {
        public string Id { get; set; }
        public string Nombre { get; }
        public string Rol { get; }
        public List<string> Intereses { get; }

        public string TituloDetallado { get; set; }

        public Nodo(string? id, string nombre, string rol, List<string> intereses)
        {
            Id = id;
            Nombre = nombre;
            Rol = rol;
            Intereses = intereses;
            ActualizarTitulo(0);
        }

        public void ActualizarTitulo(int grado)
        {
            TituloDetallado = $"{Nombre} | {Rol} | Grado: {grado} | Intereses: {string.Join(", ", Intereses)}";
        }
    }
}