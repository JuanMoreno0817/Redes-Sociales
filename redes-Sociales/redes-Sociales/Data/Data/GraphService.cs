using redes_Sociales.Data.Models;
using System.Drawing;

namespace redes_Sociales.Data
{
    public class GraphService
    {
        public Grafo _grafo { get;  set; } = new Grafo();
        private Dictionary<Nodo, string> _comunidades;
        public event Action OnGraphChanged;
        private bool _ejemploCargado = false;

        public GraphService()
        {
            if (!_ejemploCargado)
            {
                CargarGrafoEjemplo();
                _ejemploCargado = true;
            }
        }

        public Grafo Grafo
        {
            get => _grafo;    
            private set => _grafo = value;
        }

        private int ObtenerNuevoId()
        {
            if (!_grafo.Nodos.Any()) return 1;
            else
            {
                return _grafo.Nodos.Keys
                .Select(id => int.TryParse(id, out int num) ? num : 0)
                .Max() + 1;
            }
        }

        private void CargarGrafoEjemplo()
        {
            var nodos = new[]
            {
                new Nodo("1", "Ana", "Profesor", new List<string> { "IA" }),
                new Nodo("2", "Juan", "Estudiante", new List<string> { "Seguridad" }),
                new Nodo("3", "María", "Profesor", new List<string> { "Algoritmos" }),
                new Nodo("4", "Pedro", "Estudiante", new List<string> { "IA" }),
                new Nodo("5", "Sofía", "Estudiante", new List<string> {"Seguridad" }),
                new Nodo("6", "Carlos", "Profesor", new List<string> { "Redes" }),
                new Nodo("7", "Elena", "Estudiante", new List<string> { "IA" }),
                new Nodo("8", "Luis", "Estudiante", new List<string> { "Algoritmos" })
            };

            foreach (var nodo in nodos)
                _grafo.AgregarNodo(nodo);

            _grafo.AgregarArista(nodos[0], nodos[3], 3, "Tutoría", DateTime.Now, 6);
            _grafo.AgregarArista(nodos[3], nodos[1], 1, "Colaboración", DateTime.Now, 8);
            _grafo.AgregarArista(nodos[1], nodos[4], 2, "Investigación", DateTime.Now, 4);
            _grafo.AgregarArista(nodos[2], nodos[4], 2, "Tutoría", DateTime.Now, 7);
            _grafo.AgregarArista(nodos[0], nodos[2], 3, "Colaboración", DateTime.Now, 5);
            _grafo.AgregarArista(nodos[5], nodos[1], 2, "Redes", DateTime.Now, 9);
            _grafo.AgregarArista(nodos[6], nodos[0], 3, "IA", DateTime.Now, 5);
            _grafo.AgregarArista(nodos[7], nodos[2], 2, "Matemáticas", DateTime.Now, 6);
        }

        public bool AgregarUsuario(Nodo nodo)
        {
            if (nodo == null)
                return false;

            // Generar ID único
            nodo.Id = (_grafo.Nodos.Count + 1).ToString();

            // Validar que no exista un nodo con el mismo ID
            if (_grafo.Nodos.ContainsKey(nodo.Id))
                return false;

            // Agregar el nodo (esto disparará OnGraphChanged internamente)
            _grafo.AgregarNodo(nodo);

            Console.WriteLine($"✅ Nodo agregado: {nodo.Id} - {nodo.Nombre}");
            Console.WriteLine($"📊 Total nodos: {_grafo.Nodos.Count}");

            return true;
        }

        public List<Nodo> ObtenerNodosPorComunidad(string comunidadFiltro)
        {
            if (string.IsNullOrWhiteSpace(comunidadFiltro))
                return _grafo.Nodos.Values.ToList();

            // Búsqueda case-insensitive y parcial
            return _grafo.Nodos.Values
                .Where(nodo => nodo.Intereses.Any(interes =>
                    interes.Contains(comunidadFiltro, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

    }
}
