var datatable;

$(document).ready(function () {
    loadDataTable();
    var id = document.getElementById("clienteId");
    if (id.value > 0) {
        $('#exampleModal').modal('show');
    }
});

function limpiarModal() {
    var TipoDocumento = document.getElementById('TipoDocumento');
    var clientenumero_documentoNombre = document.getElementById('numero_documento');
    var clienteApellidos = document.getElementById('clienteApellidos');
    var clienteTelefono = document.getElementById('clienteTelefono');
    var clienteDireccion = document.getElementById('clienteDireccion');
    var clienteEstado = document.getElementById('clienteEstado');

    clienteId.value = 0;
    numero_documento.value = "";
    clienteApellidos.value = "";
    clienteDireccion.value = "";
    clienteTelefono.value = "";
    clienteEstado.value = true;
}

function loadDataTable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Trabajador/obtenerTodos"
        },
        "columns": [
            { "data": "tipoDocumento", "width": "15%" },
            { "data": "numeroDocumento", "width": "15%" },
            { "data": "nombres", "width": "15%" },
            { "data": "sexo", "width": "15%" },
            { "data": "idDepartamento", "width": "15%" },
            { "data": "idProvincia", "width": "15%" },
            { "data": "idDistrito", "width": "15%" },
        ]
    });
}
