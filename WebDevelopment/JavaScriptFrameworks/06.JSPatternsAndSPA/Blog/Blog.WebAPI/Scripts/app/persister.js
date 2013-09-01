/// <reference path="../libs/_references.js" />

var persisters = (function () {
    var displayName = localStorage.getItem("displayName");
    var sessionKey = localStorage.getItem("sessionKey");
    function saveUserData(userData) {
        localStorage.setItem("displayName", userData.displayName);
        localStorage.setItem("sessionKey", userData.sessionKey);
        displayName = userData.displayName;
        sessionKey = userData.sessionKey;
    }
    function clearUserData() {
        localStorage.removeItem("displayName");
        localStorage.removeItem("sessionKey");
        displayName = null;
        sessionKey = null;
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.user = new UserPersister(rootUrl + 'users/');
            this.post = new PostPersister(rootUrl + 'posts');
        },
        isUserLoggedIn: function () {
            var isLoggedIn = displayName != null && sessionKey != null;
            return isLoggedIn;
        },
        displayName: function () {
            return displayName;
        }
    });

    var UserPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },
        register: function (user, success, error) {
            var url = this.serviceUrl + 'register',
                userData = {
                    username: user.username,
                    displayName: user.displayName,
                    authCode: CryptoJS.SHA1(user.password).toString()
                };

            return httpRequester.postJSON(url, userData, function (data) {
                saveUserData(data);
                return data;
            }, error);
        },
        login: function (user, success, error) {
            var url = this.serviceUrl + 'login',
                userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.password).toString()
                };

            return httpRequester.postJSON(url, userData, function (data) {
                saveUserData(data);
                return data;
            }, error);
        },
        logout: function (success, error) {
            var url = this.serviceUrl + 'logout?sessionKey=' + sessionKey;

            return httpRequester.putJSON(url, "", function (data) {
                clearUserData();
                //success(data);
            }, error)
        },
        currentUser: function () {
            return displayName;
        }
    });

    var PostPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },

        //GET api/posts?sessionKey=...
        getAll: function (success, error) {
            var url = this.serviceUrl + '/all?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url, success, error);
        },

        // GET api/posts/{id}?sessionKey=...
        getPostById: function (postId, success, error) {
            var url = this.serviceUrl + '/' + postId + '?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url, success, error);
        },

        // GET api/posts/{tags}
        getPostsByTag: function (tags, success, error) {
            var url = this.serviceUrl + "?tags=" + tags + "&sessionKey=" + sessionKey;
            httpRequester.getJson(url, success, error);
        },

        comment: function (postId, success, error) {
            var url = this.serviceUrl + '/' + postId + '/comment?sessionKey=' + sessionKey;
            httpRequester.putJSON(url, postId, success, error);
        },
    });

    var TagPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },

        getAll: function (success, error) {
            var url = this.serviceUrl + '?sessionKey=' + sessionKey;
            var tags = httpRequester.getJSON(url, success, error);
            return tags;
        }
    });

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    };

}());