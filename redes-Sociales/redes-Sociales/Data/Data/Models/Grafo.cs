namespace redes_Sociales.Data.Models
{
    public class Grafo {
        public Dictionary<string, Nodo> Nodos { get; set; } = new Dictionary<string, Nodo>();
        public List<Arista> Aristas { get; } = new List<Arista>();

        public event Action OnGraphChanged;

        public void AgregarNodo(Nodo nodo)
        {
            Nodos[nodo.Id] = nodo;
            OnGraphChanged?.Invoke();
        }

        public void AgregarArista(Nodo origen, Nodo destino, double peso, string tipo, DateTime fecha, int duracionMeses)
        {
            Aristas.Add(new Arista(origen, destino, peso, tipo, fecha, duracionMeses));
            OnGraphChanged?.Invoke();
        }
    }
}