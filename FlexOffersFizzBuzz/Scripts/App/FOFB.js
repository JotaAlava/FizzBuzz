(function (FOFB) {
    // private properties
    var foo = "foo",
        bar = "bar";

    // public methods and properties
    FOFB.foobar = "foobar";
    FOFB.sayHello = function () {
        speak("hello world");
    };

    // private method
    function speak(msg) {
        console.log("You said: " + msg);
    };

    // check to evaluate whether 'FOFB' exists in the 
    // global FOFB - if not, assign window.FOFB an 
    // object literal
})(window.FOFB = window.FOFB || {});