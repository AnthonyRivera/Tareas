function loadBook(bookId) {
    if (bookId == undefined) { bookId = $('#BookId').val(); }

    $.ajax({
        url: `https://localhost:7034/api/Book/${bookId}`,
        type: 'GET',
        success: function (book) {
            $('#BookName').text(book.bookName);
            $('#Author').text(book.author);
            $('#ReleaseYear').text(book.releaseYear);
        },
        error: function (error) {
            console.log(error);
            alert('Ocurrió un error al cargar los datos del libro');
        }
    });
}