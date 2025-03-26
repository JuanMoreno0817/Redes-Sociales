using redes_Sociales.Data.Models;

namespace redes_Sociales.Data
{
    public class GraphService
    {
        public Grafo Grafo { get; private set; } = new Grafo();

        public GraphService()
        {
            CargarGrafoEjemplo();
        }

        private void CargarGrafoEjemplo()
        {
            var nodos = new[]
            {
                new Nodo("1", "Ana", "Profesor", new List<string> { "IA", "Big Data" }),
                new Nodo("2", "Juan", "Estudiante", new List<string> { "Redes", "Seguridad" }),
                new Nodo("3", "María", "Profesor", new List<string> { "Matemáticas", "Algoritmos" }),
                new Nodo("4", "Pedro", "Estudiante", new List<string> { "IA", "Redes" }),
                new Nodo("5", "Sofía", "Estudiante", new List<string> { "Big Data", "Seguridad" })
            };

            foreach (var nodo in nodos)
                Grafo.AgregarNodo(nodo);

            Grafo.AgregarArista(nodos[0], nodos[3], 3, "Tutoría", DateTime.Now, 6);
            Grafo.AgregarArista(nodos[3], nodos[1], 1, "Colaboración", DateTime.Now, 8);
            Grafo.AgregarArista(nodos[1], nodos[4], 2, "Investigación", DateTime.Now, 4);
            Grafo.AgregarArista(nodos[2], nodos[4], 2, "Tutoría", DateTime.Now, 7);
        }
    }
}
