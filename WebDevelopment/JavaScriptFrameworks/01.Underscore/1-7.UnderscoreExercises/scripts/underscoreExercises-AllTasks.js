/// <reference path="underscore.js" />
/// <reference path="class.js" />

var underscoreExercises = (function () {

    var findStudentsByFname = function (students) {

        var result =
            _.chain(students)
                .filter(function (student) {
                    return student.fname < student.lname;
                })
                    .sortBy(function (st) {
                        //sort by full name
                        return st.toString();
                    })
                        // in descending order
                        .reverse()
                            .each(function (st) {
                                console.log(st.toString());
                            });
    };

    var studentsByAgeInRange = function (students, min, max) {

        var result =
            _.chain(students)
                .filter(function (st) {
                    return st.age >= min && st.age <= max;
                })
                    .each(function (s) {
                        console.log(s.toString());
                    })
    };

    var studentWithHighestMarks = function (students) {

        var result =
            _.chain(students)
                .sortBy(students.marks)
                    .first()
                        .value();

        console.log(result.toString());
    };

    var groupAnimalsBySpecies = function (animals) {

        var result =
            _.chain(animals)
                .sortBy("legsNumber")
                    .groupBy("species")
                        .each(function (a) {
                                console.log(a.toString());
                            })
    };

    var sumAllAnimalsLegsNumber = function (animals) {
        var allLegs = _.reduce(animals, function (memo, anim) {
            return memo + anim.legsNumber
        }, 0);

        console.log(allLegs);
    };

    var findMostCommonAuthor = function (books) {

        var mostFamousBooks = _.groupBy(books, 'author');
        mostFamousBooks = _.sortBy(mostFamousBooks, function (g) { return -g.length });
        console.log(_.first(mostFamousBooks)[0].author);
    };

    var findMostCommonFirstName = function (people) {

        var mostFamousName = _.groupBy(people, "fname");
        mostFamousName = _.sortBy(mostFamousName, function (g) { return -g.length });
        console.log(_.first(mostFamousName)[0].fname);
    };

    var findMostCommonLastName = function (people) {

        var mostFamousName = _.groupBy(people, "lname");
        mostFamousName = _.sortBy(mostFamousName, function (g) { return -g.length });
        console.log(_.first(mostFamousName)[0].lname);
    };

        return {
            findStudentsByFname: findStudentsByFname,
            studentsByAgeInRange: studentsByAgeInRange,
            studentWithHighestMarks: studentWithHighestMarks,
            groupAnimalsBySpecies: groupAnimalsBySpecies,
            sumAllAnimalsLegsNumber: sumAllAnimalsLegsNumber,
            findMostCommonAuthor: findMostCommonAuthor,
            findMostCommonFirstName: findMostCommonFirstName,
            findMostCommonLastName: findMostCommonLastName
        };
})();