function deleteBook(bookId) {
    if (bookId == undefined || bookId == 0) { bookId = $('#BookId').val(); }

    $.ajax({
        url: `https://localhost:7034/api/Book/${bookId}`,
        type: 'DELETE',
        success: function (result) {
            $('#deleteModal').modal('hide');
            window.location.href = '/Book/Index';
        },
        error: function (error) {
            console.log(error);
            alert('Ocurrió un error al eliminar el libro');
        }
    });
}