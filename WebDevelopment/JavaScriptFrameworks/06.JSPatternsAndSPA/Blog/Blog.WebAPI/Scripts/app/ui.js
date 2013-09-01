/// <reference path="../libs/_references.js" />

var ui = (function () {

    function buildLoginForm() {
        var html =
            '<div id="login-form-holder">' +
                '<form>' +
                    '<div id="login-form">' +
                        '<label for="tb-login-username">Username: </label>' +
                        '<input type="text" id="tb-login-username"><br />' +
                        '<label for="tb-login-password">Password: </label>' +
                        '<input type="password" id="tb-login-password"><br />' +
                        '<a href="#/posts" id="btn-login" class="button">Login</a>' +
                    '</div>' +
                    '<div id="register-form" style="display: none">' +
                        '<label for="tb-register-username">Username: </label>' +
                        '<input type="text" id="tb-register-username"><br />' +
                        '<label for="tb-register-nickname">Nickname: </label>' +
                        '<input type="text" id="tb-register-nickname"><br />' +
                        '<label for="tb-register-password">Password: </label>' +
                        '<input type="password" id="tb-register-password"><br />' +
                        '<a href="#/posts" id="btn-register" class="button">Register</a>' +
                    '</div>' +
                    '<button id="btn-show-login" class="button selected">Go to Login</button>' +
                    '<button id="btn-show-register" class="button">Go to Register</button>' +
                '</form>' +
                '<div id="error-messages"></div>' +
            '</div>';
        return html;
    }

    function buildPostsUI(displayName) {
        var html = '<span id="user-nickname">' +
                'Hello, <strong>' + displayName +
        '<strong/></span>' +
        '<a href="#/logout" id="btn-logout" class="menu-btn">Logout</a>';
        return html;
    }   

    return {
        postsUI: buildPostsUI,
        loginForm: buildLoginForm
    }
}());