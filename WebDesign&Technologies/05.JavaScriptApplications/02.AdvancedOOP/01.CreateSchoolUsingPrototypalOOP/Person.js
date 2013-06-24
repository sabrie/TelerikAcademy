///*jshint asi: false*/

'use strict';

Function.prototype.inherit = function (Parent) {
    this.prototype = Object.create(Parent.prototype);
    this.prototype.super = Parent.prototype;
    this.prototype.constructor = this;
};

Object.prototype.extend = function (obj) {
    for (var prop in obj) {
        this[prop] = obj[prop];
    }
};

var Person = (function () {
    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    Person.prototype.extend({
        getName: function(){
            return  this.firstName + ' ' +
                this.lastName;
        },
        getAge: function(){
            return this.age;
        },
        introduce: function () {
            return 'Name: ' + this.getName() + '; Age: ' + this.age;
        }
    });

    return Person;
}());