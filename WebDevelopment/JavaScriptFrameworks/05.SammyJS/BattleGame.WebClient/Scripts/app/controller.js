﻿/// <reference path="../libs/class.js" />
/// <reference path="ui.js" />
/// <reference path="../libs/jquery-2.0.2.js" />

define(["class", "jquery", "ui", "persister"], function (Class, $, ui, persisters) {
var controllers = (function () {

    var updateTimer = null;

    var rootUrl = "http://localhost:22954/api/";

    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(rootUrl);
        },
        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
            }
            else {
                this.loadLoginFormUI(selector);
            }
            this.attachUIEventHandlers(selector);
        },
        loadLoginFormUI: function (selector) {
            var loginFormHtml = ui.loginForm()
            $(selector).html(loginFormHtml);
        },
        loadGameUI: function (selector) {
            var self = this;
            var gameUIHtml =
				ui.gameUI(this.persister.nickname());
            $(selector).html(gameUIHtml);

            this.updateUI(selector);

            updateTimer = setInterval(function () {
                self.updateUI(selector);
            }, 15000);
        },
        loadGame: function (selector, gameId) {
            this.persister.game.field(gameId, function (gameState) {
                var gameHtml = ui.gameState(gameState);
                $(selector + " #game-holder").html(gameHtml)
            });
        },
        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;
            console.log(self);

            wrapper.on("click", "#btn-show-login", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#login-form").show();
                wrapper.find("#register-form").hide();
            });
            wrapper.on("click", "#btn-show-register", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#register-form").show();
                wrapper.find("#login-form").hide();
            });

            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                }

                self.persister.user.login(user, function () {
                    self.loadGameUI(selector);
                }, function (err) {
                    wrapper.find("#error-messages").text(err.responseJSON.Message);
                });
                return false;
            });
            wrapper.on("click", "#btn-register", function () {
                var user = {
                    username: $(selector).find("#tb-register-username").val(),
                    nickname: $(selector).find("#tb-register-nickname").val(),
                    password: $(selector + " #tb-register-password").val()
                }
                self.persister.user.register(user, function () {
                    self.loadGameUI(selector);
                }, function (err) {
                    wrapper.find("#error-messages").text(err.responseJSON.Message);
                });
                return false;
            });
            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout(function () {
                    self.loadLoginFormUI(selector);
                    clearInterval(updateTimer);
                }, function (err) {
                });
            });

            wrapper.on("click", "#open-games-container a", function () {
                $("#game-join-inputs").remove();
                var html =
					'<div id="game-join-inputs">' +
						'<button id="btn-join-game">Join</button>' +
					'</div>';
                $(this).after(html);
            });
            wrapper.on("click", "#btn-join-game", function () {
                var game = {
                    id: $(this).parents("li").first().data("game-id")
                };

                var password = $("#tb-game-pass").val();

                if (password) {
                    game.password = password;
                }
                self.persister.game.join(game, function () {
                    self.loadGameUI(selector);
                    wrapper.find("#game-holder").html("Game is joined");
                }, function(err){
                    wrapper.find("#game-join-error-messages").text(err.responseJSON.Message);
                });
            });
            wrapper.on("click", "#btn-create-game", function () {
                var game = {
                    title: $("#tb-create-title").val(),
                }
                var password = $("#tb-create-pass").val();
                if (password) {
                    game.password = password;
                }
                self.persister.game.create(game, function () {
                    self.loadGameUI(selector);
                    wrapper.find("#game-holder").html("Game is created");
                }, function(err){
                    wrapper.find("#game-create-error-messages").text(err.responseJSON.Message);
                });
            });

            wrapper.on("click", "#active-games-container li.game-status-full a.btn-active-game", function () {
                var gameCreator = $(this).parent().data("creator");
                var myNickname = self.persister.nickname();
                if (gameCreator == myNickname) {
                    $("#btn-game-start").remove();
                    var html =
						'<br /><button href="#" id="btn-game-start">' +
							'Start' +
						'</button>';
                    $(this).parent().append(html);
                }
            });

            wrapper.on("click", "#btn-game-start", function () {
                var parent = $(this).parent();

                var gameId = parent.data("game-id");
                self.persister.game.start(gameId, function () {
                    wrapper.find("#game-holder").html("Game is started");
                },
				function (err) {
				    alert(JSON.stringify(err));
				});

                return false;
            });

            wrapper.on("click", ".active-games .in-progress", function () {
                self.loadGame(selector, $(this).parent().data("game-id"));
            });
        },
        updateUI: function (selector) {
            this.persister.game.open(function (games) {
                var list = ui.openGamesList(games);
                $(selector + " #open-games")
					.html(list);
            });
            this.persister.game.myActive(function (games) {
                var list = ui.activeGamesList(games);
                $(selector + " #active-games")
					.html(list);
            });
            this.persister.message.all(function (msg) {
                var msgList = ui.messagesList(msg);
                $(selector + " #messages-holder").html(msgList);
            });
        }
    });

    return {
        get: function () {
            return new Controller();
        }
    }


}());

    return controllers;

});

//$(function () {
//    var controller = controllers.get();
//    controller.loadUI("#main-content");
//});
