/// <reference path="../js/global.js" />

function changeStatus(obj, id, action, type) {
    console.log("action: ", action);
    BootstrapDialog.show({
        id: "divImpersonation",
        title: __WARNING,
        type: getDialogType(__WARNING),
        size: BootstrapDialog.SIZE_NORMAL,
        message: function () {
            var $message = $('<div id="divImpersonationCh" class="box box-no-border-shadow pTB10-LR05" style="margin:0px;"></div>');

            var result = '';
            result += '<div class="modal-body cust-modal-body">';

            if (action == 0) {
                result += "Are you sure you want to Disable this record!";
            }
            else if (action == 2) {
                result += "Are you sure you want to Delete this record!";
            }
            else {
                result += "Are you sure you want to Enable this record!";
            }

            result += '</div>';

            $message.append(result);
            return $message;
        },
        buttons: [
            {
                label: __ok,
                cssClass: 'btn btn-primary',
                action: function (dialog) {
                    if (obj) {
                        //BootstrapDialog.confirm(__confirmMessage, function (result) {
                        //    if (result) {
                        $("#divLoader").append(getLoader());
                        $.ajax({
                            url: changeStatusUrl,
                            data: { "ID": id, "StatusID": action, "type": type },
                            type: "POST",
                            cache: false,
                            //contentType: "application/json; charset=utf-8",
                            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                            dataType: "json",
                            success: function (data) {
                                if (data != null) {
                                    removeLoader("#divLoader");
                                    if (data.isSuccess) {
                                        if (data.message != "")
                                            showBSAlert(data.messageCaption, data.message, __SUCCESS);
                                        var onclick = "changeStatus(this,'" + id + "','0')";
                                        if (action == '0') {
                                            onclick = "changeStatus(this,'" + id + "','1')";
                                        }
                                        $(obj).attr("onclick", "");
                                        $(obj).attr("data-toggle", "");
                                        $(obj).removeAttr("data-original-title");
                                        $(obj).attr("onclick", onclick);
                                        $(obj).siblings().attr("title", "");
                                        $(obj).siblings().attr("data-toggle", "tooltip");
                                        $(obj).siblings().attr("class", "btn-fa-addCustom");

                                        if (action == '1') {
                                            $(obj).attr("class", "btn-fa-addCustom btnCust_unlock");
                                            $(obj).attr("data-original-title", __deActivate);
                                            $(obj).children().attr("class", "fa fa-unlock");
                                            $(obj).next().hide();
                                        }
                                        else if (action != '2') {
                                            if ($(obj).attr("id") == "DeActive") {
                                                $(obj).prev().hide();
                                            }
                                            $(obj).attr("class", "btn-fa-addCustom btnCust_lock");
                                            $(obj).attr("data-original-title", __activate);
                                            $(obj).children().attr("class", "fa fa-lock");
                                        }
                                        else if (action == '2') {
                                            //Remove row
                                        }
                                        $('[data-toggle="tooltip"]').tooltip();
                                        removeRow("row_" + id);
                                    }
                                }
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                removeLoader("#divLoader");
                            }
                        });
                        //    }
                        //});
                    }

                    dialog.close();
                    location.reload();
                }
            },
            {
                label: __Cancel,
                cssClass: 'btn btn-default',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            }
        ],
        onshown: function (dialogRef) {
            //
        },
        closeByBackdrop: false,
        closable: false,
    });
}

