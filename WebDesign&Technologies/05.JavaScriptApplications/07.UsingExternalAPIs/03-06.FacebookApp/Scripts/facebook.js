/// <reference path="Scripts/jquery-2.0.2.js" />

window.fbAsyncInit = function () {
    FB.init({
        appId: '468633536558792',
        channelUrl: 'http://localhost:20511/channel.html',
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });

    FB.login(function (response) {
        if (response.authResponse) {
            getProfileInfo();
            getFriends();
        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: 'read_friendlists,user_photos,user_birthday' });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));


function getProfileInfo() {
    FB.api('/me', function (response) {
        var holder = $("#profile-info");
        var name = response.name;
        var birthday = response.birthday;
        var location = response.location.name;
        var url = "https://graph.facebook.com/" + response.id + "/picture";
        holder.append("<img src =" + url + "/>");
        holder.append("<p> My name: " + name + "</p>");
        holder.append("<p> My birthday: " + birthday + "</p>");
        holder.append("<p> Location: " + location + "</p>");
    });
    $("#log").css("display", "none");
}

function getFriends() {
    FB.api('/me/friends', function (response) {
        var friendsHolder = $('#friends-holder');
        friendsHolder.append("<p>Here are my Facebook friends</p>");
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture';
            var friendName = response.data[i].name;
            friendsHolder.append("<img class='images' src=" + friendPictureUrl + " title=" + friendName + "/>");
        }
    });
}

function fbLogout() {
    FB.logout(function (response) {
        window.location.reload();
    });
}

$("#logout").click(function () { fbLogout() });