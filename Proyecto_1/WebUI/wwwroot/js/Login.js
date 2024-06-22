/// <summary>
/// JavaScript para la pantalla de login
/// </summary>
/// <createdate>28-5-2024</createdate>
/// <author>Austin Quirós Paniagua</author>
/// <company>UISILl</company>
/// <lastmodificationdate></lastmodificationdate>
/// <lastmodificationdescription></lastmodificationdescription>
/// <lastmodifierauthor></lastmodifierauthor>

jsLogin = {

    objetos: {


    },
    controles: {
        inputUsuario: '#inputUsuario',
        inputContrasena: '#inputcontrasena'

    },

    botones: {
        btnLogin: '#btnLogin'

    },

    variables: {
        Usuario: null,
        contrasena: null

    },
    metodos: {

        IniciarSesion: function () {
            event.preventDefault();

            jsLogin.variables.Usuario = $(jsLogin.controles.inputUsuario).val().trim();
            jsLogin.variables.contrasena = $(jsLogin.controles.inputContrasena).val().trim();

            console.log(jsLogin.variables.Usuario)
            console.log(jsLogin.variables.contrasena)


            // Realizar la solicitud AJAX
            $.ajax({
                url: '../Login/IniciarSesionUsuarios',
                type: 'POST',
                data: { Usuario: jsLogin.variables.Usuario, Contrasena: jsLogin.variables.contrasena },
                success: function (result) {

                    console.log(result);

                    if (result.ok) {
                        Swal.fire({
                            title: "Exito",
                            text: result.message,
                            icon: "success",
                            confirmButtonText: "Continuar!",
                            confirmButtonColor: "#297EA6"
                        });
                        // Redirigir a la página principal después de 2 segundos
                        setTimeout(function () {
                            window.location.href = '/Home/Index';
                        }, 2000);
                    } else {
                        Swal.fire({
                            title: "Error",
                            text: "El usuario o la contraseña es incorrecto",
                            icon: "warning",
                            confirmButtonText: "Continuar!",
                            confirmButtonColor: "#297EA6"

                        });
                    }
                },
                error: function () {
                    // Manejo de errores si es necesario
                    Swal.fire({
                        title: "Error",
                        text: "No se encontró el método solicitado",
                        icon: "error",
                        confirmButtonText: "Continuar!"
                    });
                }
            });


        }






    },
    eventos:
        function () {
            $(jsLogin.botones.btnLogin).on("click", function () {
                jsLogin.metodos.IniciarSesion();

            });


        }

}

$(function () {
    jsLogin.eventos();
});