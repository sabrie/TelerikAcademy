///*jshint asi: false*/

'use strict';

var Teacher = (function (Super) {
    Teacher.inherit(Super);

    function Teacher(firstName, lastName, age, specialty) {
        Super.apply(this, arguments);

        this.specialty = specialty;
    }

    Teacher.prototype.extend({
        introduce: function () {
            return this.super.introduce.call(this) +
                '; Specialty: ' + this.specialty;
        },
    });

    return Teacher;
}(Person));