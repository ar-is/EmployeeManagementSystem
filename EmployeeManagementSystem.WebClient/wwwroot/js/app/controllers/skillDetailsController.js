var SkillDetailsController = function (pageElementHelpers, skillService) {

    var animations = function () {
        $(".fa-edit").hide();
        typeAnimations();
        nameAnimations();
        descriptionAnimations();
        buttonAnimations();
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

    var buttonAnimations = function () {
        $("#submitChanges").hide();
        $("#discardChanges").hide();

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

    return {
        animations: animations,
        updateSkill: updateSkill
    }
}(PageElementHelpers, SkillService);