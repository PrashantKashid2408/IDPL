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
    var formData = new FormData($('#frmOperator')[0]); // Change $('#frmOperator') to $('#frmOperator')[0] to get the native DOM element
    $("#divLoader").append(getLoader());

    $.ajax({
        url: window.location.origin + '/Operators/SaveOperator',
        data: formData,
        type: "POST",
        processData: false,
        contentType: false,
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
                                location.href = "/AcademicYear/Index";
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
