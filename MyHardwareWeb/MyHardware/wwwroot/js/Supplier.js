const supplierIndex = function () {
  //constants

  const render = function () {
    $('.header-main').show();
    $('.header-login').hide();

    $('.js-invite-customer').click(function (e) {
      e.preventDefault();
      let data;
      $.ajax({
        url: window.location.href + '/GetInviteDialog',
        type: 'GET',
        data: data,
        success: function (result) {
          $(result).appendTo('body').modal('show');
          $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus');


          });
        },
        error: function (xhr, status, exception) {
        },
        complete: function () {
          $('#TokenInput').val('fuidiudasfufdsadfdsfdsafsdsa');
          $('#flexCheckChecked').on('click', function () {
            $('#TokenInput').removeAttr('readonly');
          });
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


const supplierForm = function () {
  //constants

  const render = function () {
    $('.header-main').show();
    $('.header-login').hide();

    //$('.js-login-action').click(function () {
    //  let data = $('#login-form').serializeArray().reduce(function (a, x) { a[x.name] = x.value; return a; }, {});
    //  $.ajax({
    //    url: window.location.href + 'Login' + '/ValidatePassword',
    //    type: 'POST',
    //    data: data,
    //    success: function (result) {
    //      window.location.replace('https://localhost:44384/Product');
    //    },
    //    error: function (xhr, status, exception) {
    //      App.showErrors(xhr);
    //    },
    //    complete: function () {
    //    }
    //  });
    //});

  };

  return {
    init: function () {
      render();
    }
  }
}();