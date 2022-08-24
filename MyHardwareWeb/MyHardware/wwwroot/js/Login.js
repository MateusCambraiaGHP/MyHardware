


//var login = function () {
//  var render = function () {
//  };

//  return {
//    init: function () {
//      render();
//    }
//  }
//}();

//const login = function () {

//  const render = function () {
$('.header-main').hide();
$('.header-login').show();

//      $.ajax({
//        url: App.getUrl() + '/save',
//        type: 'POST',
//        data: data,
//        success: function (result) {
//          flash.success('O Equipamento foi salvo com sucesso.', DefaultValues.FlashDisplayTime);
//          window.location = App.getUrl();
//        },
//        error: function (xhr, status, exception) {
//          App.showError($('#control-item-form'), xhr, exception);
//        },
//        complete: function () {
//          App.done();
//        }
//      });
//    });

//    var initialFormData = $('#control-item-form').serialize();
//  };

//  var renderComponents = function () {
//    var id = $('#Id').val();
//    if (id === 0) { return false; }
//    if (items) {
//      components = items;

//      componentsInitial = components;
//      App.renderTemplate({ model: components }, 'js-table-component', 'template-component');
//      console.log(components);
//      return true;
//    }

//    $.ajax({
//      url: App.getUrl() + '/getallcontrolitemcomponent',
//      data: { id: $('#Id').val() },
//      type: 'GET',
//      success: function (result) {
//        if (result.model.length === 0) {
//          $('.js-table-component > tbody').html('<tr class="js-table-empty"><td></td><td colspan="5" class="text text-center">Nenhum outro componente cadastrado.</td><td></td><td></td></tr>');
//        }
//        else {
//          App.renderTemplate(result, 'js-table-component', 'template-component');
//          components = result.model;
//          componentsInitial = JSON.stringify(result.model);

//          let items = result.model;
//          $(items).each(function (index, item) {
//            let $tr = $('#' + item.HashCode);
//            item.Active == 1 ? $tr.removeClass('inactive') : $tr.addClass('inactive');
//          });
//        }
//        App.done();
//      },
//      error: function (xhr, status, exception) {
//        App.critical('Ocorreu um erro crítico! Erro: {0} ({1}).'.format(jqXHR.status, jqXHR.statusText));
//        App.done();
//      }
//    });
//  };

//  const caseControlItemType = function () {
//    let controlItemType = $('#ControlItemType').val();
//    switch (controlItemType) {
//      case "4":
//        $('#inputTare').show();
//        $('#inputAxes').show();
//        $('.table-contanier').hide();
//        $('#IdentificationNumber').show();
//        break;
//      case "6":
//        $('.table-contanier').show();
//        $('#inputTare').hide();
//        $('#inputAxes').hide();
//        $('#IdentificationNumber').hide();
//        $('#Tare').val("0,00");
//        $('#QuantityAxes').val(0);
//        break;
//      default:
//        $('#inputTare').hide();
//        $('#inputAxes').hide();
//        $('.table-contanier').hide();
//        $('#Tare').val("0,00");
//        $('#QuantityAxes').val(0);
//        $('#IdentificationNumber').show();
//    }
//  };

//  const showControlItemDialog = function (hashCode) {
//    let data;
//    if (hashCode) {
//      var found = components.filter(function (componentsItems) {
//        return componentsItems.HashCode === hashCode;
//      });
//      if (!found.length) {
//        alert('Componente não encontrado. HashCode: "{0}".'.format(hashCode));
//        return false;
//      }
//      data = found[0];
//    }

//    loader.show();
//    $.ajax({
//      url: App.getUrl() + '/getcontrolitemcomponentdialog',
//      type: 'GET',
//      data: data,
//      success: function (result) {
//        $(result).appendTo('body');
//        controlItemComponentForm.caseItemCommunicationType();
//        controlItemComponentForm.caseSettingsDialog();

//        if (hashCode) {
//          if (data.Active == '0') {
//            $($('#ActiveComponent').removeAttr('checked'));
//          }
//        };

//        $('#TcpIpPort').setMask({ mask: '9999', autoTab: false });
//        $('.settings-input-number').setMask({ mask: '99999999', autoTab: false });

//        $('.component-create-dialog')
//          .on('shown.bs.modal', function () {
//            controlItemComponentForm.init();
//          })
//          .on('hidden.bs.modal', function (e) {
//            $(this).remove();
//          })
//          .modal('show');
//      },
//      error: function (jqXHR, textStatus, errorThrown) {
//        App.critical('Ocorreu um erro crítico! Erro: {0} ({1}).'.format(jqXHR.status, jqXHR.statusText));
//      },
//      complete: function () {
//        App.done();
//        loader.hide();
//      }
//    });
//  };

