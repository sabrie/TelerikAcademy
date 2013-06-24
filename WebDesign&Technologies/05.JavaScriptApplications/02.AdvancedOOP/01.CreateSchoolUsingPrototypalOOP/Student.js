///*jshint asi: false*/

'use strict';

var Student = (function (Super) {
    Student.inherit(Super);

    function Student(firstName, lastName, age, grade) {
        Super.apply(this, arguments);

        this.grade = grade;
    }

    Student.prototype.extend({
        introduce: function () {
            return this.super.introduce.call(this) +
                '; Grade: ' + this.grade;
        }
    });

    return Student;
}(Person));