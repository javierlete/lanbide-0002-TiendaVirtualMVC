const URL = '/api/productos/'

// ES5
//window.onload = function() {
//    fetch(URL)
//        .then(function (respuesta) {
//            return respuesta.json();
//        })
//        .then(function (productos) {
//            console.log(productos);
//        });
//};

// ES2015
//window.onload = () => {
//    fetch(URL)
//        .then((respuesta) => respuesta.json())
//        .then((productos) => console.log(productos));
//};

// ES2017
window.onload = async () => {
    const respuesta = await fetch(URL);
    const productos = await respuesta.json();

    console.log(productos);

    let tr;

    const tbody = document.getElementsByTagName('tbody')[0];

    for (const producto of productos) {
        console.log(producto);

        tr = document.createElement('tr');
        tr.innerHTML = `
            <th>${producto.Id}</th>
            <td>${producto.Nombre}</th>
            <td>${producto.Precio}</th>
            <td>${producto.FechaCaducidad}</th>`;

        tbody.appendChild(tr);
    }
}
