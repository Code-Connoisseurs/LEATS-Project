/*Slideshow code*/
var slideIndex = 0;
slideImages();

function slideImages() {
  var i;
  var x = document.getElementsByClassName("SlideShowImages");
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }
  slideIndex++;
  if (slideIndex > x.length) {slideIndex = 1}
  x[slideIndex-1].style.display = "block";
  setTimeout(slideImages(), 5000); // Change image every 5 seconds
}