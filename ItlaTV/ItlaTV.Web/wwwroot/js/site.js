function buscarSeries() {
    var filtroSerie = document.getElementById('filtroSerie').value.toLowerCase();

    var tarjetas = document.getElementsByClassName('box');

    for (var i = 0; i < tarjetas.length; i++) {
        var tarjeta = tarjetas[i];
        var nombreSerie = tarjeta.querySelector('.card-title').textContent.toLowerCase();

        var estado = nombreSerie.includes(filtroSerie);

        if (estado) {
            tarjeta.style.display = '';
        } else {
            tarjeta.style.display = 'none';
        }
    }
}

function buscarProductoras() {
    var checkboxes = document.getElementsByClassName('form-check-input');
    var productorasSeleccionadas = [];

    for (var i = 0; i < checkboxes.length; i++) {
        var checkbox = checkboxes[i];
        if (checkbox.checked) {
            productorasSeleccionadas.push(checkbox.value.toLowerCase());
        }
    }

    var tarjetas = document.getElementsByClassName('box');

    for (var i = 0; i < tarjetas.length; i++) {
        var tarjeta = tarjetas[i];
        var nombreProductora = tarjeta.querySelector('.productora').textContent.toLowerCase();

        var estado = productorasSeleccionadas.includes(nombreProductora);

        if (estado) {
            tarjeta.style.display = ''; // Mostrar la tarjeta
        } else {
            tarjeta.style.display = 'none'; // Ocultar la tarjeta
        }
    }
}