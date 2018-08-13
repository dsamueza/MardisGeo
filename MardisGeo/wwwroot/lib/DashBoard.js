var idperson
function ModalPerfil(id) {

    idperson = id;
    $("#idaccount").empty();
    $.ajax({
        url: 'Account/Admin',
        type: "POST",
        content: "application/json; charset=utf-8",
        data: {
            id: 1
        },
        success: function (data) {
            $.each(data, function (index, value) {
                $("#idaccount").append("<option value=" + value.idaccount + ">" + value.account + "</option>");
            });
            $('#responsive').modal('show');
            GetProfile($("#idaccount").val().toString(), id);
        },

        error: function () {
            $("#idaccount").append("<option value=" + 0 + ">No existe Opciones</option>");
        },


    });


}
function GetProfile(idaccount, idperson) {

    $("#content-chk").empty();

    $.ajax({
        url: 'ProfileDash/Admin',
        type: "POST",
        content: "application/json; charset=utf-8",
        data: {
            id: idaccount
            , idper: idperson
        },
        success: function (data) {
            $.each(data, function (index, value) {
                if (value.person != 0) {
                    $("#content-chk").append(" <div class='checkbox checkbox-success'>" +
                        "<input id='" + value.idaccount + "' type='checkbox' checked='' onclick='onToggle(" + value.idaccount + " )'>" +
                        "<label for='" + value.idaccount + "'>" +
                        value.account + " "
                        + "</label >" +
                        "</div>");
                } else {
                    $("#content-chk").append(" <div class='checkbox checkbox-success'>" +
                        "<input id='" + value.idaccount + "' type='checkbox' onclick='onToggle(" + value.idaccount + " )'>" +
                        "<label for='" + value.idaccount + "'>" +
                        value.account + " "
                        + "</label >" +
                        "</div>");
                }

            });

        },

        error: function () {


        }
        ,
        async: false, // La petición es síncrona
    });


}
$("#idaccount").change(function () {
    GetProfile($("#idaccount").val().toString(), idperson);
});
function onToggle(idprofile, iduser) {
    $.ajax({
        url: 'saveprofileDashBoard/Admin',
        type: "POST",
        content: "application/json; charset=utf-8",
        data: {
            id: idprofile
            , idper: idperson
        },
        success: function (data) {

        },

        error: function () {


        }
        ,
        async: true, // La petición es síncrona
    });
}
