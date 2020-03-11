var SkillsController = function (pageElementHelpers, jobService, skillService) {

    var jobsInit = function (container) {

        var success = function (data) {
            var option = "";
            
            $.each(data, function (i) {
                option += '<option value="' + data[i].id + '">' + data[i].seniorityLevel + " " + data[i].title + '</option>';
            });

            $(container).html(option);
        };

        var fail = function () {
            alert('Something failed!');
        };
      
        jobService.getJobs(success, fail);
    };

    var jobsDropdownOnChange = function (table, skillDetailsAction) {
        $('#searchJob').on('change', function () {
            var selectedJobId = $('#searchJob option:selected').attr('value');

            table.destroy();
            table = SkillsController.skillsInit("#skills", selectedJobId, skillDetailsAction);
        });
    };

    var allSkillsInit = function (container, skillDetailsAction, type, status) {
        $(container).DataTable({
            ajax: skillService.getAllSkillsDatatable(type, status),
            columns: [
                {
                    data: "name",
                    render: function (data, type, skill) {
                        return '<a href="' + skillDetailsAction + "/" + skill.id + '">' + data + '</a>';
                    }
                },
                {
                    data: "type"
                },
                {
                    data: "description"
                },
                {
                    data: "isEnabled",
                    render: function (data, type, skill) {
                        return data ? '<i class="fas fa-check" style="color:green;"></i>' : '<i class="fas fa-times" style="color:red;"></i>';
                    }
                }
            ],
            dom: 'Bfrtip',
            buttons: [
                'copyHtml5',
                'excelHtml5',
                'csvHtml5',
                'pdfHtml5'
            ]
        });
    };

    var skillsInit = function (container, jobId, skillDetailsAction) {
        var table = $(container).DataTable({
            ajax: skillService.getSkillsForJobDatatable(jobId),
            columns: [
                {
                    data: "name",
                    render: function (data, type, skill) {
                        return '<a href="' + skillDetailsAction + "/" + skill.id + '">'+ data +'</a>';
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

        return table;
    };

    var skillInit = function (skillTypeContainer, skillNameContainer,
        skillDescriptionContainer, skillCreationDateContainer, skillId) {

        var success = function (data) {
            $(skillTypeContainer).html(data.type);
            $(skillNameContainer).html(data.name);
            $(skillDescriptionContainer).append(data.description);
            $(skillCreationDateContainer).html(data.creationDate);
        };

        var fail = function () {
            alert('Something failed!');
        };

        skillService.getSkill(skillId, success, fail);
    }

    var createSkill = function () {
        var postSuccess = function () {
            pageElementHelpers.toggleModal("green", "Skill created");
        };

        var postFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "Skill not created!" + errorThrown);
        };

        $("#submitSkillForm").click(function () {
            skillService.postSkill(postSuccess, postFail);

            setTimeout(function () {
                window.location.href = "https://localhost:44375/Skills/AllSkills"
            }, 2500);
        });
    };

    return {
        jobsInit: jobsInit,
        jobsDropdownOnChange: jobsDropdownOnChange,
        allSkillsInit: allSkillsInit,
        skillsInit: skillsInit,
        skillInit: skillInit,
        createSkill: createSkill
    }

}(PageElementHelpers, JobService, SkillService);