var EmployeesController = function (pageElementHelpers, skillService, employeeService) {

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
            $("#allEmployees").dataTable().$("tr.selected").each(function () {
                var data = table.row(this).data();
                location.href = employeeDetailsAction + "/" + data.id;
            });
        });      
    };

    var allEmployeesInit = function (container, employeeDetailsAction) {
        var table = $(container).DataTable({
            ajax: employeeService.getAllEmployeesDatatable(),
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

                //var skillIds = [];
                //$(".form-check input:checkbox:checked").map(function () {
                //    if (typeof $(this).data('id') !== 'undefined') {
                //        skillsIds.push({ skillId: $(this).data('id') });
                //    }
                //});

                //var asd = [...skillIds, ...newSkillIds];

                //var employeeToCreate = {
                //    name: $("#postEmpName").val(),
                //    surname: $("#postEmpSurname").val(),
                //    jobId: $("#postEmpJob").find(':selected').data('id'),
                //    hiringDate: $("#postHiringDate").val(),
                //    phoneNumber: $("#postEmpPhone").val(),
                //    email: $("#postEmpEmail").val(),
                //    employeeSkills: skillsIds
                //};

                //$.ajax({
                //    type: "POST",
                //    url: "http://localhost:5001/api/employees/",
                //    data: JSON.stringify(employeeToCreate),
                //    contentType: 'application/json'
                //})
                //    .then(postEmpSuccess, postEmpFail);
            };

            var getSkillsByNameFail = function (xhr, textStatus, errorThrown) {
                pageElementHelpers.toggleModal("red", "Could not get new skills!" + errorThrown);
            };

            var skillNames = allNewSkills.map(s => s.name);
            var skillNamesString = skillNames.toString();

            //$.ajax({
            //    url: "http://localhost:5001/api/skillsByName/?skillNames=" + skillNamesString,
            //    method: "GET"
            //})
            //    .then(getSkillsByNameSuccess)
            //    .fail(getSkillsByNameFail);

            //var skillNames = allNewSkills.map(s => s.name);

            //var getSkillsByNameSuccess = function (data) {
            //    var newSkillsIds = [];

            //    $.each(data, function (i, item) {
            //        newSkillsIds.push(data[i].id);
            //    });

            //    employeeService.postEmployee(newSkillsIds, postEmpSuccess, postEmpFail);
            //};

            //var getSkillsByNameFail = function (xhr, textStatus, errorThrown) {
            //    pageElementHelpers.toggleModal("red", "Could not get new skills!" + errorThrown);
            //};

            skillService.getSkillsByName(skillNamesString, getSkillsByNameSuccess, getSkillsByNameFail);
        };

        var postSkillCollectionFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "New Skills not created!" + errorThrown);
        };

        //var postEmpSuccess = function () {
        //    pageElementHelpers.toggleModal("green", "Employee created");
        //};

        //var postEmpFail = function (xhr, textStatus, errorThrown) {
        //    pageElementHelpers.toggleModal("red", "Employee not created!" + errorThrown);
        //};

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
        allEmployeesInit: allEmployeesInit,
        createEmployee: createEmployee,
        deleteMultipleEmployees: deleteMultipleEmployees
    }

}(PageElementHelpers, SkillService, EmployeeService);