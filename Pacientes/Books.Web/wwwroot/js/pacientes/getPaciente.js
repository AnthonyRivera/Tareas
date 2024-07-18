function loadPaciente(ID) {
    if (ID == undefined) { ID = $('#ID').val(); }

    $.ajax({
        url: `https://localhost:7034/api/Pacientes/${ID}`,
        type: 'GET',
        success: function (paciente) {
            $('#FirstName').text(paciente.FirstName);
            $('#LastName').text(paciente.LastName);
            $('#Sex').text(paciente.Sex);
        },
        error: function (error) {
            console.log(error);
            alert('Ocurrió un error al cargar los datos del libro');
        }
    });
}