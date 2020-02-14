﻿var SkillDetailsController = function (pageElementHelpers, skillService) {

    var animations = function (isEnabled) {
        $(".fa-edit").hide();
        typeAnimations();
        nameAnimations();
        descriptionAnimations();
        buttonAnimations(isEnabled);
    };

    var typeAnimations = function () {
        pageElementHelpers.toggleEditIcon(".card-header", "#inputType", "#typeEdit");
        pageElementHelpers.onClickEditIcon("#typeEdit", "#skillType", "#inputType");
        pageElementHelpers.onEditUnfocus("#inputType", "#skillType");
    };

    var nameAnimations = function () {
        pageElementHelpers.toggleEditIcon(".card-title", "#inputName", "#nameEdit");
        pageElementHelpers.onClickEditIcon("#nameEdit", "#skillName", "#inputName");
        pageElementHelpers.onEditUnfocus("#inputName", "#skillName");
    };

    var descriptionAnimations = function () {
        pageElementHelpers.toggleEditIcon(".description", "#inputDescription", "#descriptionEdit");
        pageElementHelpers.onClickEditIcon("#descriptionEdit", "#skillDescription", "#inputDescription");
        pageElementHelpers.onEditUnfocus("#inputDescription", "#skillDescription");
    };

    var buttonAnimations = function (isEnabled) {
        $("#submitChanges").hide();
        $("#discardChanges").hide();

        if (isEnabled)
            $("#disableSkill").show();
        else
            $("#enableSkill").show();

        $("#discardChanges").click(function () {
            location.reload();
        });

        pageElementHelpers.onInputChange("#inputType", "#submitChanges", "#discardChanges");
        pageElementHelpers.onInputChange("#inputName", "#submitChanges", "#discardChanges");
        pageElementHelpers.onInputChange("#inputDescription", "#submitChanges", "#discardChanges");
    };

    var success = function () {
        pageElementHelpers.toggleModal("green", "Skill updated");
    };

    var fail = function (xhr, textStatus, errorThrown) {
        var errorMessage = xhr.status + ': ' + xhr.statusText;
        pageElementHelpers.toggleModal("red", "Skill not updated!" + errorThrown);
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

    var disableSuccess = function () {
        pageElementHelpers.toggleModal("green", "Skill disabled");
        $("#disableSkill").hide();
        $("#enableSkill").show();
    };

    var disableFail = function (xhr, textStatus, errorThrown) {
        var errorMessage = xhr.status + ': ' + xhr.statusText;
        pageElementHelpers.toggleModal("red", "Skill not disabled!" + errorThrown);
    };

    var disableSkill = function (id) {
        var disablePatchDoc = skillService.getSkillDisablePatchDocument();

        $("#disableSkill").click(function (e) {
            skillService.patchSkill(id, disablePatchDoc, disableSuccess, disableFail);
            e.preventDefault();
        });
    };

    var enableSuccess = function () {
        pageElementHelpers.toggleModal("green", "Skill enabled");
        $("#disableSkill").show();
        $("#enableSkill").hide();
    };

    var enableFail = function (xhr, textStatus, errorThrown) {
        var errorMessage = xhr.status + ': ' + xhr.statusText;
        pageElementHelpers.toggleModal("red", "Skill not enabled!" + errorThrown);
    };

    var enableSkill = function (id) {
        var enablePatchDoc = skillService.getSkillEnablePatchDocument();

        $("#enableSkill").click(function (e) {
            skillService.patchSkill(id, enablePatchDoc, enableSuccess, enableFail);
            e.preventDefault();
        });
    };

    var toggleSkillStatus = function (id) {
        disableSkill(id);
        enableSkill(id);
    };

    return {
        animations: animations,
        updateSkill: updateSkill,
        toggleSkillStatus: toggleSkillStatus
    }
}(PageElementHelpers, SkillService);