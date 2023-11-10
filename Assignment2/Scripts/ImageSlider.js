document.addEventListener("DOMContentLoaded", function () {
    var imageSlider = document.getElementById("imageSlider");
    var images = document.querySelectorAll("#imageSlider img");
    var currentIndex = 0;

    setInterval(function () {
        images[currentIndex].style.opacity = 0; 
        currentIndex = (currentIndex + 1) % images.length;
        images[currentIndex].style.opacity = 1; 
    }, 3000); 

    
    images[currentIndex].style.opacity = 1;
});