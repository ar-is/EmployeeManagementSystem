var SkillService = function () {

    //var getSkillsForJob = function (jobId, success, fail) {
    //    $.ajax({
    //        url: "http://localhost:5001/api/jobs/" + jobId + "/skills",
    //        method: "GET"
    //    })
    //        .then(success)
    //        .fail(fail);
    //};

    var getAllSkillsDatatable = function (status) {
        return {
            url: "http://localhost:5001/api/skills/?status=" + status,
            dataSrc: ""
        };
    };

    var getSkillsForJobDatatable = function (jobId) {
        return {
            url: "http://localhost:5001/api/jobs/" + jobId + "/skills",
            dataSrc: "",
            headers: {
                "Accept": "application/json"
            }
        };
    };

    var getSkill = function (skillId, success, fail) {
        $.ajax({
            url: "http://localhost:5001/api/skills/" + skillId,
            method: "GET"
        })
            .then(success)
            .fail(fail);
    }

    var getSkillPatchDocument = function (patch) {

        $("#inputType").change(function () {
            var typeValue = $('#inputType').find(":selected").text();
            var typePatch = { "op": "replace", "path": "/type", "value": typeValue };

            if (!patch.find(p => p === typePatch))
                patch.push(typePatch);
        });

        $("#inputName").change(function () {
            var nameValue = $('#inputName').val();
            var namePatch = { "op": "replace", "path": "/name", "value": nameValue };

            if (!patch.find(p => p === namePatch))
                patch.push(namePatch);
        });

        $("#inputDescription").change(function () {
            var descriptionValue = $('#inputDescription').val();
            var descriptionPatch = { "op": "replace", "path": "/description", "value": descriptionValue };

            if (!patch.find(p => p === descriptionPatch))
                patch.push(descriptionPatch);
        });
    };

    var getSkillDisablePatchDocument = function () {
        return [ { "op": "replace", "path": "/isEnabled", "value": false } ];
    };

    var getSkillEnablePatchDocument = function () {
        return [{ "op": "replace", "path": "/isEnabled", "value": true }];
    };

    var patchSkill = function (id, patch, success, fail) {
        $.ajax({
            type: "PATCH",
            url: "http://localhost:5001/api/skills/" + id,
            data: JSON.stringify(patch),
            processData: false,
            contentType: 'application/json-patch+json'
        })
            .then(success, fail);
    };

    return {
        //getSkillsForJob: getSkillsForJob
        getAllSkillsDatatable: getAllSkillsDatatable,
        getSkillsForJobDatatable: getSkillsForJobDatatable,
        getSkill: getSkill,
        getSkillPatchDocument: getSkillPatchDocument,
        getSkillDisablePatchDocument: getSkillDisablePatchDocument,
        getSkillEnablePatchDocument: getSkillEnablePatchDocument,
        patchSkill: patchSkill
    }
}();