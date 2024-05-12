
function SubmitLogin() {
    var url = "";
    var flag = !0;
    var username = $("#txtUserName").val().trim();
    if ((username == "")) {
        $("#divLoginMsg > div.alert").remove();
        $("#divLoginMsg").prepend(getAlert(__msglogRegEmailAddressRequired, "danger", false));
    }
    else if ($("#txtPassword").val().trim() == "") {
        $("#divLoginMsg > div.alert").remove();
        $("#divLoginMsg").prepend(getAlert(__msglogRegPassword, "danger", false));
    }
    else {
        $("#divLoginMsg").append(getLoader());
        DoLogin(username, $("#txtPassword").val().trim(), "", false, false)
    }
    closeAlertDismissable();
};

function DoLogin(username, password, queryString, isRemember, autologin) {
    $.ajax({
        url: '../Users/Login',
        data: { "username": username, "password": password, "queryString": queryString, "isRemember": isRemember, "autologin": autologin },
        type: "POST",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            if ($("#divLoginMsg"))
                $("#divLoginMsg > div.alert").remove();

            removeLoader("#divLoginMsg");

            if (data.isSuccess) {
                localStorage.setItem("logout", 0);

                if (data.returnUrl != null && data.returnUrl != undefined) {
                    if (data.data.roleID == 1 || data.data.roleID == 2 || data.data.roleID == 3 || data.data.roleID == 4 || data.data.roleID == 7) {
                        window.location.href = data.returnUrl;
                    }
                    else {
                        $("#divLoginMsg").prepend(getAlert("Access Denied", "FAILE", false));
                    }
                }
            }
            else if (!data.isSuccess) {
                $("#divLoginBox").removeClass("box");
                $("#divLoginMsg > div.alert").remove();
                $("#divLoginMsg").prepend(getAlert(__msglogRegInvalidEmailAddressPass, data.jsonMessageType, false));

                $("#txtPassword").val('');
                $("#txtUserName").val('').focus();
            }
        },
        complete: function () {
            setTimeout(function () { 
                removeLoader("#divLoginMsg");
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () { 
                removeLoader("#divLoginMsg");
            }, 300);
            console.log(xhr.error().statusText);
        }
    });
}

function CallEnter(objEvent, obj) {
    if (objEvent) {
        if (objEvent.which || objEvent.keyCode) {
            if ((objEvent.which == 13) || (objEvent.keyCode == 13)) {
                $("#" + obj).click();
                return false;
            }
        }
    }
    else
        return true;
}

function closeAlertDismissable() {
    $(".alert-dismissable").find("button.close").click(function () {
        $(".alert-dismissable").remove();
    });
}

function getAlert(message, type, hasIcon) {

    var i = "danger";
    var c = "ban";
    switch (type.toLowerCase()) {
        case "error":
        case "failure":
        case "danger":
            c = "danger";
            i = "ban"
            break;
        case "info":
            c = i = "info";
            break;
        case "warning":
            c = i = "warning";
            break;
        case "success":
            c = "success";
            i = "check";
            break;
        default:
            c = "danger";
            i = "ban"
            break;
    }

    var html = $("#scriptAlert").text();
    if (hasIcon)
        html = html.replace("<!--", "").replace("-->", "").replace("[[ICON]]", i);
    html = html.replace("[[CLASS]]", c).replace("[[MESSAGE]]", message);

    return html;
}

