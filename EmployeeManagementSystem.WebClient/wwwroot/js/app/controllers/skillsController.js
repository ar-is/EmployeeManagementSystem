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

    var skillsInit = function (container, jobId, skillDetailsAction) {
        $(container).DataTable({
            ajax: skillService.getSkillsForJobDatatable(jobId),
            columns: [
                {
                    data: "name"
                },
                {
                    data: "type"
                },
                {
                    data: "description"
                },
                {
                    data: "id",
                    render: function (data, type, skill) {
                        return '<a href="' + skillDetailsAction + "/" + skill.id + '">Details</a>';
                    }
                }
            ]
        });
    };

    return {
        jobsInit: jobsInit,
        skillsInit: skillsInit
    }

}(JobService, SkillService);