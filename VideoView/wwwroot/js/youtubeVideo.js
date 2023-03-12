var tag = document.createElement('script');

tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

//var player;
//function onYouTubeIframeAPIReady() {
//    player = new YT.Player('player', {
//        height: '390',
//        width: '640',
//        videoId: 'Zp37voNDY_0',
//        enablejsapi: 1,
//        playerVars: {
//            playsinline: 1,
//            rel: 0
//        }
//    });
//}

var player;
function initializePlayer(videoId) {
    if (player != null) {
        player.destroy();
    }
    player = new YT.Player("player", {
        height: '360',
        width: '640',
        videoId: videoId
    });
}

function getTime() {
    var currentTime = player.getCurrentTime();
    return currentTime;
}