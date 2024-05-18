function SubmitForm(formName) {
    var msg = "";
    var isValid = true;
    var validator_count = 0;

    if (formName == "frmOperator") {
        if ($("#OperatorName").val() == "") {
            msg = msg + "\n" + "Operator Name";
            isValid = false;
        }

        if ($("#UserName").val() == 0) {
            msg = msg + "\n" + "UserName";
            isValid = false;
        }
        if ($("#Password").val() == 0) {
            msg = msg + "\n" + "Password";
            isValid = false;
        }
    }
    if (isValid) {
        if (formName == "frmOperator") {
            SaveOperator();
        }
    }
    else if (msg != "") {
        showBSAlert(__requiredCaption, msg, __WARNING);
    }

    msg = "";
    validator_count = 0;
}


function SaveOperator() {
    $("#divLoader").append(getLoader());
    var id = $("#Id").val();
    var userId = $("#UserId").val();
    var operatorName = $("#OperatorName").val();
    var userName = $("#UserName").val();
    var password = $("#Password").val();



    $.ajax({
        url: '/Operators/SaveOperator',
        data: { "id": id, "userId": userId, "operatorName": operatorName, "userName": userName, "password": password },
        type: "POST",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            if (data.isSuccess) {
                BootstrapDialog.show({
                    id: "divSaveOperator",
                    title: __SUCCESS,
                    type: getDialogType(__SUCCESS),
                    message: function () {
                        var $message = $('<div id="divSaveOperatorInner"></div>');
                        $message.append(data.message);
                        return $message;
                    },
                    closeByBackdrop: false,
                    closable: false,
                    buttons: [
                        {
                            label: __ok,
                            cssClass: 'btn btn-primary',
                            action: function (dialog) {
                                location.href = "/Operators/Index";
                            }
                        }
                    ],
                    onshown: function () {

                    }
                });
            }
            else if (!data.isSuccess) {
                BootstrapDialog.show({
                    id: "divSaveOperator",
                    title: __WARNING,
                    type: getDialogType(__WARNING),
                    message: function () {
                        var $message = $('<div id="divSaveOperatorInner"></div>');
                        $message.append(data.message);
                        return $message;
                    },
                    closeByBackdrop: false,
                    closable: false,
                    buttons: [
                        {
                            label: __ok,
                            cssClass: 'btn btn-primary',
                            action: function (dialog) {
                                location.reload(true);
                            }
                        }
                    ]
                });
            }
        },
        complete: function () {
            setTimeout(function () {
                removeLoader("#divLoader");
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () {
            }, 300);
            console.log(xhr.error().statusText);
            //  alert(xhr.error())
        }
    });
}