function changeStudentsStatus(obj, id, action, type) {
    console.log("action: ", action);
    BootstrapDialog.show({
        id: "divImpersonation",
        title: __WARNING,
        type: getDialogType(__WARNING),
        size: BootstrapDialog.SIZE_NORMAL,
        message: function () {
            var $message = $('<div id="divImpersonationCh" class="box box-no-border-shadow pTB10-LR05" style="margin:0px;"></div>');

            var result = '';
            result += '<div class="modal-body cust-modal-body">';

            if (action == 0) {
                result += "Are you sure you want to Disable this record!";
            }
            else if (action == 2) {
                result += "Are you sure you want to Delete this record!";
            }
            else {
                result += "Are you sure you want to Enable this record!";
            }

            result += '</div>';

            $message.append(result);
            return $message;
        },
        buttons: [
            {
                label: __ok,
                cssClass: 'btn btn-primary',
                action: function (dialog) {
                    if (obj) {
                        //BootstrapDialog.confirm(__confirmMessage, function (result) {
                        //    if (result) {
                        $("#divLoader").append(getLoader());
                        $.ajax({
                            url: changeStatusUrl,
                            data: { "id": id, "statusID": action, "type": type, "islastCheck": 1 },
                            type: "POST",
                            cache: false,
                            //contentType: "application/json; charset=utf-8",
                            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                            dataType: "json",
                            success: function (data) {
                                if (data != null) {
                                    removeLoader("#divLoader");

                                    if (!data.isSuccess) {
                                        if (data.flag == 'true') {
                                            //    if (result) {
                                            $("#divLoader").append(getLoader());
                                            $.ajax({
                                                url: changeStatusUrl,
                                                data: { "ID": id, "StatusID": action, "type": type, "islastCheck": 0 },
                                                type: "POST",
                                                cache: false,
                                                //contentType: "application/json; charset=utf-8",
                                                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                                                dataType: "json",
                                                success: function (data) {
                                                    if (data != null) {
                                                        removeLoader("#divLoader");
                                                        if (data.isSuccess) {
                                                            if (data.message != "")
                                                                showBSAlert(data.messageCaption, data.message, __SUCCESS);
                                                            var onclick = "changeStudentsStatus(this,'" + id + "','0')";
                                                            if (action == '0') {
                                                                onclick = "changeStudentsStatus(this,'" + id + "','1')";
                                                            }
                                                            $(obj).attr("onclick", "");
                                                            $(obj).attr("data-toggle", "");
                                                            $(obj).removeAttr("data-original-title");
                                                            $(obj).attr("onclick", onclick);
                                                            $(obj).siblings().attr("title", "");
                                                            $(obj).siblings().attr("data-toggle", "tooltip");
                                                            $(obj).siblings().attr("class", "btn-fa-addCustom");

                                                            if (action == '1') {
                                                                $(obj).attr("class", "btn-fa-addCustom btnCust_unlock");
                                                                $(obj).attr("data-original-title", __deActivate);
                                                                $(obj).children().attr("class", "fa fa-unlock");
                                                                $(obj).next().hide();
                                                            }
                                                            else if (action != '2') {
                                                                if ($(obj).attr("id") == "DeActive") {
                                                                    $(obj).prev().hide();
                                                                }
                                                                $(obj).attr("class", "btn-fa-addCustom btnCust_lock");
                                                                $(obj).attr("data-original-title", __activate);
                                                                $(obj).children().attr("class", "fa fa-lock");
                                                            }
                                                            else if (action == '2') {
                                                                //Remove row
                                                            }
                                                            $('[data-toggle="tooltip"]').tooltip();
                                                            removeRow("row_" + id);
                                                        }
                                                    }
                                                },
                                                error: function (xhr, ajaxOptions, thrownError) {
                                                    removeLoader("#divLoader");
                                                }
                                            });

                                            //BootstrapDialog.confirm(__confirmMessage, function (result) {
                                        }
                                        else {
                                            BootstrapDialog.show({
                                                id: "divImpersonation",
                                                title: __WARNING,
                                                type: getDialogType(__WARNING),
                                                size: BootstrapDialog.SIZE_NORMAL,
                                                message: function () {
                                                    var $message = $('<div id="divImpersonationCh" class="box box-no-border-shadow pTB10-LR05" style="margin:0px;"></div>');

                                                    $message.append(data.message);
                                                    return $message;
                                                },
                                                buttons: [
                                                    {
                                                        label: __ok,
                                                        cssClass: 'btn btn-primary',
                                                        action: function (dialog) {
                                                            dialog.close();
                                                        }
                                                    }
                                                ],
                                                onshown: function (dialogRef) {
                                                    //
                                                },
                                                closeByBackdrop: false,
                                                closable: false,
                                            });
                                        }
                                    }
                                    else {
                                        if (data.message != "")
                                            showBSAlert(data.messageCaption, data.message, __SUCCESS);
                                        var onclick = "changeStudentsStatus(this,'" + id + "','0')";
                                        if (action == '0') {
                                            onclick = "changeStudentsStatus(this,'" + id + "','1')";
                                        }
                                        $(obj).attr("onclick", "");
                                        $(obj).attr("data-toggle", "");
                                        $(obj).removeAttr("data-original-title");
                                        $(obj).attr("onclick", onclick);
                                        $(obj).siblings().attr("title", "");
                                        $(obj).siblings().attr("data-toggle", "tooltip");
                                        $(obj).siblings().attr("class", "btn-fa-addCustom");

                                        if (action == '1') {
                                            $(obj).attr("class", "btn-fa-addCustom btnCust_unlock");
                                            $(obj).attr("data-original-title", __deActivate);
                                            $(obj).children().attr("class", "fa fa-unlock");
                                            $(obj).next().hide();
                                        }
                                        else if (action != '2') {
                                            if ($(obj).attr("id") == "DeActive") {
                                                $(obj).prev().hide();
                                            }
                                            $(obj).attr("class", "btn-fa-addCustom btnCust_lock");
                                            $(obj).attr("data-original-title", __activate);
                                            $(obj).children().attr("class", "fa fa-lock");
                                        }
                                        else if (action == '2') {
                                            //Remove row
                                        }
                                        $('[data-toggle="tooltip"]').tooltip();
                                        removeRow("row_" + id);
                                    }
                                }
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                removeLoader("#divLoader");
                            }
                        });
                        //    }
                        //});
                    }

                    dialog.close();
                }
            },
            {
                label: __Cancel,
                cssClass: 'btn btn-default',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            }
        ],
        onshown: function (dialogRef) {
            //
        },
        closeByBackdrop: false,
        closable: false,
    });
}

