/// <reference path="libs/cryptoJS.js" />
/// <reference path="libs/jquery-2.0.2.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="app/controller.js" />
/// <reference path="app/persister.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/class.js" />
/// <reference path="app/ui.js" />
/// <reference path="libs/rsvp.min.js" />
/// <reference path="libs/mustache.js" />

(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-2.0.2",
            "sammy": "libs/sammy-0.7.4",
            "rsvp": "libs/rsvp.min",
            "controller": "app/controller",
            "persister": "app/persister",
            "class": "libs/class",
            "http-requester": "libs/http-requester",
            "ui": "app/ui",
            "cryptoJS": "libs/cryptoJS",
            "mustache": "libs/mustache"
        }
    });

    require(["jquery", "sammy", "controller", "persister", "ui", "mustache"], function ($, sammy, controllers, persisters, ui, mustache) {

        var controller = controllers.get();
        var url = "http://localhost:22954/api/";
        var persister = persisters.get(url);
        var selector = "#main-content";

        var app = sammy(selector, function () {

            this.get("#/", function () {
                if (persister.isUserLoggedIn()) {
                    debugger;
                    document.location.href = "#/create-game";
                } else {
                    controller.loadUI(selector);
                }
            });

            this.get("#/create-game", function () {

                if (controller.persister.isUserLoggedIn()) {
                    controller.loadGameUI(selector);
                    var templateHtml = $("#create-game-template").html();
                    document.getElementById("game-holder").innerHTML = templateHtml;

                } else {
                    document.location.href = "#/";
                }
            });

            this.get("#/my-games", function () {

                var myGamesTemplate = $("#my-games-template").html();
                var myGames = persister.game.myActive(function (data) {
                    var rendered = mustache.render(myGamesTemplate, data);
                    document.getElementById("game-holder").innerHTML = rendered;
                }, function (error) {
                    console.log(error);
                });
            });

            this.get("#/open-games", function () {

                var openGamesTemplate = $("#open-games-template").html();
                var games = persister.game.open(function (data) {
                    var rendered = mustache.render(openGamesTemplate, data);
                    document.getElementById("game-holder").innerHTML = rendered;
                }, function (error) {
                    console.log(error);
                });
            });

            this.get("#/logout", function () {
                var self = this;
                persister.user.logout(function () {
                    //self.redirect("#/");
                    $("#game-holder").empty();
                    document.location.href = "#/";
                    controller.loadUI(selector);
                }); 
            });
        });

        app.run("#/");
    });
}());