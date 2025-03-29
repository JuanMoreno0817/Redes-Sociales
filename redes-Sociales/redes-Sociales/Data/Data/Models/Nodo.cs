namespace redes_Sociales.Data.Models
{
    public class Nodo {
        public string Id { get; set; }
        public string Nombre { get; }
        public string Rol { get; }
        public List<string> Intereses { get; }

        public Nodo(string? id, string nombre, string rol, List<string> intereses)
        {
            Id = id;
            Nombre = nombre;
            Rol = rol;
            Intereses = intereses;
        }
    }
}