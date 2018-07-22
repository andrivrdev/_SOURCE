$(document).ready(function () {

    //Init Scrollmagic
    var controller = new ScrollMagic.Controller();

    //Build a scene
    var ourScene = new ScrollMagic.Scene({
        triggerElement: '#project01'
    })
        .setClassToggle('#project01', 'fade-in') //add class to project01


        /*=========STEP 01========*/
  /*Removed for STEP 02  .addIndicators()   */       /* <<<<<< Add indicators so we can see what is happening*/
        /*========================*/

        /*=========STEP 02========*/
        .addIndicators({                       
            name: 'fade screne',
            colorTrigger: 'black',                  /* <<<<<< Change indicators to be more descriptive and to have diffirent colors and indentation*/
            indent: 200,
            colorStart: '#75C695'
        })          
        /*========================*/
        .addTo(controller);
});