/******** FORM SWITCH JS START *************/
const signInBtn = document.getElementById("signIn");
const signUpBtn = document.getElementById("signUp");
const fistForm = document.getElementById("form1");
const secondForm = document.getElementById("form2");
const container = document.querySelector(".container");

signInBtn.addEventListener("click", () => {
    container.classList.remove("right-panel-active");
});

signUpBtn.addEventListener("click", () => {
    container.classList.add("right-panel-active");
});

fistForm.addEventListener("submit", (e) => e.preventDefault());
secondForm.addEventListener("submit", (e) => e.preventDefault());

/******** FORM SWITCH JS END *************/
/******** FORM Signin START *************/
$("#login").click(function () {

    let email = $("#signin-email").val();
    let pass = $("#signin-password").val();


    if (email.length > 4) {
        if (pass.length > 2) {
            $.ajax({
                url: '/login',
                type: 'post',
                data: { 'Email': email, 'Password': pass },
                beforeSend: function () {
                    $("#login").attr("disabled", true);
                    $("#login").text("Loading...");
                    //$('#login').text(`Loading <i class="fa fa-spinner fa-spin"></i>`);
                },
                success: function (response) {
                    if (response.success) {

                        toastr.success(response.message, 'Success')
                        setTimeout(() => {
                            window.open(response.url, "_self");
                        }, 2000);

                    } else {
                        toastr.error(response.message, 'Error');
                    }
                },
                complete: function () {
                    $("#login").attr("disabled", false);
                    $("#login").text("Sign In");

                },
                error: function () {
                    $("#login").attr("disabled", false);
                    $("#login").text("Sign In");
                }
            });
        } else {
            $(".signin-pass-msg").text("Invalid Password..!");
            setTimeout(function () { $(".signin-pass-msg").text(""); }, 3000);
        }
    } else {
        if (pass.length < 2) {
            $(".signin-pass-msg").text("Invalid Password..!");
            setTimeout(function () { $(".signin-pass-msg").text(""); }, 3000);
        }
        $(".signin-email-msg").text("Invalid Email..!");
        setTimeout(function () { $(".signin-email-msg").text(""); }, 3000);
    }

});
/******** FORM Signin END *************/
