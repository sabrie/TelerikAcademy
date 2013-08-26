define(function () {
        var people = [
      { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/Agassi_Federer_small.jpg" },
      { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "images/Nadal_small.jpg" },
      { id: 3, name: "Asya Grigorova", age: 20, avatarUrl: "images/Amelie_small.jpg" },
      { id: 4, name: "Ivanka Ivanova", age: 20, avatarUrl: "images/Sharapova_small.jpg" }
        ];

        var getPeople = function (success) {
            success(people);
        };

        return {
            getPeople: getPeople
        }
});