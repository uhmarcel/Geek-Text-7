
window.onload = function () {

    var ratingStars = document.getElementById('reviewRatingSpan').querySelectorAll("i");
    var ratingInput = document.getElementById('MainContent_createReviewRating');

    ratingStars[0].addEventListener("click", function () {
        ratingStarRemoveAll(ratingStars);
        ratingStars[0].classList.remove('far');
        ratingStars[0].classList.add('fa');
        ratingInput.value = "1";
    });

    ratingStars[1].addEventListener("click", function () {
        ratingStarRemoveAll(ratingStars);
        ratingStars[0].classList.remove('far');
        ratingStars[0].classList.add('fa');
        ratingStars[1].classList.remove('far');
        ratingStars[1].classList.add('fa');
        ratingInput.value = "2";
    });

    ratingStars[2].addEventListener("click", function () {
        ratingStarRemoveAll(ratingStars);
        ratingStars[0].classList.remove('far');
        ratingStars[0].classList.add('fa');
        ratingStars[1].classList.remove('far');
        ratingStars[1].classList.add('fa');
        ratingStars[2].classList.remove('far');
        ratingStars[2].classList.add('fa');
        ratingInput.value = "3";
    });

    ratingStars[3].addEventListener("click", function () {
        ratingStarRemoveAll(ratingStars);
        ratingStars[0].classList.remove('far');
        ratingStars[0].classList.add('fa');
        ratingStars[1].classList.remove('far');
        ratingStars[1].classList.add('fa');
        ratingStars[2].classList.remove('far');
        ratingStars[2].classList.add('fa');
        ratingStars[3].classList.remove('far');
        ratingStars[3].classList.add('fa');
        ratingInput.value = "4";
    });

    ratingStars[4].addEventListener("click", function () {
        ratingStarRemoveAll(ratingStars);
        ratingStars[0].classList.remove('far');
        ratingStars[0].classList.add('fa');
        ratingStars[1].classList.remove('far');
        ratingStars[1].classList.add('fa');
        ratingStars[2].classList.remove('far');
        ratingStars[2].classList.add('fa');
        ratingStars[3].classList.remove('far');
        ratingStars[3].classList.add('fa');
        ratingStars[4].classList.remove('far');
        ratingStars[4].classList.add('fa');
        ratingInput.value = "5";
    });
};

function ratingStarRemoveAll(ratingStars) {
    ratingStars[0].classList.remove('fa');
    ratingStars[0].classList.add('far');
    ratingStars[1].classList.remove('fa');
    ratingStars[1].classList.add('far');
    ratingStars[2].classList.remove('fa');
    ratingStars[2].classList.add('far');
    ratingStars[3].classList.remove('fa');
    ratingStars[3].classList.add('far');
    ratingStars[4].classList.remove('fa');
    ratingStars[4].classList.add('far');
}

