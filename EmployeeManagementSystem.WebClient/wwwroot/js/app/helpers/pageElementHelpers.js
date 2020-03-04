var PageElementHelpers = function () {

    var toggleEditIcon = function (mainContainer, inputContainer, iconContainer) {
        $(mainContainer).hover(function () {
            if ($(inputContainer).is(':hidden'))
                $(iconContainer).show();
        }, function () {
            $(iconContainer).hide();
        });
    };

    var onClickEditIcon = function (iconContainer, valueContainer, inputContainer) {
        $(iconContainer).on('click', function () {
            $(iconContainer).hide();
            $(valueContainer).css({ 'display': "none" });
            $(inputContainer).css({ 'display': 'inline-block' });
            $(inputContainer).focus();
            $(inputContainer).val($(valueContainer).html());
        });
    };

    var onEditUnfocus = function (inputContainer, valueContainer) {
        $(inputContainer).focusout(function () {
            $(valueContainer).html($(inputContainer).val());
            $(inputContainer).css({ 'display': 'none' });
            $(valueContainer).css({ 'display': "inline-block", "margin-top": "2px" });
        });
    };

    var onInputChange = function (inputContainer, saveButton, discardButton) {
        $(inputContainer).change(function () {
            $(saveButton).show();
            $(discardButton).show();
        });
    };

    var toggleModal = function (color, message) {
        var dialog = bootbox.dialog({
            message: "<span style='color: " + color + "'>" + message + "</span>",
            closeButton: false,
            centerVertical: true
        });

        setTimeout(function () {
            dialog.modal('hide');
        }, 2000);
    };

    var deleteToggleModal = function (element, deleteCallback) {
        var dialog = bootbox.dialog({
            centerVertical: true,
            title: '! Delete !',
            message: "<p>After deletion, " + element + " will not be available. Do you still want to delete? </p>",
            size: 'large',
            buttons: {
                cancel: {
                    label: "Cancel",
                    className: 'btn-info',
                    callback: function () { }
                },
                ok: {
                    label: "Delete",
                    className: 'btn-danger',
                    callback: deleteCallback
                }
            }
        });

        return dialog;
    };

    return {
        toggleEditIcon: toggleEditIcon,
        onClickEditIcon: onClickEditIcon,
        onEditUnfocus: onEditUnfocus,
        onInputChange: onInputChange,
        toggleModal: toggleModal,
        deleteToggleModal: deleteToggleModal
    }
}();