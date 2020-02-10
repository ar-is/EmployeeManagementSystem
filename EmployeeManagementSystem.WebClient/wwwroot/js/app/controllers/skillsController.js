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
                    data: "name",
                    render: function (data, type, skill) {
                        return '<a href="' + skillDetailsAction + "/" + skill.id + '">'+data+'</a>';
                    }
                },
                {
                    data: "type"
                },
                {
                    data: "description"
                }
            ]
        });
    };

    var skillInit = function (skillTypeContainer, skillNameContainer,
        skillDescriptionContainer, skillCreationDateContainer, skillId) {

        var success = function (data) {
            $(skillTypeContainer).html(data.type);
            $(skillNameContainer).html(data.name);
            $(skillDescriptionContainer).html(data.description);
            $(skillCreationDateContainer).html("Creation Date" + " : " + data.creationDate);
        };

        var fail = function () {
            alert('Something failed!');
        };

        skillService.getSkill(skillId, success, fail);
    }

    return {
        jobsInit: jobsInit,
        skillsInit: skillsInit,
        skillInit: skillInit
    }

}(JobService, SkillService);