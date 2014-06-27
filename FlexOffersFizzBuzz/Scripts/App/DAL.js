(function (DAL) {
    // private properties
    var foo = "foo",
        bar = "bar";

    // public methods and properties
    DAL.foobar = "foobar";
    DAL.sayHello = function () {
        speak("hello world");
    };

    // private method
    function speak(msg) {
        console.log("You said: " + msg);
    };

    // check to evaluate whether 'DAL' exists in the 
    // global DAL - if not, assign window.DAL an 
    // object literal
})(window.FOFB.DAL = window.FOFB.DAL || {});