function removeRow(_thisRecord) {
    console.log("#" + _thisRecord);
    $("#" + _thisRecord).remove();
}
function changeStatusManageEnquiries(obj, id, action, type) {
    console.log("action: ", action);
    BootstrapDialog.show({
        id: "divImpersonation",
        title: __WARNING,
        type: getDialogType(__WARNING),
        size: BootstrapDialog.SIZE_NORMAL,
        message: function () {
            var $message = $('<div id="divImpersonationCh" class="box box-no-border-shadow pTB10-LR05" style="margin:0px;"></div>');

            var result = '';
            result += '<div class="modal-body cust-modal-body">';

            if (action == 0) {
                result += "Are you sure you want to Approve this record!";
            }
            else {
                result += "Are you sure you want to Reject this record!";
            }

            result += '</div>';

            $message.append(result);
            return $message;
        },
        buttons: [
            {
                label: __ok,
                cssClass: 'btn btn-primary',
                action: function (dialog) {
                    if (obj) {
                        //BootstrapDialog.confirm(__confirmMessage, function (result) {
                        //    if (result) {
                        $("#divLoader").append(getLoader());
                        $.ajax({
                            url: changeStatusUrl,
                            data: { "ID": id, "StatusID": action, "type": type },
                            type: "POST",
                            cache: false,
                            //contentType: "application/json; charset=utf-8",
                            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                            dataType: "json",
                            success: function (data) {
                                if (data != null) {
                                    removeLoader("#divLoader");
                                    if (data.isSuccess) {
                                        if (data.message != "")
                                            showBSAlert(data.messageCaption, data.message, __SUCCESS);
                                        var onclick = "changeStatus(this,'" + id + "','0')";
                                        if (action == '0') {
                                            onclick = "changeStatus(this,'" + id + "','1')";
                                        }
                                        $(obj).attr("onclick", "");
                                        $(obj).attr("data-toggle", "");
                                        $(obj).removeAttr("data-original-title");
                                        $(obj).attr("onclick", onclick);
                                        $(obj).siblings().attr("title", "");
                                        $(obj).siblings().attr("data-toggle", "tooltip");
                                        $(obj).siblings().attr("class", "btn-fa-addCustom");

                                        if (action == '1') {
                                            $(obj).attr("class", "btn-fa-addCustom btnCust_unlock");
                                            $(obj).attr("data-original-title", __deActivate);
                                            $(obj).children().attr("class", "fa fa-unlock");
                                            $(obj).next().hide();
                                        }
                                        else if (action != '2') {
                                            if ($(obj).attr("id") == "DeActive") {
                                                $(obj).prev().hide();
                                            }
                                            $(obj).attr("class", "btn-fa-addCustom btnCust_lock");
                                            $(obj).attr("data-original-title", __activate);
                                            $(obj).children().attr("class", "fa fa-lock");
                                        }
                                        else if (action == '2') {
                                            //Remove row
                                        }
                                        $('[data-toggle="tooltip"]').tooltip();
                                    }
                                }
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                removeLoader("#divLoader");
                            }
                        });
                        //    }
                        //});
                    }

                    dialog.close();
                }
            },
            {
                label: __Cancel,
                cssClass: 'btn btn-default',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            }
        ],
        onshown: function (dialogRef) {
            //
        },
        closeByBackdrop: false,
        closable: false,
    });
}
function changePromoteStatus(id, PromoteStatus) {
    $("#divLoader").append(getLoader());
    $.ajax({
        url: window.location.origin + '/api/StudentDetails/PromoteStudent?ID=' + id + '&PromoteStatus=' + PromoteStatus,
        data: {},//{ "ID": id, "PromoteStatus": PromoteStatus },
        type: "POST",
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                removeLoader("#divLoader");
                if (data.isSuccess) {
                    if (data.message != "")
                        showBSAlert(data.messageCaption, data.message, __SUCCESS);
                    location.reload();
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            removeLoader("#divLoader");
        }
    });
}

