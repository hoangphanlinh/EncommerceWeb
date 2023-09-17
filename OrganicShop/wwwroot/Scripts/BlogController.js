$(document).ready(function () {
    alert('ok');
});
function RelatedBlog(int id) {
    $.ajax(
        {
            url: '/Blog/RelatedBlog?id=' + id,
            type: 'GET',
            contentType: 'application/json;charset=utf-8',
            dataType: 'Json',
            success: function (result) {
                
            }
        }
    )
}