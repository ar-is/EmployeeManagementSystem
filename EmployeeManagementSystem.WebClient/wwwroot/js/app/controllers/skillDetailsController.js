var SkillDetailsController = function (pageElementHelpers, skillService) {

    var animations = function (isEnabled) {
        //$(".fa-edit").hide();
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
        pageElementHelpers.onInputChange(".form-check", "#submitChanges", "#discardChanges");
    };

    var success = function () {
        pageElementHelpers.toggleModal("green", "Skill updated");
    };

    var fail = function (xhr, textStatus, errorThrown) {
        var errorMessage = xhr.status + ': ' + xhr.statusText;
        pageElementHelpers.toggleModal("red", "Skill not updated!" + errorThrown + errorMessage);
    };

    var updateSkill = function (id) {
        var patch = [];
        skillService.getSkillPatchDocument(patch);

        $("#submitChanges").click(function (e) {
            skillService.getJobSkillsPatchDocument(patch);
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
            skillService.getJobSkillsPatchDocument(disablePatchDoc);
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
            skillService.getJobSkillsPatchDocument(enablePatchDoc);
            skillService.patchSkill(id, enablePatchDoc, enableSuccess, enableFail);
            e.preventDefault();
        });
    };

    var toggleSkillStatus = function (id) {
        disableSkill(id);
        enableSkill(id);
    };

    var deleteSkill = function (id) {
        var deleteSuccess = function () {
            pageElementHelpers.toggleModal("green", "Skill deleted");
            reload();
        };

        var deleteFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "Skill not deleted!" + errorThrown);
            reload();
        };

        var reload = function () {
            setTimeout(function () {
                window.location.href = "https://localhost:44375/Skills/AllSkills"
            }, 2500);
        };

        var deleteCallback = function () {
            skillService.deleteSkill(id, deleteSuccess, deleteFail);
        };

        $("#deleteSkill").click(function () {
            pageElementHelpers.deleteToggleModal("this skill", deleteCallback)
        });
    };

    return {
        animations: animations,
        updateSkill: updateSkill,
        toggleSkillStatus: toggleSkillStatus,
        deleteSkill: deleteSkill
    }
}(PageElementHelpers, SkillService);