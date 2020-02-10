var SkillService = function () {

    //var getSkillsForJob = function (jobId, success, fail) {
    //    $.ajax({
    //        url: "http://localhost:5001/api/jobs/" + jobId + "/skills",
    //        method: "GET"
    //    })
    //        .then(success)
    //        .fail(fail);
    //};

    var getSkillsForJobDatatable = function (jobId) {
        return {
            url: "http://localhost:5001/api/jobs/" + jobId + "/skills",
            dataSrc: "",
            headers: {
                "Accept": "application/json"
            }
        };
    };

    return {
        //getSkillsForJob: getSkillsForJob
        getSkillsForJobDatatable: getSkillsForJobDatatable
    }
}();