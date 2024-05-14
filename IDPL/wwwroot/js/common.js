
var funcSelectSentenceChBxVal = [];
var loadView = {
    dashboard: function () {
        $(".nav-sidebar .nav-link").click(function () {
            $('#dashboard').load("dashboard.html");
        });
    },
    createAcc: function () {
        $(".nav-sidebar .nav-link").click(function () {
            $('#createAccount').load("create-account.html");
        });
    }
}

// convert Formdata to object
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function getLoader() {
    return $("#scriptLoader").html();
}
function removeLoader(selector) {
    $(selector).find(".overlay, .loading-img").remove();
}
function getLoaderSmall() {
    return $("#scriptLoaderSmall").html();
}
function removeLoaderSmall(selector) {
    $(selector).find(".overlay, .loading-img-small").remove();
}

function SubmitCreateAccount() {
    var inputMassage = "";
    var valid = true;

    var txtfullname = $("input[name='txtfullname']").val();
    var txtusername = $("input[name='txtusername']").val();
    var userTypeRole = $("select[name='userTypeRole']").val();
    var txtPassword = $("input[name='txtPassword']").val().trim();

    if (txtfullname == "") {
        inputMassage += __Fullname + "<br />";
        valid = false;
    }
    if (txtusername == "") {
        inputMassage += __Username + "<br />";
        valid = false;
    }
    if (userTypeRole == "") {
        inputMassage += __userTypeRole + "<br />";
        valid = false;
    }
    if (txtPassword == "") {
        inputMassage += __Password;
        valid = false;
    }
    if (valid) {
        alert("Action Here");
    }
    else {
        showBSAlert(__warnCaption, inputMassage, __DANGER);
    }
    return valid;
}
