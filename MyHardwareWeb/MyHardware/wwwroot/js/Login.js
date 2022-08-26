
const loginForm = function () {
  //constants

  const render = function () {
    $('.header-main').hide();
    $('.header-login').show();
    $('.alert-danger').hide();

    $('.js-login-action').click(function () {
      let data = $('#login-form').serializeArray().reduce(function (a, x) { a[x.name] = x.value; return a; }, {});
      $.ajax({
        url: window.location.href + 'Login' + '/ValidatePassword',
        type: 'POST',
        data: data,
        success: function (result) {
        },
        error: function (xhr, status, exception) {
          App.showErrors(xhr);
        },
        complete: function () {
        }
      });
    });

    $('.js-register-action').click(function (e) {
      e.preventDefault();
      let data;
      $.ajax({
        url: window.location.href + 'Login' + '/GetRegisterDialog',
        type: 'GET',
        data: data,
        success: function (result) {
          console.log(result);
          $('body').append(result);
          $('body').modal("show");
        },
        error: function (xhr, status, exception) {
        },
        complete: function () {
        }
      });
    });


  };

  return {
    init: function () {
      render();
    }
  }
}();