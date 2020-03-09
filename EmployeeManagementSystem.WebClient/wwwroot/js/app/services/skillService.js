var SkillService = function () {

    //var getSkillsForJob = function (jobId, success, fail) {
    //    $.ajax({
    //        url: "http://localhost:5001/api/jobs/" + jobId + "/skills",
    //        method: "GET"
    //    })
    //        .then(success)
    //        .fail(fail);
    //};

    var getSkills = function (type, success, fail) {
        $.ajax({
            url: "http://localhost:5001/api/skills/?type=" + type,
            method: "GET"
        })
            .then(success)
            .fail(fail);
    };

    var getAllSkillsDatatable = function (type, status) {
        return {
            url: "http://localhost:5001/api/skills/?type=" + type + "&status=" + status,
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

    var getSkillsByName = function (skillNames, success, fail) {
        $.ajax({
            url: "http://localhost:5001/api/skillsByName/?skillNames=" + skillNames,
            method: "GET"
        })
            .then(success)
            .fail(fail);
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

        var jobIds = [];
        $(".form-check input:checkbox:checked").map(function () {
            jobIds.push({ jobId: $(this).data('id') });
        });

        var jobsPatch = { "op": "replace", "path": "/jobSkills", "value": jobIds };

        if (!patch.find(p => p === jobsPatch))
            patch.push(jobsPatch);   
    };

    var getJobSkillsPatchDocument = function (patch) {
        var jobIds = [];
        $(".form-check input:checkbox:checked").map(function () {
            jobIds.push({ jobId: $(this).data('id') });
        });

        var jobsPatch = { "op": "replace", "path": "/jobSkills", "value": jobIds };

        if (!patch.find(p => p === jobsPatch))
            patch.push(jobsPatch);
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

    var postSkill = function (success, fail) {

        var jobIds = [];
        $(".form-check input:checkbox:checked").map(function () {
            jobIds.push({ jobId: $(this).data('id') });
        });

        var skillToCreate = {
            type: $("#postType").find(":selected").text(),
            name: $("#postName").val(),
            description: $("#postDescription").val(),
            isEnabled: true,
            jobSkills: jobIds
        };

        $.ajax({
            type: "POST",
            url: "http://localhost:5001/api/skills/",
            data: JSON.stringify(skillToCreate),
            contentType: 'application/json'
        })
            .then(success, fail);
    };

    var postSkillCollection = function (allNewSkills, success, fail) {
        $.ajax({
            type: "POST",
            url: "http://localhost:5001/api/skillcollections/",
            data: JSON.stringify(allNewSkills),
            contentType: 'application/json'
        })
            .then(success, fail);
    }

    var deleteSkill = function (id, success, fail) {
        $.ajax({
            type: "DELETE",
            url: "http://localhost:5001/api/skills/" + id
        })
            .then(success, fail);
    };

    return {
        //getSkillsForJob: getSkillsForJob
        getSkills: getSkills,
        getAllSkillsDatatable: getAllSkillsDatatable,
        getSkillsForJobDatatable: getSkillsForJobDatatable,
        getSkillsByName: getSkillsByName,
        getSkill: getSkill,
        getSkillPatchDocument: getSkillPatchDocument,
        getSkillDisablePatchDocument: getSkillDisablePatchDocument,
        getSkillEnablePatchDocument: getSkillEnablePatchDocument,
        getJobSkillsPatchDocument: getJobSkillsPatchDocument,
        patchSkill: patchSkill,
        postSkill: postSkill,
        postSkillCollection: postSkillCollection,
        deleteSkill: deleteSkill
    }
}();