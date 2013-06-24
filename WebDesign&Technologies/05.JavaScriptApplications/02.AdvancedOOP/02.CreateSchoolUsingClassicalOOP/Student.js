///*jshint asi: false*/

'use strict';

var Student = Class.create({
    init: function (fname, lname, age, grade) {
        this._super.init(fname, lname, age);
        this.grade = grade;
    },
    getName: function(){
        return this._super.getName();
    },
    getAge: function(){
        return this._super.getAge();
    },
    getGrade: function(){
        return "; Grade: " + this.grade;
    },
    introduce: function () {
        return this.getName() + this.getAge() + this.getGrade();
    }
});

Student.inherit(Person);

// ===========================================

//function Student(fname, lname, age, grade) {
//    Person.apply(this, arguments);
//    this.grade = grade;
//};

//Student.prototype = {
//    introduce: function () {
//       return "Name: " + this.fname + " " + this.lname +
//            "; Age: " + this.age + "; Grade: " + this.grade;
//    }
//};