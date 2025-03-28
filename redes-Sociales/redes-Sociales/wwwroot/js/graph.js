function drawGraph(nodes, edges) {
    console.log("Ejecutando drawGraph con:", { nodes, edges });

    const container = document.getElementById('graph-visualization');
    if (!container) {
        console.error("ERROR: No se encontró el contenedor");
        return;
    }

    try {
        // Limpiar contenedor completamente
        container.innerHTML = '';

        // Validación de datos mínima
        if (!nodes || nodes.length === 0) {
            throw new Error("No hay nodos para mostrar");
        }

        // Crear datasets
        const nodesDataset = new vis.DataSet(nodes);
        const edgesDataset = new vis.DataSet(edges || []);

        // Configuración robusta
        const options = {
            nodes: {
                shape: 'dot',
                size: 20,
                font: {
                    size: 14,
                    color: '#000000',
                    strokeWidth: 2,
                    strokeColor: '#ffffff'
                },
                borderWidth: 2,
                color: {
                    border: '#2B7CE9',
                    background: '#97C2FC',
                    highlight: {
                        border: '#2B7CE9',
                        background: '#D2E5FF'
                    }
                }
            },
            edges: {
                width: 2,
                color: {
                    color: '#848484',
                    highlight: '#848484'
                },
                smooth: {
                    type: 'continuous'
                },
                arrows: {
                    to: {
                        enabled: true,
                        scaleFactor: 0.5
                    }
                }
            },
            physics: {
                enabled: true,
                stabilization: {
                    enabled: true,
                    iterations: 1000
                }
            },
            interaction: {
                hover: true,
                tooltipDelay: 200
            }
        };

        // Crear la red
        const network = new vis.Network(container, {
            nodes: nodesDataset,
            edges: edgesDataset
        }, options);

        console.log("Grafo renderizado con éxito!");

        // Forzar redimensionamiento si es necesario
        setTimeout(() => {
            network.redraw();
            network.fit();
        }, 100);

    } catch (error) {
        console.error("Error al dibujar grafo:", error);

        // Mostrar mensaje de error en el contenedor
        container.innerHTML = `
            <div style="color: red; padding: 20px; text-align: center;">
                <h4>Error al mostrar el grafo</h4>
                <p>${error.message}</p>
                <p>Ver consola para detalles técnicos</p>
            </div>
        `;
    }
}