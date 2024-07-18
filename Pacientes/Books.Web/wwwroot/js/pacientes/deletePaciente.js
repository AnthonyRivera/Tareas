function deletePaciente(ID) {
    if (ID == undefined || ID == 0) { ID = $('#ID').val(); }

    $.ajax({
        url: `https://localhost:7034/api/Pacientes/${ID}`,
        type: 'DELETE',
        success: function (result) {
            $('#deleteModal').modal('hide');
            window.location.href = '/Paciente/Index';
        },
        error: function (error) {
            console.log(error);
            alert('Ocurrió un error al eliminar el paciente');
        }
    });
}