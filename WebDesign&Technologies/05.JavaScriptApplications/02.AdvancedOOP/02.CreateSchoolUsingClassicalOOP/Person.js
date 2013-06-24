///*jshint asi: false*/

'use strict';

var Person = Class.create({
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    },
    getName: function(){
        return "Name: " + this.fname + " " + this.lname;
    },
    getAge: function(){
        return "; Age: " + this.age;
    },
    introduce: function () {
        return this.getName() + this.getAge();
    }
});


// ========================================================

//function Person(fname, lname, age) {
//    this.fname = fname;
//    this.lname = lname;
//    this.age = age;
//};

//Person.prototype = {
//    introduce: function () {
//        return "Name: " + this.fname + " " + this.lname +
//            "; Age: " + this.age;
//    }
//};

//Student.prototype = new Person();
//Student.prototype.constructor = Student;

//Teacher.prototype = new Person();
//Teacher.prototype.constructor = Teacher;