function search(query, sortColumn, sortOrder, page, size, flag, ISLOAD, lsttype) {
    $("#divLoader").append(getLoader());
    $.ajax({
        url: searchUrl,
        //data: JSON.stringify({ query: query, sortColumn: sortColumn, sortOrder: sortOrder, page: page, size: size, flag: flag, ISLOAD: ISLOAD, ListType: lsttype }),
        data: { "query": query, "sortColumn": sortColumn, "sortOrder": sortOrder, "page": page, "size": size, "flag": flag, "ISLOAD": ISLOAD, "ListType": lsttype },
        type: "POST",
        cache: false,
        //contentType: "application/json; charset=utf-8",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (result) {
            removeLoader("#divLoader");
            if (result != null) {
                $("#dvCommon").empty();
                $("#dvCommon").html(result);
                if ($(window).width() > 768)
                    $("#Search").focus();
            }
            setArrow();
            //resizeListView('ddlColumns', 'tblList');
            $("#ddlColumns").val(selectValue);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            removeLoader("#divLoader");
        }
    });
}

function ItemDelete(id) {
    $.ajax({
        url: '/FinanceItems/GetItemData',
        data: { "ID": id },
        type: "POST",
        datatype: "json",
        async: false,
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (data) {
            if (data.isSuccess) {
                if (data.data[0].subItemCount > 0) {
                    BootstrapDialog.show({
                        id: "divImpersonation",
                        title: __WARNING,
                        type: getDialogType(__WARNING),
                        size: BootstrapDialog.SIZE_NORMAL,
                        message: function () {
                            var $message = $('<div id="divImpersonationCh" class="box box-no-border-shadow pTB10-LR05" style="margin:0px;"></div>');

                            var result = '';
                            result += '<div class="modal-body cust-modal-body">';
                            result += "To delete this item, please delete all of its associated sub-items.",

                                result += '</div>';

                            $message.append(result);
                            return $message;
                        },
                        buttons: [
                            {
                                label: __ok,
                                cssClass: 'btn btn-primary',
                                action: function (dialog) {
                                    dialog.close();
                                }
                            }
                        ],
                        onshown: function (dialogRef) {
                            //
                        },
                        closeByBackdrop: false,
                        closable: false,
                    });
                }

                else {
                    BootstrapDialog.show({
                        id: "divImpersonation",
                        title: __WARNING,
                        type: getDialogType(__WARNING),
                        size: BootstrapDialog.SIZE_NORMAL,
                        message: function () {
                            var $message = $('<div id="divImpersonationCh" class="box box-no-border-shadow pTB10-LR05" style="margin:0px;"></div>');

                            var result = '';
                            result += '<div class="modal-body cust-modal-body">';
                            result += "Are you sure you want to delete the Item?",

                                result += '</div>';

                            $message.append(result);
                            return $message;
                        },
                        buttons: [
                            {
                                label: __ok,
                                cssClass: 'btn btn-primary',
                                action: function (dialog) {
                                    //var grName = $("#GroupName").val();

                                    $("#divLoader").append(getLoader());
                                    $.ajax({
                                        url: '/FinanceItems/DeleteItem',
                                        data: { "ID": id },
                                        type: "POST",
                                        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                                        dataType: "json",
                                        cache: false,
                                        success: function (data) {
                                            if (data.isSuccess) {
                                                BootstrapDialog.show({
                                                    id: "divManageDocDeletFolder",
                                                    title: __SUCCESS,
                                                    type: getDialogType(__SUCCESS),
                                                    message: function () {
                                                        var $message = $('<div id="divManageDocDeletFolderInner"></div>');
                                                        $message.append("Record deleted successfully");
                                                        return $message;
                                                    },
                                                });
                                                removeRow("row_" + id);
                                            }
                                            else if (!data.isSuccess) {
                                            }
                                        },
                                        complete: function () {
                                            setTimeout(function () {
                                                removeLoader("#divLoader");
                                                $('#divManageDocDeletFolder').modal('toggle');
                                                location.reload(true);
                                            }, 1000);
                                        },
                                        error: function (xhr, ajaxOptions, thrownError) {
                                            setTimeout(function () {
                                            }, 300);
                                            console.log(xhr.error().statusText);
                                        }
                                    });

                                    dialog.close();
                                }
                            },
                            {
                                label: __Cancel,
                                cssClass: 'btn btn-default',
                                action: function (dialogItself) {
                                    dialogItself.close();
                                }
                            }
                        ],
                        onshown: function (dialogRef) {
                            //
                        },
                        closeByBackdrop: false,
                        closable: false,
                    });
                }
            }
        },

        complete: function () {
            //setTimeout(function () {
            //    removeLoader("#divLoader");
            //    $('#divManageDocDeletFolder').modal('toggle');
            //    location.reload(true);
            //}, 1000);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () {
            }, 300);
            console.log(xhr.error().statusText);
        }
    });
}

