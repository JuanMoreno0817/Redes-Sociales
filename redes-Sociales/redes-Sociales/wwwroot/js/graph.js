window.drawGraph = (canvasId, grafoJson) => {
    const canvas = document.getElementById(canvasId);
    if (!canvas) {
        console.error("No se encontró el canvas:", canvasId);
        return;
    }

    const ctx = canvas.getContext("2d");
    const grafo = JSON.parse(grafoJson);

    // Distribución circular de los nodos
    const nodesArr = Object.values(grafo.nodos);
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;
    const radius = 200;

    let positions = {};
    nodesArr.forEach((nodo, index) => {
        const angle = (2 * Math.PI / nodesArr.length) * index;
        const x = centerX + radius * Math.cos(angle);
        const y = centerY + radius * Math.sin(angle);
        positions[nodo.id] = { x, y };
    });

    // Dibujar aristas
    grafo.aristas.forEach(arista => {
        const o = positions[arista.origen.id];
        const d = positions[arista.destino.id];
        if (o && d) {
            ctx.beginPath();
            ctx.moveTo(o.x, o.y);
            ctx.lineTo(d.x, d.y);
            ctx.strokeStyle = "gray";
            ctx.stroke();
        }
    });

    // Dibujar nodos
    Object.entries(positions).forEach(([id, pos]) => {
        const nodo = nodesArr.find(n => n.id === id);
        if (nodo) {
            ctx.beginPath();
            ctx.arc(pos.x, pos.y, 20, 0, 2 * Math.PI);
            ctx.fillStyle = "#f66";
            ctx.fill();
            ctx.strokeStyle = "#333";
            ctx.stroke();

            ctx.fillStyle = "#000";
            ctx.font = "bold 14px Arial";
            ctx.fillText(nodo.nombre, pos.x - 15, pos.y - 25);
        }
    });
};