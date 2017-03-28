// site.js


// Function as expression: This ensures that the variables are not global, and the code within the
//paranthesis are executed. 
//(function () {


    /* Examples with jQuery */
    //document.getElementById == $
    //var ele = document.getElementById("username");
    //ele.innerHTML = "Trond";
    //main.onmouseenter = function () {
    //    main.style.backgroundColor = "#888";
    //};
      //main.onmouseleave = function () {
    //    main.style.backgroundColor = "";

    //};
     //var main = document.getElementById("main");


    /*Example with jQuery*/

    //var ele = $("#username");
    //ele.text = "Trond";

    //var main = $("#main");
    
    //main.on("mouseenter", function () {
    //    main.style.backgroundColor = "#888";
    //});

    //main.on("mouseleave",  function () {
    //    main.style.backgroundColor = "";

    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text() );
    //});




//    var $icon = $("#sidebarToggle i.fa");
//    //Displays the sidebar
//    var $sidebarAndWrapper = $("#sidebar, #wrapper");
   

//    $("#sidebarToggle").on("click", function () {

//        $sidebarAndWrapper.toggleClass("hide-sidebar");
//        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
       
//            $icon.removeClass("fa-angle-left");
//            $icon.addClass("fa-angle-right");
          
//        } else {
          
//            $icon.addClass("fa-angle-left");
//            $icon.removeClass("fa-angle-right");
          
//        }
//    });

   
//})();
//// () executes the code of the ananomouse function
 


// site.js

(function () {
    var $sidebarAndWrapper = $("#sidebar,#wrapper"); // Referencing by element IDs
    // Find the element i with class 'fa' within the element with class 'sidebarToggle'
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        }
    });
})();