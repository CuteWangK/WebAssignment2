
document.addEventListener("DOMContentLoaded", function () {
    document.body.addEventListener('click', function (event) {
        if (event.target.classList.contains('game-image')) {
            var videoUrl = event.target.getAttribute('data-video-url');

            var videoPopup = document.createElement("div");
            videoPopup.id = "videoPopup"; 
            videoPopup.innerHTML = `
                <iframe width="1000" height="600" src="${videoUrl}" frameborder="0" allowfullscreen></iframe>
                <span id="closeBtn" onclick="closeVideo()">Close</span>
            `;

            document.body.appendChild(videoPopup);
        }
    });
});

function closeVideo() {
    var videoPopup = document.getElementById("videoPopup");
    videoPopup.parentNode.removeChild(videoPopup);
}