var SkillService = function () {

    var getSkillsForJob = function (jobId, success, fail) {
        $.ajax({
            url: "http://localhost:5001/api/jobs/" + jobId + "/skills",
            method: "GET"
        })
            .then(success)
            .fail(fail);
    };

    return {
        getSkillsForJob: getSkillsForJob
    }
}();