function EnableDisableSchool(obj, id, action, type) {
    $.ajax({
        url: window.location.origin + '/School/GetHQStatus',
        type: "GET",
        data: { ID: id },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            if (data.isSuccess) {
                var HQdata = data.data;
                if (HQdata.statusId == 0) {
                    showBSAlert(__requiredCaption, "The HQ Admin for this school is disabled. Please enable the HQ Admin to enable this school.", __WARNING);
                } else {
                    BootstrapDialog.show({
                        id: "divImpersonation",
                        title: __WARNING,
                        type: getDialogType(__WARNING),
                        size: BootstrapDialog.SIZE_NORMAL,
                        message: function () {
                            var $message = $('<div id="divImpersonationCh" class="box box-no-border-shadow pTB10-LR05" style="margin:0px;"></div>');

                            var result = '';
                            result += '<div class="modal-body cust-modal-body">';

                            if (action == 0) {
                                result += "Are you sure you want to Disable this School!";
                            }
                            else if (action == 2) {
                                result += "Are you sure you want to Delete this School!";
                            }
                            else {
                                result += "Are you sure you want to Enable this School!";
                            }

                            result += '</div>';

                            $message.append(result);
                            return $message;
                        },
                        buttons: [
                            {
                                label: __ok,
                                cssClass: 'btn btn-primary',
                                action: function (dialog) {
                                    if (obj) {
                                        //BootstrapDialog.confirm(__confirmMessage, function (result) {
                                        //    if (result) {
                                        $("#divLoader").append(getLoader());
                                        $.ajax({
                                            url: changeStatusUrl,
                                            data: { "ID": id, "StatusID": action, "type": type },
                                            type: "POST",
                                            cache: false,
                                            //contentType: "application/json; charset=utf-8",
                                            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                                            dataType: "json",
                                            success: function (data) {
                                                if (data != null) {
                                                    removeLoader("#divLoader");
                                                    if (data.isSuccess) {
                                                        if (data.message != "")
                                                            showBSAlert(data.messageCaption, data.message, __SUCCESS);
                                                        var onclick = "changeStatus(this,'" + id + "','0')";
                                                        if (action == '0') {
                                                            onclick = "changeStatus(this,'" + id + "','1')";
                                                        }
                                                        $(obj).attr("onclick", "");
                                                        $(obj).attr("data-toggle", "");
                                                        $(obj).removeAttr("data-original-title");
                                                        $(obj).attr("onclick", onclick);
                                                        $(obj).siblings().attr("title", "");
                                                        $(obj).siblings().attr("data-toggle", "tooltip");
                                                        $(obj).siblings().attr("class", "btn-fa-addCustom");

                                                        if (action == '1') {
                                                            $(obj).attr("class", "btn-fa-addCustom btnCust_unlock");
                                                            $(obj).attr("data-original-title", __deActivate);
                                                            $(obj).children().attr("class", "fa fa-unlock");
                                                            $(obj).next().hide();
                                                        }
                                                        else if (action != '2') {
                                                            if ($(obj).attr("id") == "DeActive") {
                                                                $(obj).prev().hide();
                                                            }
                                                            $(obj).attr("class", "btn-fa-addCustom btnCust_lock");
                                                            $(obj).attr("data-original-title", __activate);
                                                            $(obj).children().attr("class", "fa fa-lock");
                                                        }
                                                        else if (action == '2') {
                                                            //Remove row
                                                        }
                                                        $('[data-toggle="tooltip"]').tooltip();
                                                        removeRow("row_" + id);
                                                    }
                                                }
                                            },
                                            error: function (xhr, ajaxOptions, thrownError) {
                                                removeLoader("#divLoader");
                                            }
                                        });
                                        //    }
                                        //});
                                    }

                                    dialog.close();
                                }
                            },
                            {
                                label: __Cancel,
                                cssClass: 'btn btn-default',
                                action: function (dialogItself) {
                                    dialogItself.close();
                                }
                            }
                        ],
                        onshown: function (dialogRef) {
                            //
                        },
                        closeByBackdrop: false,
                        closable: false,
                    });
                }
            }
            else if (!data.isSuccess) {
            }
        },
        complete: function () {
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.error().statusText);
        }
    });
}
function GenerateInvoicePDF(id, Type) {
    $("#divLoader").append(getLoader());
    $.ajax({
        url: '/FinancePaymentAndTransaction/GenerateInvoicePDF',
        data: { "id": id, "pdfType": Type },
        type: "POST",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            if (data.isSuccess) {
                var filePath = data.data.schoolNote;

                // Create a link element
                var link = document.createElement('a');
                link.href = filePath;

                // Set the download attribute to give the file a specific name
                link.download = data.data.invoiceName;

                // Append the link to the document
                document.body.appendChild(link);

                // Trigger a click event on the link
                link.click();

                // Remove the link from the document
                document.body.removeChild(link)
            }
        },
        complete: function () {
            setTimeout(function () {
                removeLoader("#divLoader");
            }, 1000);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () {
            }, 300);
            console.log(xhr.error().statusText);
        }
    });
}