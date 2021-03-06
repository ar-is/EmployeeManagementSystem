﻿var EmployeeService = function () {

    var getAllEmployeesDatatable = function (skillIds) {
        return {
            url: "http://localhost:5001/api/employees?skillguids=" + skillIds,
            dataSrc: ""
        };
    };

    var getSelectedEmployeesIds = function (table) {
        var employeeIds = [];

        $("#allEmployees").dataTable().$("tr.selected").each(function () {
            var data = table.row(this).data();
            employeeIds.push(data.id);
        });

        return employeeIds.join();
    };

    var postEmployee = function (skillsIds, success, fail) {

        $(".form-check input:checkbox:checked").map(function () {
            if (typeof $(this).data('id') !== 'undefined') {
                skillsIds.push({ skillId: $(this).data('id') });
            }
        });

        var employeeToCreate = {
            name: $("#postEmpName").val(),
            surname: $("#postEmpSurname").val(),
            jobId: $("#postEmpJob").find(':selected').data('id'),
            hiringDate: $("#postHiringDate").val(),
            phoneNumber: $("#postEmpPhone").val(),
            email: $("#postEmpEmail").val(),
            employeeSkills: skillsIds
        };

        $.ajax({
            type: "POST",
            url: "http://localhost:5001/api/employees/",
            data: JSON.stringify(employeeToCreate),
            contentType: 'application/json'
        })
            .then(success, fail);
    };

    var getEmployeePatchDocument = function (patch) {

        $("#inputEmpName").change(function () {
            var nameValue = $('#inputEmpName').val();
            var namePatch = { "op": "replace", "path": "/name", "value": nameValue };

            if (!patch.find(p => p === namePatch))
                patch.push(namePatch);
        });

        $("#inputEmpSurname").change(function () {
            var surnameValue = $('#inputEmpSurname').val();
            var surnamePatch = { "op": "replace", "path": "/surname", "value": surnameValue };

            if (!patch.find(p => p === surnamePatch))
                patch.push(surnamePatch);
        });

        $("#inputEmpPhone").change(function () {
            var phoneValue = $('#inputEmpPhone').val();
            var phonePatch = { "op": "replace", "path": "/phoneNumber", "value": phoneValue };

            if (!patch.find(p => p === phonePatch))
                patch.push(phonePatch);
        });

        $("#inputEmpEmail").change(function () {
            var emailValue = $('#inputEmpEmail').val();
            var emailPatch = { "op": "replace", "path": "/email", "value": emailValue };

            if (!patch.find(p => p === emailPatch))
                patch.push(emailPatch);
        });

        var skillIds = [];
        $(".form-check input:checkbox:checked").map(function () {
            skillIds.push({ skillId: $(this).data('id') });
        });

        var skillsPatch = { "op": "replace", "path": "/employeeSkills", "value": skillIds };

        if (!patch.find(p => p === skillsPatch))
            patch.push(skillsPatch);
    };

    var getEmployeeSkillsPatchDocument = function (patch) {
        var skillIds = [];
        $(".form-check input:checkbox:checked").map(function () {
            skillIds.push({ skillId: $(this).data('id') });
        });

        var skillsPatch = { "op": "replace", "path": "/employeeSkills", "value": skillIds };

        if (!patch.find(p => p === skillsPatch))
            patch.push(skillsPatch);
    };

    var patchEmployee = function (id, patch, success, fail) {
        $.ajax({
            type: "PATCH",
            url: "http://localhost:5001/api/employees/" + id,
            data: JSON.stringify(patch),
            processData: false,
            contentType: 'application/json-patch+json'
        })
            .then(success, fail);
    };

    var deleteEmployeesCollection = function (employeesIds, success, fail) {
        $.ajax({
            url: "http://localhost:5001/api/employeecollections?ids=" + employeesIds,
            method: "DELETE"
        })
            .then(success)
            .fail(fail);
    };

    var deleteEmployee = function (id, success, fail) {
        $.ajax({
            type: "DELETE",
            url: "http://localhost:5001/api/employees/" + id
        })
            .then(success, fail);
    };

    return {
        getAllEmployeesDatatable: getAllEmployeesDatatable,
        getSelectedEmployeesIds: getSelectedEmployeesIds,
        postEmployee: postEmployee,
        getEmployeePatchDocument: getEmployeePatchDocument,
        getEmployeeSkillsPatchDocument: getEmployeeSkillsPatchDocument,
        patchEmployee: patchEmployee,
        deleteEmployeesCollection: deleteEmployeesCollection,
        deleteEmployee: deleteEmployee
    }
}();