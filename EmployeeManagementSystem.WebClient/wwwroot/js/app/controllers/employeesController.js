﻿var EmployeesController = function (pageElementHelpers, skillService, employeeService) {

    var animations = function (table, employeeDetailsAction) {

        table.on('select deselect', function (e, dt, type, indexes) {
            var count = table.rows({ selected: true }).count();

            if (count > 0) {
                $("#deleteEmployees").show();
                $("#deleteEmployees").text((count > 1) ? 'Delete Selected' : 'Delete');

                if (count == 1)
                    $("#editEmployee").show();
                else
                    $("#editEmployee").hide();

            } else {
                $("#editEmployee").hide();
                $("#deleteEmployees").hide();
            }
        });

        $("#editEmployee").click(function () {
            table.$("tr.selected").each(function () {
                var data = table.row(this).data();
                location.href = employeeDetailsAction + "/" + data.id;
            });
        });      
    };

    var skillsFilterCheckboxesInit = function () {
        var getSkillsCheckboxesSuccess = function (data) {
            $.each(data, function (i, item) {
                if (data[i].type === "Soft") {
                    $("#softSkills").append('<option value="' + data[i].id + '" data-id="' + data[i].id + '">' + data[i].name + '</option>');
                }
                else if (data[i].type === "Technical") {
                    $("#techSkills").append('<option value="' + data[i].id + '" data-id="' + data[i].id + '">' + data[i].name + '</option>');
                }

                $('#skillFilter').multiselect('rebuild');
            });
        };

        var getSkillsCheckboxesFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "Skills Filter not rendered! " + errorThrown);
        };

        $('#skillFilter').multiselect({
            enableClickableOptGroups: true,
            includeSelectAllOption: true,
            buttonWidth: '30%',
            nonSelectedText: 'Filter by Skill(s)'
        });

        skillService.getSkills(getSkillsCheckboxesSuccess, getSkillsCheckboxesFail);
    };

    var skillsFilterCheckboxesOnChange = function (table, employeeDetailsAction) {
        $('#skillFilter').on('change', function () {
            var selected = $(this).find('option:selected', this);
            var skillIds = [];

            selected.each(function (index, element) {

                thisVal = $(this).val();

                if (!skillIds.find(s => s === $(this).data('id')))
                    skillIds.push($(this).data('id'));
            });

            var skillIdsString = skillIds.join(',');
            table.destroy();
            table = EmployeesController.allEmployeesInit("#allEmployees", skillIdsString, employeeDetailsAction);
            EmployeesController.animations(table, employeeDetailsAction);
            EmployeesController.deleteMultipleEmployees(table);
        });
    };

    var allEmployeesInit = function (container, skillIds, employeeDetailsAction) {
        var table = $(container).DataTable({
            ajax: employeeService.getAllEmployeesDatatable(skillIds),
            columnDefs: [
                {
                    targets: 0,
                    data: null,
                    defaultContent: '',
                    orderable: false,
                    className: 'select-checkbox',
                },
                {
                    targets: 1,
                    data: "name"
                },
                {
                    targets: 2,
                    data: "surname"
                },
                {
                    targets: 3,
                    data: "hiringDate",
                    render: function (data, type, row) {
                        return moment(data).format('dddd, MMMM Do, YYYY');
                    }
                },
                {
                    targets: 4,
                    data:  "department"
                },
                {
                    targets: 5,
                    data: "job"
                },
                {
                    targets: 6,
                    data: "id",
                    render: function (data, type, row) {
                        return '<a href="' + employeeDetailsAction + "/" + row.id + '">Details</a>';
                    }
                }],
            select: {
                style: 'multi',
                selector: 'td:first-child'
            },
            order: [[1, "asc"]]
        });

        $(container).on('click', '#select_all', function () {
            if ($('#select_all:checked').val() === 'on')
                table.rows().select();
            else
                table.rows().deselect();
        });	

        return table;
    };

    var createEmployee = function (allNewSkills) {

        var postSkillCollectionSuccess = function () {

            var getSkillsByNameSuccess = function (data) {
                var skillsIds = [];

                $.each(data, function (i, item) {
                    skillsIds.push({ skillId: data[i].id });
                });

                var postEmpSuccess = function () {
                    pageElementHelpers.toggleModal("green", "Employee created");
                };

                var postEmpFail = function (xhr, textStatus, errorThrown) {
                    pageElementHelpers.toggleModal("red", "Employee not created!" + errorThrown);
                };

                EmployeeService.postEmployee(skillsIds, postEmpSuccess, postEmpFail);
            };

            var getSkillsByNameFail = function (xhr, textStatus, errorThrown) {
                pageElementHelpers.toggleModal("red", "Could not get new skills!" + errorThrown);
            };

            var skillNames = allNewSkills.map(s => s.name);
            var skillNamesString = skillNames.toString();

            skillService.getSkillsByName(skillNamesString, getSkillsByNameSuccess, getSkillsByNameFail);
        };

        var postSkillCollectionFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "New Skills not created!" + errorThrown);
        };

        $("#submitEmployeeForm").click(function () {

            if ($('.soft').has('.newSkills').length || $(".technical").has('.newSkills').length) {
                skillService.postSkillCollection(allNewSkills, postSkillCollectionSuccess, postSkillCollectionFail);
            }
            else {
                var skillsIds = [];

                var postEmpSuccess = function () {
                    pageElementHelpers.toggleModal("green", "Employee created");
                };

                var postEmpFail = function (xhr, textStatus, errorThrown) {
                    pageElementHelpers.toggleModal("red", "Employee not created!" + errorThrown);
                };

                EmployeeService.postEmployee(skillsIds, postEmpSuccess, postEmpFail);
            }

            setTimeout(function () {
                window.location.href = "https://localhost:44375/Employees/AllEmployees"
            }, 2500);
        });
    };

    var deleteMultipleEmployees = function (table) {

        var deleteMultipleEmployeesSuccess = function () {
            PageElementHelpers.toggleModal("green", "Employees successfully deleted!");
            reload();
        };

        var deleteMultipleEmployeesFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "Employees not deleted!" + errorThrown);
            reload();
        };

        var reload = function () {
            setTimeout(function () {
                window.location.href = "https://localhost:44375/Employees/AllEmployees"
            }, 2500);
        };

        var deleteCallback = function () {
            var employeeIds = employeeService.getSelectedEmployeesIds(table);

            employeeService.deleteEmployeesCollection(employeeIds, deleteMultipleEmployeesSuccess, deleteMultipleEmployeesFail);
        };

        $("#deleteEmployees").click(function () {
            pageElementHelpers.deleteToggleModal("these employees", deleteCallback);
        });
    };

    return {
        animations: animations,
        skillsFilterCheckboxesInit: skillsFilterCheckboxesInit,
        skillsFilterCheckboxesOnChange: skillsFilterCheckboxesOnChange,
        allEmployeesInit: allEmployeesInit,
        createEmployee: createEmployee,
        deleteMultipleEmployees: deleteMultipleEmployees
    }

}(PageElementHelpers, SkillService, EmployeeService);