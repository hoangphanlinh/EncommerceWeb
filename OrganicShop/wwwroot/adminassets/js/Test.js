
$(document).ready(function () {
    LoadDSShipper();
});

function LoadDSShipper() {
    $.ajax({
        URL: '/Admin/Shippers/LoadData',
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'Json',
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ShipperID + '<td>';
                html += '<td>' + item.ShipperName + '<td>';
                html += '<td>' + item.Phone + '<td>';
                html += '<td>' + item.Company + '<td>';
                html += '<td>' + item.ShipDate + '<td>';
                //html += '<td> <a ></a> <td>';
                html += '</tr>';

            });
            $('#tblshipper').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    })
}