//  return {
//    init: function (items) {
//      render(items);
//    },
//    caseControlItemType: function () {
//      caseControlItemType();
//    },
//    showControlItemDialog: function (hashCode) {
//      showControlItemDialog(hashCode);
//    },
//    components: function () {
//      return components;
//    }
//  }
//}();

//const controlItemComponentForm = function () {
//  const render = function () {
//    $('#ComponentType').on('change', caseSettingsDialog);
//    $('#CommunicationType').on('change', caseItemCommunicationType);
//    $('#component-create-form').on('submit', function (e) {
//      e.preventDefault();
//      App.wait()

//      let data = $('#component-create-form').serializeObject();
//      data.ActiveComponent === "1" ? data.Active = data.ActiveComponent : data.Active = 0;
//      data.ActiveSTX === "1" ? data.StartOfText = data.ActiveSTX : data.ActiveSTX = 0;
//      $.ajax({
//        url: App.getUrl() + '/savecontrolitemcomponent',
//        type: 'POST',
//        data: data,
//        success: function (result) {
//          App.addOrUpdateRow(controlItemForm.components(), result, 'js-table-component', 'template-component', 'ASC');
//          $('.component-create-dialog').modal('hide');
//          toastr.success(result.model.IsNew ? 'Componente adicionado com sucesso.' : 'Componente atualizado com sucesso.');
//          const $tr = $('#' + data.HashCode);
//          data.ActiveComponent != undefined ? $tr.removeClass('inactive') : $tr.addClass('inactive');

//          $('.js-remove-item-component').on('click', function (e) {
//            e.preventDefault();
//            var ok = confirm('Deseja realmente remover o componente?');
//            if (!ok) {
//              return false;
//            }
//            var index = controlItemForm.components().findIndex(i => i.HashCode === $(this).data('hash'));
//            if (index > -1) {
//              controlItemForm.components().splice(index, 1);
//            }
//            $(this).parent().parent().remove();
//          });
//        },
//        error: function (xhr, status, exception) {
//          App.showError($('#component-create-form'), xhr, exception);
//        },
//        complete: function () {
//          App.done();
//        }
//      });
//    });
//  }

//  const caseSettingsDialog = function () {
//    let componentType = $('#ComponentType').val();
//    switch (componentType) {
//      case "1":
//        $('.form-settings-component').show();
//        break;
//      case "2":
//        $('.form-settings-component').hide();
//        break;
//      default:
//        $('.form-settings-component').show();
//    }
//  };

//  const caseItemCommunicationType = function () {
//    let communicationType = $('#CommunicationType').val();
//    switch (communicationType) {
//      case "1":
//        $('.component-type-tcip').hide();
//        $('.component-type-serial').show();
//        $('#TcpIp').val('');
//        $('#TcpIpPort').val('');
//        break;
//      case "2":
//        $('.component-type-tcip').show();
//        $('.component-type-serial').hide();
//        $('#PortName').val('');
//        $('#BaudRate').val('0');
//        $('#Parity').val('');
//        $('#DataBits').val('0');
//        $('#StopBits').val('');
//        break;
//      default:
//        $('.component-type-tcip').hide();
//        $('#TcpIp').val('');
//        $('#TcpIpPort').val('');
//        $('#PortName').val('');
//        $('#BaudRate').val('0');
//        $('#Parity').val('');
//        $('#DataBits').val('0');
//        $('#StopBits').val('');
//    }
//  };

//  return {
//    init: function () {
//      render();
//    },
//    caseSettingsDialog: function () {
//      caseSettingsDialog();
//    },
//    caseItemCommunicationType: function () {
//      caseItemCommunicationType();
//    }
//  }
//}();

//const controlItemFilter = function () {
//  const render = function () {
//    loadSession();

//    $('.js-operational-unit').on('change', function (e) {
//      e.preventDefault();
//      $('#idOperationalUnit').val($(this).val());
//      doFilter();
//    });

//    $('.js-name').on('change', function (e) {
//      e.preventDefault();
//      $('#name').val($(this).val());
//      doFilter();
//    });

//    $('.js-filter').on('click', function (e) {
//      $('#idOperationalUnit').val($('.js-operational-unit').val());
//      $('#name').val($('.js-name').val());
//      $('#idControlItemCategory').val($('.js-id-control-item-category').val());
//      $('#controlItemType').val($('.js-control-item-type').val());
//      $('#ownership').val($('.js-ownership').val());
//      $('.filter-dialog')
//        .on('shown.bs.modal', function () {
//          $('#name').focus();
//        })
//        .modal('show');
//    });

