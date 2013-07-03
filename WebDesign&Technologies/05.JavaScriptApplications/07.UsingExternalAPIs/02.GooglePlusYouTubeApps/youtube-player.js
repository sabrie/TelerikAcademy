var player;
function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '315', //must be bigger than 200px
        width: '560', //must be bigger than 200px
        videoId: 'GeL3XkhPyTM', // the ID of the first video - http://www.youtube.com/watch?v=GeL3XkhPyTM
        events: {
            'onReady': onPlayerReady,
        }
    });

    console.log(player);
}

function onPlayerReady(event) {
    event.target.pauseVideo();
}

document.getElementById('single-video').addEventListener('click', function () {
    var video = document.getElementById('load-video').value;

    //player.cueVideoById(video, 0, "large");
    player.loadVideoById(video, 0, "large");
}, false);

document.getElementById('pause').addEventListener('click', function () {
    player.pauseVideo();
}, false);

document.getElementById('play').addEventListener('click', function () {
    player.playVideo();
}, false);

document.getElementById('mute').addEventListener('click', function () {
    player.mute();
}, false);

document.getElementById('unmute').addEventListener('click', function () {
    player.unMute();
}, false);

document.getElementById('load-playlist').addEventListener('click', function () {
    var videoPlaylist = document.getElementById('playlist').value.split(',');

    //player.cuePlaylist(videoPlaylist, 0, 0, "large");
    player.loadPlaylist(videoPlaylist, 0, 0, "large");
}, false);

document.getElementById('previous').addEventListener('click', function () {
    player.previousVideo();
}, false);

document.getElementById('next').addEventListener('click', function () {
    player.nextVideo();
}, false);