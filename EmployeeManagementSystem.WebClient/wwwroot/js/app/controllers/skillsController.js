var SkillsController = function (jobService, skillService) {

    var jobsInit = function (container, jobId) {
        var success = function (data) {
            var option = "";

            $.each(data, function (i) {
                option += '<option value="' + data[i].id + '">' + data[i].seniorityLevel + " " + data[i].title + '</option>';
            });

            $(container).html(option);
            $(container).val(jobId);
        };

        var fail = function () {
            alert('Something failed!');
        };

        jobService.getJobs(success, fail);
    };

    var skillsForJobInit = function (container, jobId) {
        var success = function (data) {
            $.each(data, function (i) {
                $(container).append("<tr><td>" + data[i].name + "</td><td>" + data[i].type + "</td><td>" + data[i].description + "</td><td>" + data[i].creationDate + "</td></tr>");
            });
        };

        var fail = function () {
            alert('Something failed!');
        };

        skillService.getSkillsForJob(jobId, success, fail);
    }

    return {
        jobsInit: jobsInit,
        skillsForJobInit: skillsForJobInit
    }

}(JobService, SkillService);