var SkillDetailsController = function (skillService) {

    var animations = function () {

        $(".fa-edit").hide();
        typeAnimations();
        nameAnimations();
        descriptionAnimations();
        buttonAnimations();
    };

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

    var typeAnimations = function () {
        toggleEditIcon(".card-header", "#inputType", "#typeEdit");
        onClickEditIcon("#typeEdit", "#skillType", "#inputType");
        onEditUnfocus("#inputType", "#skillType");
    };

    var nameAnimations = function () {
        toggleEditIcon(".card-title", "#inputName", "#nameEdit");
        onClickEditIcon("#nameEdit", "#skillName", "#inputName");
        onEditUnfocus("#inputName", "#skillName");
    };

    var descriptionAnimations = function () {
        toggleEditIcon(".description", "#inputDescription", "#descriptionEdit");
        onClickEditIcon("#descriptionEdit", "#skillDescription", "#inputDescription");
        onEditUnfocus("#inputDescription", "#skillDescription");
    };

    var buttonAnimations = function () {
        $("#submitChanges").hide();
        $("#discardChanges").hide();

        $("#discardChanges").click(function () {
            location.reload();
        });

        onInputChange("#inputType", "#submitChanges", "#discardChanges");
        onInputChange("#inputName", "#submitChanges", "#discardChanges");
        onInputChange("#inputDescription", "#submitChanges", "#discardChanges");
    };

    var onInputChange = function (inputContainer, saveButton, discardButton) {
        $(inputContainer).change(function () {
            $(saveButton).show();
            $(discardButton).show();
        });
    };

    var toggleModal = function (color, message) {
        var dialog = bootbox.dialog({
            message: "<span style='color: "+ color +"'>" + message +"</span>",
            closeButton: false,
            centerVertical: true
        });

        setTimeout(function () {
            dialog.modal('hide');
        }, 2000);
    };

    var success = function () {
        toggleModal("green", "Skill updated");
    };

    var fail = function () {
        toggleModal("red", "Skill not updated!");
    };

    var updateSkill = function (id) {
        var patch = [];
        skillService.getSkillPatchDocument(patch);

        $("#submitChanges").click(function (e) {
            skillService.patchSkill(id, patch, success, fail);

            $("#submitChanges").hide();
            $("#discardChanges").hide();
            e.preventDefault();
        });
    };

    return {
        animations: animations,
        updateSkill: updateSkill
    }
}(SkillService);