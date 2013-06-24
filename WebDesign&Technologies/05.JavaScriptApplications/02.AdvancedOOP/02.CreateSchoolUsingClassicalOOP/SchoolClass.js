///*jshint asi: false*/

'use strict';

var SchoolClass = Class.create({
    init: function Class(name, studentsCapacity, students, formTeacher) {
        this.name = name;
        this.studentsCapacity = studentsCapacity;
        this.students = [];
        this.formTeacher = formTeacher;

        for (var i = 0; i < students.length; i++) {
            this.students.push(students[i]);
        }
    },

    addStudent: function (student) {
        if (this.students.length >= this.studentsCapacity) {
            throw new Error("Class is full.");
        }

        this.students.push(student);
    },

    print: function () {
        console.log("Class name: " + this.name +
            "; Students capacity: " + this.studentsCapacity +
            "; Form-teacher: " + this.formTeacher.getName());

        if (this.students.length !== 0) {
            console.log("Students: ");

            this.students.forEach(function (student) {
                console.log(student.introduce());
            })
        }
        else {
            console.log("There are no students in this class");
        }
    }
});