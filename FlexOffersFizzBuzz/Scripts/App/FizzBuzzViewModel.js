(function (FizzBuzzViewModel) {

    FizzBuzzViewModel.listOfOperations = ko.observableArray();

    FizzBuzzViewModel.runFizzBuzz = function (typeOfObjectToUse, lowValue, highValue) {
        FizzBuzzViewModel.HitFizzBuzzSignalR(typeOfObjectToUse, lowValue, highValue);
    }

    FizzBuzzViewModel.HitFizzBuzz = function () {

        var typeToUse = $('#typeDropdown').val();
        var lowValue = $('#lowValueInput').val();
        var highValue = $('#highValueInput').val();

        window.fizzBuzzHub.server.post(typeToUse, lowValue, highValue);

        //var typeToUse = $('#typeDropdown').val();
        //var lowValue = $('#lowValueInput').val();
        //var highValue = $('#highValueInput').val();

        //$.ajax({
        //    url: "api/fizzbuzz/?typeOfObjectToUse=" + typeToUse + "&lowValue=" + lowValue + "&highValue=" + highValue,
        //    type: 'POST',
        //}).success(function (data) {
        //    for (var i = 0; i < data.ServiceCallResults.length; i++) {
        //        window.FOFB.FizzBuzzViewModel.listOfOperations.push(window.FOFB.Operation.Constructor(data.ServiceCallResults[i]));
        //    }

        //    $.growlUI('FizzBuzz Executed');
        //});
    }

    FizzBuzzViewModel.HitFizzBuzzSignalR = function (data) {

        for (var i = 0; i < data.ServiceCallResults.length; i++) {
            window.FOFB.FizzBuzzViewModel.listOfOperations.push(window.FOFB.Operation.Constructor(data.ServiceCallResults[i]));
        }

        $.growlUI('FizzBuzz Executed');
        //var typeToUse = typeOfObjectToUse;
        //var lowValue = lowValueToUse;
        //var highValue = highValueToUse;

        //$.ajax({
        //    url: "api/fizzbuzz/?typeOfObjectToUse=" + typeToUse + "&lowValue=" + lowValue + "&highValue=" + highValue,
        //    type: 'POST',
        //}).success(function (data) {
        //    for (var i = 0; i < data.ServiceCallResults.length; i++) {
        //        window.FOFB.FizzBuzzViewModel.listOfOperations.push(window.FOFB.Operation.Constructor(data.ServiceCallResults[i]));
        //    }

        //    $.growlUI('FizzBuzz Executed');
        //});
    }

    $.ajax({
        url: "api/fizzbuzz/",
        type: 'GET',
    }).done(function (data) {
        for (var i = 0; i < data.ServiceCallResults.length; i++) {
            window.FOFB.FizzBuzzViewModel.listOfOperations.push(window.FOFB.Operation.Constructor(data.ServiceCallResults[i]));
        }

        setTimeout($.unblockUI, 500);
    });
})(window.FOFB.FizzBuzzViewModel = window.FOFB.FizzBuzzViewModel || {});