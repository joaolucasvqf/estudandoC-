function TestCors() {
    var tokenJwt = "";
    var servico = "https://localhost:44384/api/mensagem/4535e91e-2149-490d-9f5b-ef916d17f472/92b53516-5514-4560-8dee-46cd108d0e27";
    $("#resultado").html("--------------Carregando--------------");

    $.ajax({
        url: servico,
        method: "GET",
        crossDomain: true,
        headers: { "Accept": "Application/json" },
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + tokenJwt);
        },
        success: function (data, status, xhr) {
            $("#resultado").html(data);
        }
    });
}