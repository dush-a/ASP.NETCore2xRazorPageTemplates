function onYouTubeIframeAPIReady() {
    var player;
    player = new YT.Player('YouTubeBackgroundVideoPlayer', {
        videoId: 'BE67EwLGcs0', // YouTube Video ID //https://www.youtube.com/watch?v=BE67EwLGcs0
        width: 1280,               // Player width (in px)
        height: 520,              // Player height (in px)
        //startSeconds: 1,
        //endSeconds: 36,
        playerVars: {
            playlist: '{$loadYouTubeVideoID}',
            //start: 5,
            end: 36,
            autoplay: 1,        // Auto-play the video on load
            autohide: 1,
            disablekb: 1,
            controls: 0,        // Hide pause/play buttons in player
            showinfo: 0,        // Hide the video title
            modestbranding: 1,  // Hide the Youtube Logo
            loop: 1,            // Run the video in a loop
            fs: 0,              // Hide the full screen button
            autohide: 0,         // Hide video controls when playing
            rel: 0,
            enablejsapi: 1,
            iv_load_policy: 3
            //theme: light,
            //color: white
        },
        events: {
            onReady: function (e) {
                e.target.mute();
                e.target.setPlaybackQuality('hd1080');
            },
            onStateChange: function (e) {
                if (e && e.data === 1) {
                    var videoHolder = document.getElementById('home-banner-box');
                    if (videoHolder && videoHolder.id) {
                        videoHolder.classList.remove('loading');
                    }
                } else if (e && e.data === 0) {
                    e.target.playVideo()
                }
            }
        }
    });
}