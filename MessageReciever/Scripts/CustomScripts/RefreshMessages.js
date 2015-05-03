$(document).ready(function () {
    $('#refreshMsgDisplay').click(function (e) {
        $('#messageDisplay').load('/Message/DisplayMessages');
    });
});
