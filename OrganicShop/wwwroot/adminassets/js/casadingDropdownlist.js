$(document).ready(function () {
    $('#city').attr('disable', true);
    $('#district').attr('disable', true);
    $('#ward').attr('disable', true);
    LoadCities();

    $('#city').on("change",function () {
        var id = $(this).val();
        if (id >0) {
            LoadDistricts(id);
        } else {
            alert("select City");
            $('#district').empty();
            $('#ward').empty();
            $('#district').attr('disable', true);
            $('#ward').attr('disable', true);
            $('#district').append('<option>--Select District--</option>');
            $('#ward').append('<option>--Select Ward--</option>');
        }
    });

    $('#district').on("change",function () {
        var id = $(this).val();
        if (id > 0) {
            LoadWards(id);
        } else {
            alert("select District");
            $('#ward').empty();
            $('#ward').attr('disable', true);
            $('#ward').append('<option>--Select Ward--</option>');
        }
    });

});
function LoadCities() {
    $('#city').empty();

    $.ajax({
        url: '/Admin/Customers/GetCity',
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#city').attr('disable', false);
                $('#city').append('<option>--Select City--</option>');
                $('#district').append('<option>--Select District--</option>');
                $('#ward').append('<option>--Select Ward--</option>');
                $.each(response, function (i, data) {
                    $('#city').append('<option value=' + data.value + '>' + data.text + '</option>')
                });
            }
            else {
                $('#city').attr('disable', true);
                $('#district').attr('disable', true);
                $('#ward').attr('disable', true);
                $('#city').append('<option>--City not available--</option>');
                $('#district').append('<option>--District not available--</option>');
                $('#ward').append('<option>--Ward not available--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function LoadDistricts(id) {
    $('#district').empty();
    $('#ward').empty();
    $('#ward').attr('disable', true);


    $.ajax({
        url: '/Admin/Customers/getDistrict?id=' + id,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#district').attr('disable', false);
                $('#district').append('<option>--Select District--</option>');
                $('#ward').append('<option>--Select Ward--</option>');
                $.each(response, function (i, data) {
                    $('#district').append('<option value=' + data.value + '>' + data.text + '</option>')
                });
            }
            else {
                $('#district').attr('disable', true);
                $('#ward').attr('disable', true);
                $('#district').append('<option>--District not available--</option>');
                $('#ward').append('<option>--Ward not available--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function LoadWards(id) {
    $('#ward').empty();
  
    $.ajax({
        url: '/Admin/Customers/getWard?id=' + id,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#ward').attr('disable', false);
                $('#ward').append('<option>--Select Ward--</option>');
                $.each(response, function (i, data) {
                    $('#ward').append('<option value=' + data.value + '>' + data.text + '</option>')
                });
            }
            else {
                $('#ward').attr('disable', true);
                $('#ward').append('<option>--Ward not available--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}