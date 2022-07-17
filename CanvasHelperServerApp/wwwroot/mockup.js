
(function ($) {
  "use strict"; // Start of use strict
  // Configure tooltips for collapsed side navigation
  $('.navbar-sidenav [data-toggle="tooltip"]').tooltip({
    template: '<div class="tooltip navbar-sidenav-tooltip" role="tooltip" style="pointer-events: none;"><div class="arrow"></div><div class="tooltip-inner"></div></div>'
  })
  // Toggle the side navigation
  $("#sidenavToggler").click(function (e) {
    e.preventDefault();
    $("body").toggleClass("sidenav-toggled");
    $(".navbar-sidenav .nav-link-collapse").addClass("collapsed");
    $(".navbar-sidenav .sidenav-second-level, .navbar-sidenav .sidenav-third-level").removeClass("show");
  });
  // Force the toggled class to be removed when a collapsible nav link is clicked
  $(".navbar-sidenav .nav-link-collapse").click(function (e) {
    e.preventDefault();
    $("body").removeClass("sidenav-toggled");
  });
  // Prevent the content wrapper from scrolling when the fixed side navigation hovered over
  $('body.fixed-nav .navbar-sidenav, body.fixed-nav .sidenav-toggler, body.fixed-nav .navbar-collapse').on('mousewheel DOMMouseScroll', function (e) {
    var e0 = e.originalEvent,
      delta = e0.wheelDelta || -e0.detail;
    this.scrollTop += (delta < 0 ? 1 : -1) * 30;
    e.preventDefault();
  });
  // Scroll to top button appear
  $(document).scroll(function () {
    var scrollDistance = $(this).scrollTop();
    if (scrollDistance > 100) {
      $('.scroll-to-top').fadeIn();
    } else {
      $('.scroll-to-top').fadeOut();
    }
  });
  // Configure tooltips globally
  $('[data-toggle="tooltip"]').tooltip()
  // Smooth scrolling using jQuery easing
  $(document).on('click', 'a.scroll-to-top', function (event) {
    var $anchor = $(this);
    $('html, body').stop().animate({
      scrollTop: ($($anchor.attr('href')).offset().top)
    }, 1000, 'easeInOutExpo');
    event.preventDefault();
  });
})(jQuery); // End of use strict

var selectedModules = [];

let assignments = '{ "Assignments" : [' +
  '{ "name":"CW 1" , "courseId":"700123", "courseName":"Trustworthy Computing" },' +
  '{ "name":"Final Exam" , "courseId":"700122", "courseName":"Maintaining Large Software Systems" },' +
  '{ "name":"CW 2" , "courseId":"700155", "courseName":"Component Based Architecture" },' +
  '{ "name":"Final Exam" , "courseId":"700122", "courseName":"Maintaining Large Software Systems" },' +
  '{ "name":"CW 2" , "courseId":"700525", "courseName":"Component Based Architecture" },' +
  '{ "name":"Final Exam" , "courseId":"700778", "courseName":"Maintaining Large Software Systems" },' +
  '{ "name":"CW 2" , "courseId":"700102", "courseName":"Component Based Architecture" },' +
  '{ "name":"Final Exam" , "courseId":"700977", "courseName":"Maintaining Large Software Systems" },' +
  '{ "name":"CW 2" , "courseId":"600755", "courseName":"Component Based Architecture" },' +
  '{ "name":"Final Exam" , "courseId":"700110", "courseName":"Maintaining Large Software Systems" } ]}';


 
function getRandomColor() {
  var letters = '0123456789ABCDEF';
  var color = '#';
  for (var i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)];
  }
  return color;
}

function closeSection() {
  if ($(".form-check-input:checked").length > 0) {
    $(".bg-primary").removeAttr("style");
    $(".bg-primary button").attr("data-toggle", "collapse");
  }
  else {
    $(".bg-primary").attr("style", "  background-color:#c1c5c9 !important");
    $(".bg-primary button").attr("data-toggle", "");
  }

}

$(document).on('change', '.form-check-input', function () {

  var item = $(this).attr('value');

  if (this.checked) {
    selectedModules.push(item);
    $("#headingOne h2 > .selected").append('<span class="rounded-pill ' + $(this).attr("value") + ' ">' + $(this).attr("value") + '</span>');
    $("#headingOne h2 > .selected > ." + $(this).attr("value")).css("background-color", getRandomColor());
    JSON.parse(assignments).Assignments.forEach(function (i) {
      if (assignments.includes(i.courseId) && item == i.courseId) {
        $("#collapseOne > .card-body > table > tbody").append('<tr><th scope="row">' + i.courseId + '</th><td>' + i.courseName + '</td><td>' + i.name + '</td><td><button type="button" style="margin-right: 5px;" class="btn btn-success"> <i class="fa fa-pencil-square-o" aria-hidden="true"></i></button><button type="button" class="btn btn-warning" style="margin-right:5px"> <i class="fa fa-trash-o" aria-hidden="true"></i></button><button type="button" class="btn btn-info"> <i class="fa fa-eye" aria-hidden="true"></i> </button></td></tr>')
      }
    })
  } else {
    $("#collapseOne > .card-body > table > tbody > tr:contains('" + item + "')").remove()
    $("#headingOne h2").remove('.' + $(this).attr("value") + '');
    $("#headingOne > h2 > .selected > span." + $(this).attr("value") + "").remove()
    selectedModules.splice($.inArray(item, selectedModules), 1);
    selectedModules.length == 0 ? closeSection() : null

  }
  closeSection()

});
var questionCount = 1

$(".addQuestion" ).on( "click", function() {
  questionCount++

  $( this ).parents('.modal-body').find(".questions").append(`
  <div class="input-group w-100" style="margin-bottom: 15px;">
             
  <input type="text" class="form-control" placeholder="Enter your question here..." aria-label="Enter your question here..." aria-describedby="basic-addon1"> <span class="input-group-text" action="removeQuestion">
    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x" viewBox="0 0 16 16">
<path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"></path>
</svg>
  </span>
</div>
`)
 
 });



 
 $( "body" ).on( "click", "span[action='removeQuestion']",function() {
  $( this ).parent().remove()
 });
