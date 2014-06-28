(function (Operation) {

    Operation.Constructor = function (data) {
        var self = this;
        self.highNumber = ko.observable(data.HighNumber);
        self.lowNumber = ko.observable(data.LowNumber);
        self.result = ko.observable(data.Result);

        self.output = ko.observable(data.Output);
        self.type = ko.observable(data.Types);
        self.bootstrapClass = ko.observable();

        self.FormatedResult = ko.computed(function () {
            var result;
            var lowerNumberRow = self.result().substring(self.result().indexOf('$'), self.result().indexOf('?'));
            var lowerNumberDividend = lowerNumberRow.substring(lowerNumberRow.indexOf('$') + 1, lowerNumberRow.indexOf('|'));
            var lowerNumberQuotient = lowerNumberRow.substring(lowerNumberRow.indexOf('|') + 1, lowerNumberRow.indexOf('@'));
            var typeOfObjectUsedWithLowerNumber = lowerNumberRow.substring(lowerNumberRow.indexOf('@') + 1);

            var highNumberRow = self.result().substring(self.result().indexOf('?$') + 2);
            var highNumberDividend = highNumberRow.substring(highNumberRow.indexOf('$') + 1, highNumberRow.indexOf('|'));
            var highNumberQuotient = highNumberRow.substring(highNumberRow.indexOf('|') + 1, highNumberRow.indexOf('@'));
            var typeOfObjectUsedWithHighNumber = highNumberRow.substring(highNumberRow.indexOf('@') + 1);


            if (self.output() == "InvalidType" || self.output() == "ObjectValueIsZero" || self.output() == "LowerNumberIsHigherThanHighNumber") {
                self.bootstrapClass('class="well alert alert-danger');
                result = "&#60;" + self.type() + "&#62; " + " - " + "N/A";
            }
            else if (highNumberRow != "") {
                self.bootstrapClass('class="well alert alert-success');
                result = "Output: " + self.output() + "\n\nDivided: " + lowerNumberDividend + " by: " + self.lowNumber() + " - " + self.lowNumber() + " is the lower number input!\n\n<br>" + "Output: " + self.output() + "\nDivided: " + highNumberDividend + " by: " + self.highNumber() + " - " + self.highNumber() + " is the higher number input!";
            } else {
                self.bootstrapClass('class="well alert alert-success');
                result = "Output: " + self.output() + "\n\nDivided: " + lowerNumberDividend + " by: " + self.lowNumber() + " - " + self.lowNumber() + " is the lower number input!<br><br>";
            }
            return result;
        });

        return self;
    };

})(window.FOFB.Operation = window.FOFB.Operation || {});

//var event = function (eventDTO) {
//    var self = this;

//    self.eventId = ko.observable(eventDTO.EventId)
//    self.name = ko.observable(eventDTO.Name)
//    self.activityId = ko.observable(eventDTO.ActivityId)
//    self.activity = ko.observable(eventDTO.Activity)
//    self.active = ko.observable(eventDTO.Active)
//    self.messages = ko.observableArray(eventDTO.Messages)
//    self.users = ko.observableArray(eventDTO.Users)
//    self.plusones = ko.observableArray(eventDTO.PlusOnes)
//    self.isBeingViewed = ko.observable(false)

//    self.getFormatedTime = ko.computed(function () {
//        var activityTime = self.activity().Time
//        var hours = activityTime.substring(11, 13);
//        var minutes = activityTime.substring(14, 16);

//        hours = hours - 4;

//        var result = new Date();
//        result.setHours(hours)
//        result.setMinutes(minutes)
//        result.setSeconds(0)

//        return result.toLocaleTimeString().substring(0, 4) + " PM";
//    });

//    self.getTotalNumberOfPlayers = ko.computed(function () {
//        return self.users().length + self.plusones().length;
//    })

//    self.isCurrentUserAttending = ko.computed(function (event) {
//        for (var i = 0; i < self.users().length; i++) {
//            if (self.users()[i].Name == window.usersUsername.substring(6)) {
//                return true;
//            }
//        }
//        return false;
//    })

//    self.isCurrentUserNOTAttending = ko.computed(function (event) {
//        for (var i = 0; i < self.users().length; i++) {
//            if (self.users()[i].Name == window.usersUsername.substring(6)) {
//                return false;
//            }
//        }
//        return true;
//    });

//    self.currentProgress = function () {
//        return ((this.users().length + this.plusones().length) / this.activity().RequiredNumberOfPlayers1 * 100) + '%';
//    }

//    self.isThereAnEmail = function () {
//        if (window.currentSignedInUser.Email == "") {
//            return false;
//        }
//        return true;
//    }

//    return self;
//}
//return event;
