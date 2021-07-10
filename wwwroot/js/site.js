// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    let commentTemplate = '<div class="row">' +
            '<h6> На {commentDate} г.</h6>' +
        '</div >' +
        '<div class="row single-comment-description">' +
            '{comment}' +
        '</div>';

    $('#car-photos-carousel').carousel();

    $("#add-comment-form").on("submit", function (e) {
        e.preventDefault();
        let comment = $(this).find('textarea').val(),
            modelId = $(this).find('input[name="car_model_id"]').val();


        $.ajax({
            type: "POST",
            url: "/post_a_comment",
            data: { comment: comment, carModelId: modelId },
            dataType: "text",
            success: function (msg) {
                let now = new Date();
                let currentComment = commentTemplate;
                currentComment = currentComment.replace('{commentDate}', now.getDate() + '.' + now.getMonth() + '.' + now.getFullYear())
                currentComment =currentComment.replace('{comment}', comment);

                $('#comments-list').prepend(currentComment);
                $('#car-comments-form-wrapper').text('Вашият коментар беше публикуван успешно!');
            }
        });
    });
});