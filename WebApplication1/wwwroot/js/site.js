// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


$(function () {
    $('.boat').draggable({
        containment: '#gameMap',
        cursor: 'move',
        revert: true
    });
});

$(function () {
    $('.col').droppable({
        drop: handleDrop
    });
});

function handleDrop(event, ui) {
    ui.draggable.position({
        of: $(this),
        my: 'bottom',
        at: 'bottom'
    });
    ui.draggable.draggable('option', 'revert', false);
    ui.draggable.draggable("option", "grid", [520, 520]);
}
