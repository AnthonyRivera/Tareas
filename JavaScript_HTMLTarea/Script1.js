
var title = document.getElementById('Title');
var paragraph = document.getElementById('paragraph');
var changeButton = document.getElementById('changeButton');

var oldParagraph = paragraph.textContent;
var newParagraph = 'Puff, nuevo párrafo.';
var buttonClick = true;
function changeContent() {
    if (buttonClick) {
        paragraph.textContent = newParagraph;
    } else {
        paragraph.textContent = oldParagraph;
    }
    
    buttonClick = !buttonClick;
}

function changeColor() {
    title.style.color = 'pink';
}
function resetColor() {
    title.style.color = 'aquamarine';
}

changeButton.addEventListener('click', changeContent);

title.addEventListener('mouseover', changeColor);
title.addEventListener('mouseleave', resetColor);