///*jshint asi: false*/

'use strict';

var Student = (function () {
    function Student(firstName, lastName, grade) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.grade = grade;
    }

    return Student;
}());

Student.prototype = {
    getName: function () {
        return this.firstName + ' ' +
            this.lastName;
    },
    getGrade: function () {
        return this.grade;
    },
    introduce: function () {
        return 'Name: ' + this.getName() + '; Grade: ' + this.getGrade();
    }
};