//    $('.filter-dialog').on('click', '.js-clear-filter', function (e) {
//      e.preventDefault();
//      $('#name').val("");
//      $('.js-name').val("");
//      $('#idOperationalUnit').val("");
//      $('.js-id-operational-unit').val("");
//      $('#idCompanyGroup').val("");
//      $('.js-id-company-group').val("");
//      $('#idControlItemCategory').val("");
//      $('.js-id-control-item-category').val("");
//      $('#controlItemType').val("");
//      $('.js-control-item-type').val("");
//      $('#ownership').val("");
//      $('.js-ownership').val("");
//      App.clearFilter();
//      doFilter();
//    });

//    $(document).on('submit', '.filter-dialog form', function (e) {
//      e.preventDefault();
//      doFilter();
//    });

//    App.initHelpers(['input-mask', 'selectize']);

//  };

//  var doFilter = function () {
//    var filter = getFilter();
//    var url = App.getUrl() + '/dofilter';
//    session.set(App.getCurrentPage(), filter);
//    App.wait('Aguarde...');
//    $.ajax({
//      url: url,
//      type: 'POST',
//      data: filter,
//      success: function (result) {
//        $('.table > tbody').html('').html(result.items);
//        $('#pagination').html('').html(result.pagination);
//        $('.row.table-footer').remove();
//        var length = $('.table > tbody').children().length;
//        if (length === 0) {
//          App.showEmptyTable('Nenhum Equipamento encontrado para o filtro informado.');
//        }
//        // set fast filter
//        $('.js-operational-unit').val($('#idOperationalUnit').val());
//        $('.js-name').val($('#name').val());
//        $('.js-id-control-item-category').val($('#idControlItemCategory').val());
//        $('.js-control-item-type').val($('#controlItemType').val());
//        $('.js-ownership').val($('#ownership').val());
//        // close dialog
//        if ($('.filter-dialog.in').length) {
//          $('.filter-dialog').modal('hide');
//        }
//        App.updateFilterStatus(hasFilter());
//      },
//      error: function (jqXHR, textStatus, errorThrown) {
//        App.critical('Ocorreu um erro crítico! Erro: {0} ({1}).'.format(jqXHR.status, jqXHR.statusText));
//      },
//      complete: function () {
//        App.done();
//      }
//    });
//  };

//  var getFilter = function () {
//    var filter = $('.filter-dialog form').serializeObject();
//    filter.idCompany = App.getCurrentCompany();
//    return filter;
//  };

//  var hasFilter = function () {
//    var isOperationalUnitFilter = $('#idOperationalUnit').val() !== '';
//    var isNameFilter = $('#name').val() !== '';
//    var isIdControlItemCategoryFilter = $('#idControlItemCategory').val() !== '';
//    var isControlItemTypeFilter = $('#controlItemType').val() !== '';
//    var isOwnershipFilter = $('#ownership').val() !== '';

//    return isOperationalUnitFilter
//      || isControlItemTypeFilter
//      || isNameFilter
//      || isIdControlItemCategoryFilter
//      || isOwnershipFilter;
//  };

//  const loadSession = function () {
//    const filter = session.get(App.getCurrentPage());
//    if (!filter) {
//      doFilter();
//      return false;
//    }
//    $('#idOperationalUnit').val(filter.IdOperationalUnit);
//    $('#name').val(filter.name);
//    $('#idControlItemCategory').val(filter.idControlItemCategory);
//    $('#controlItemType').val(filter.controlItemType);
//    $('#ownership').val(filter.ownership);
//    doFilter(filter.page);
//  };

//  return {
//    init: function () {
//      render();
//    },
//    doFilter: function (page) {
//      doFilter(page);
//    },

//    getFilter: function () {
//      return getFilter();
//    },

//    hasFilter: function () {
//      return hasFilter();
//    }
//  };
//}();

///* Export
//-------------------------------------------------------------------------------- */
//var controlItemExport = function () {
//  var render = function () {
//    $('.js-export').on('click', function (e) {
//      $('.export-dialog').modal('show');
//    });

//    $('#export-file-custom').on('click', function (e) {
//      e.preventDefault();
//      doExport();
//    });
//  };

//  var doExport = function () {
//    var url = App.getUrl() + '/export';
//    var format = $('input[type=radio][name=format]:checked').val();
//    var filter = controlItemFilter.getFilter();
//    App.executeRequestWithouBaseUrl(url, 'POST', { format: format, filter: filter }, function (result) {
//      if (result.success) {
//        $('.export-dialog').modal('hide');
//        window.location = App.getBaseUrl() + 'Utils/DownloadExportedFile?fileName=' + result.fileName;
//        toastr.success('As Alocações de Equipamento foram exportadas com sucesso.', 'Exportar');
//      }
//      else {
//        App.critical('Ocorreu um erro crítico! Erro: {0} ({1}).'.format(jqXHR.status, jqXHR.statusText));
//      }
//    });
//  };

//  App.initHelpers(['toastr']);
//  return {
//    init: function () {
//      render();
//    }
//  };
//}();