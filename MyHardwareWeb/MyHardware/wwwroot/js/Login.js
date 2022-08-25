$('.header-main').hide();
$('.header-login').show();

$('.js-login-action').click(function () {
  let data = $('#login-form').serializeArray().reduce(function (a, x) { a[x.name] = x.value; return a; }, {});
  $.ajax({
    url: window.location.href + 'Login' + '/ValidatePassword',
    type: 'POST',
    data: data,
    success: function (result) {
    },
    error: function (xhr, status, exception) {
      $('#errorMessages').append(xhr.responseJSON.errors.Password[0]); 
      $('#errorMessages').append(xhr.responseJSON.errors.Email[0]); 
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


