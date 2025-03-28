using redes_Sociales.Data.Models;
using System.Drawing;

namespace redes_Sociales.Data
{
    public class GraphService
    {
        public Grafo Grafo { get; private set; } = new Grafo();
        private Dictionary<Nodo, string> _comunidades;

        public GraphService()
        {
            CargarGrafoEjemplo();
            ObtenerNodosPorComunidad("IA");
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
                Grafo.AgregarNodo(nodo);

            Grafo.AgregarArista(nodos[0], nodos[3], 3, "Tutoría", DateTime.Now, 6);
            Grafo.AgregarArista(nodos[3], nodos[1], 1, "Colaboración", DateTime.Now, 8);
            Grafo.AgregarArista(nodos[1], nodos[4], 2, "Investigación", DateTime.Now, 4);
            Grafo.AgregarArista(nodos[2], nodos[4], 2, "Tutoría", DateTime.Now, 7);
            Grafo.AgregarArista(nodos[0], nodos[2], 3, "Colaboración", DateTime.Now, 5);
            Grafo.AgregarArista(nodos[5], nodos[1], 2, "Redes", DateTime.Now, 9);
            Grafo.AgregarArista(nodos[6], nodos[0], 3, "IA", DateTime.Now, 5);
            Grafo.AgregarArista(nodos[7], nodos[2], 2, "Matemáticas", DateTime.Now, 6);
        }

        private List<Nodo> ObtenerNodosPorComunidad(string comunidadFiltro)
        {
            var comunidades = new Dictionary<Nodo, string>();

            var grupos = Grafo.Nodos.Values
                .GroupBy(nodo => string.Join(", ", nodo.Intereses.OrderBy(i => i)))
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var grupo in grupos)
            {
                string comunidad = "Interés: " + grupo.Key;

                foreach (var nodo in grupo.Value)
                {
                    comunidades[nodo] = comunidad;
                }
            }

            // Filtrar nodos que pertenecen a la comunidad deseada
            return comunidades.Where(c => c.Value == comunidadFiltro).Select(c => c.Key).ToList();
        }

    }
}
