/// <reference path="libs/_references.js" />
/// <reference path="libs/sammy-0.7.4.js" />

(function () {
    var controller = controllers.get();
    var url = "http://localhost:50453/api/";
    var persister = persisters.get(url);
    var selector = "#main-content";

    var app = Sammy(selector, function () {

        this.get("#/", function () {
            if (persister.isUserLoggedIn()) {
                document.location.href = "#/posts";
            } else {
                controller.loadUI(selector);
            }
        });

        this.get("#/posts", function () {
            if (persister.isUserLoggedIn()) {
                controller.loadPostsUI(selector);
                persister.post.getAll(function (data) {
                    var templateHtml = $("#posts-template").html();
                    var rendered = Mustache.render(templateHtml, data);
                    $("#posts-holder").html(rendered);
                }, function (error) {
                    console.log(error);
                });
            } else {
                document.location.href = "#/";
            }
        });

        this.get("#/posts/:tags", function () {
            if (persister.isUserLoggedIn()) {
                persister.post.getPostsByTag(this.params["tags"], function (data) {
                    var templateHtml = $("#posts-by-tags").html();
                    var rendered = Mustache.render(templateHtml, data);
                    $("#posts-holder").html(rendered);
                }, function (err) {
                    console.log(err);
                });
            } else {
                document.location.href = "#/";
            }
        });

        this.get("#/post/:id", function (id) {
            if (persister.isUserLoggedIn()) {
                persister.post.getPostById(this.params["id"], function (data) {
                    var templateHtml = $("#post").html();
                    var rendered = Mustache.render(templateHtml, data);
                    $("#posts-holder").html(rendered);
                }, function (err) {
                    console.log(err);
                });
            } else {
                document.location.href = "#/";
            }
        });

        this.get("#/post/:id/comment", function (id) {
            if (persister.isUserLoggedIn()) {
                persister.post.comment(this.params["id"], function (data) {
                    var templateHtml = $("#comments").html();
                    var rendered = Mustache.render(templateHtml, data);
                    $("#posts-holder").html(rendered);
                }, function (err) {
                    console.log(err);
                });
            } else {
                document.location.href = "#/";
            }
        });

        this.get("#/logout", function () {
            var self = this;
            persister.user.logout(function () {
                $("#posts-holder").empty();
                document.location.href = "#/";
                controller.loadUI(selector);
            });
        });
    });

    app.run("#/");
}());

//this.get("#/item/:id", function (id) {
//    alert("In item with id: " + this.params["id"]);
//});

//// additional
//this.get("#/item/:id/marks", function (id) {
//    alert("Marks of item with id: " + this.params["id"]);
//});