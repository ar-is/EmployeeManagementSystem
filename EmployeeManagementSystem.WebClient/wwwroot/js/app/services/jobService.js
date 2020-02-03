var JobService = function () {

    var getJobs = function (success, fail) {
        $.ajax({
            url: "http://localhost:5001/api/jobs",
            method: "GET"
        })
            .then(success)
            .fail(fail);
    };

    return {
        getJobs: getJobs
    }
}();