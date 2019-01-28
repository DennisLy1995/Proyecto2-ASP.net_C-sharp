SVGFETileElement 
$(document).ready(function () {
    /*document.getElementById("left_nav").style.height = $(document).height() + "px";*/
    var inputs = document.querySelectorAll("input[type=cedula_nacional]");

    for (index = 0; index < inputs.length; ++index) {
        inputs[index].addEventListener('change', verifyInput);
    }
});
function verifyInput() {
    var listaInputs = document.querySelectorAll("input[type=cedula_nacional]");
    for (i = 0; i < listaInputs.length; i++) {
        if (listaInputs[i].value.length == 11) {
            var count = listaInputs[i].value.split("-");
            console.log(count);
            if (count.length == 3) {
                if (count[1].length == 4 && count[2].length == 4) {
                    listaInputs[i].classList.remove("is-invalid");
                    listaInputs[i].classList.add("is-valid");
                } else {
                    listaInputs[i].classList.add("is-invalid");
                }
            } else {
                listaInputs[i].classList.add("is-invalid");
            }
        } else {
            listaInputs[i].classList.add("is-invalid");
        }
    }
}
function ControlAlert() {
 
    this.SetMessage = function (message) {
        var alert_message = document.querySelector("#alert_message");
        alert_message.innerHTML = message;
    }


    this.Open = function () {
        window.location.href = '#alert';
    }
    this.Close = function () {
        window.location.href = "#";
    }


    this.SetProgress = function (progress) {
        var bar = document.querySelector("#progress_bar");
        bar.style.width = progress + "%";
    }
    
}
function ControlActions() {

    this.URL_API = "http://localhost:58520/api/";

	this.GetUrlApiService = function (service) {
		return this.URL_API + service;
	}

    this.UpdateNavPanel = function () {
        document.getElementById("left_nav").style.height = $(document).height() + "px";
    }
	this.GetTableColumsDataName = function (tableId) {
		var val = $('#' + tableId).attr("ColumnsDataName");

		return val;
	}

	this.FillTable = function (service, tableId,refresh) {

		if (!refresh) {
			columns = this.GetTableColumsDataName(tableId).split(',');
			var arrayColumnsData = [];


			$.each(columns, function (index, value) {
				var obj = {};
				obj.data = value;
				arrayColumnsData.push(obj);
			});

			$('#' + tableId).DataTable({
				"processing": true,
				"ajax": {
					"url": this.GetUrlApiService(service),
					dataSrc: 'Data'
				},
				"columns": arrayColumnsData
			});
		} else {
			//RECARGA LA TABLA
			$('#' + tableId).DataTable().ajax.reload();
		}
		
	}

	this.GetSelectedRow = function (tableId) {
		var data = sessionStorage.getItem(tableId + '_selected');

		return data;
	};

	this.BindFields = function (formId, data) {
		console.log(data);
		$('#' + formId +' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			this.value = data[columnDataName];
		});
	}

	this.GetDataForm = function (formId) {
		var data = {};
		
		$('#' + formId + ' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			data[columnDataName] = this.value;
		});

		console.log(data);
		return data;
    }

    this.ClearDataForm = function (formId) {
        $('#' + formId + ' *').filter(':input').val('');
    }

	this.ShowMessage = function (type,message) {
		if (type == 'E') {
			$("#alert_container").removeClass("alert alert-success alert-dismissable")
			$("#alert_container").addClass("alert alert-danger alert-dismissable");
			$("#alert_message").text(message);
		} else if (type == 'I') {
			$("#alert_container").removeClass("alert alert-danger alert-dismissable")
			$("#alert_container").addClass("alert alert-success alert-dismissable");
			$("#alert_message").text(message);
		}
		$('.alert').show();
	};

	this.PostToAPI = function (service, data) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            console.log(response.Message);
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
    };

    this.GetToAPI = function (url) {
        var response = {};
        try {
            $.ajax({
                type: "GET",
                url: url,
                cache: false,
                async: false,
                success: function (data) {
                    response = data['Data'];
                }
            });
        } catch (err) {
            console.log(err);
        }
        return response;
    }

	this.PutToAPI = function (service, data) {
		var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};

	this.DeleteToAPI = function (service, data) {
		var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};
}

//Custom jquery actions
$.put = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'PUT',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}

$.delete = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'DELETE',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}
