///*jshint asi: false*/

'use strict';

var School = Class.create({
    init: function School(name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = [];

        for (var i = 0; i < classes.length; i++) {
            this.classes.push(classes[i]);
        }
    },
    
    addClass: function (schoolClass) {
        this.classes.push(schoolClass);
    },

    print: function () {
        console.log("School name: " + this.name);
        console.log("Town: " + this.town);

        if (this.classes.length !== 0) {
            console.log("Classes: ");

            this.classes.forEach(function (schoolClass) {
                console.log(schoolClass.name);
            });
        }
        else {
            console.log("There are no classes in this school");
        }
    }
});