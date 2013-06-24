///*jshint asi: false*/

'use strict';

var Teacher = Class.create({
    init: function (fname, lname, age, specialty) {
        this._super.init(fname, lname, age);
        this.specialty = specialty;
    },

    getName: function(){
        return this.fname + " " + this.lname;
    },

    introduce: function () {
        return this._super.introduce() + "; Specialty: " + this.specialty;
    }
});

Teacher.inherit(Person);


// ======================================================================

//function Teacher(fname, lname, age, specialty) {
//    Person.apply(this, arguments);

//    this.specialty = specialty;
    
//};

//Teacher.prototype = {
//    introduce: function () {
//        return "Name: " + this.fname + " " + this.lname +
//            ", Age: " + this.age + ", Specialty: " + this.specialty;
//    }
//};