function showFP(_type) {
    if (_type == 'FPLink') {
        BootstrapDialog.show({
            id: "divFP",
            title: "Forgot Password",
            size: BootstrapDialog.SIZE_NORMAL,
            message: function () {
                var $message = $('<div id="divForgotPwd" class="pTB10-LR05"></div>');
                var html = '<div class="body">';
                html += '   <div class="">';
                html += '       <div class="input_holder">';
                html += '           <label for="input-1">Email Address</label>:';
                html += '           <input onkeydown="CallEnter(event, \'btnFPsubmit\')" id="txtUsername" maxlength="100" type="text" class="input__field input__field--haruki form-control" />'; //onkeydown="CallEnter(event, \'btnFPsubmit\')"
                html += '       </div>';
                html += '       <div>&nbsp;</div>';
                html += '   </div>';
                html += '</div>';
                $message.append(html);
                return $message;
            },
            closeByBackdrop: false,
            closable: false,
            buttons: [
                {
                    label: 'Close',
                    cssClass: 'btn btn-default',
                    action: function (dialogItself) {
                        dialogItself.close();
                    }
                }, {
                    label: 'Submit',
                    cssClass: 'btn btn-primary',
                    id: 'btnFPsubmit',
                    action: function (dialog) {
                       
                        if ($.trim($("#txtUsername").val()) != "") {
                            $("#btnFPsubmit").css({ "opacity": "0.5", "cursor": "not-allowed" });
                            $("#btnFPsubmit").prop("disabled", "true");
                            $.ajax({
                                url: "/api/User/ForgotPassword?UserName=" + $.trim($("#txtUsername").val()),
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (result) {
                                    removeLoader("#divForgotPwd");
                                    if (result != null) {
                                        $(".modal-content").attr('class', 'modal-content');
                                        $("#divForgotPwd").prepend(getAlert('Email Sent !', "success", false));
                                    }
                                },
                                complete: function () {
                                    setTimeout(function () { 
                                        removeLoader(".modal-content");
                                        removeLoader("#divForgotPwd");
                                    }, 300);
                                },
                                error: function (xhr, ajaxOptions, thrownError) {
                                    dialog.close();
                                    console.log(xhr.error().statusText);
                                    removeLoader("#divForgotPwd");
                                }
                            });
                        }
                        else {
                            $("#divForgotPwd div.alert").remove();
                            $("#divForgotPwd").prepend(getAlert('Registered Email Address Required', "danger", false));
                        }
                    }
                }
            ],
            onshown: function (dialogRef) {
                //
            }
        });
    }
}

function DeleteUserLogin() {
    var url = "";
    var flag = !0;
    var username = $("#txtUserName").val().trim();
    if ((username == "")) {
        $("#divLoginMsg > div.alert").remove();
        $("#divLoginMsg").prepend(getAlert(__msglogRegEmailAddressRequired, "danger", false));
    }
    else if ($("#txtPassword").val().trim() == "") {
        $("#divLoginMsg > div.alert").remove();
        $("#divLoginMsg").prepend(getAlert(__msglogRegPassword, "danger", false));
    }
    else {
        $("#divLoginMsg").append(getLoader());
        DoDeleteUserLogin(username, $("#txtPassword").val().trim(), "", false, false)
    }
    closeAlertDismissable();
};

function DoDeleteUserLogin(username, password, queryString, isRemember, autologin) {
    $.ajax({
        url: '../Users/DeleteUserLogin',
        data: { "username": username, "password": password, "queryString": queryString, "isRemember": isRemember, "autologin": autologin },
        type: "POST",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            if ($("#divLoginMsg"))
                $("#divLoginMsg > div.alert").remove();

            removeLoader("#divLoginMsg");

            if (data.isSuccess) {
                localStorage.setItem("logout", 0);

                if (data.returnUrl != null && data.returnUrl != undefined) {
                    if (data.data.roleID == 4 || data.data.roleID == 5) {
                        window.location.href = "/DeleteUser/DeleteUser";
                    }
                    else {
                        $("#divLoginMsg").prepend(getAlert("Access Denied", "FAILE", false));
                    }
                }
            }
            else if (!data.isSuccess) {
                $("#divLoginBox").removeClass("box");
                $("#divLoginMsg > div.alert").remove();
                $("#divLoginMsg").prepend(getAlert(__msglogRegInvalidEmailAddressPass, data.jsonMessageType, false));

                $("#txtPassword").val('');
                $("#txtUserName").val('').focus();
            }
        },
        complete: function () {
            setTimeout(function () { 
                removeLoader("#divLoginMsg");
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () {
                removeLoader("#divLoginMsg");
            }, 300);
            console.log(xhr.error().statusText);
        }
    });
}