//Flowsheet model

function Flowsheet(data) {
    this.id = data.flowsheetID;
    this.customField = data.customField;
    this.durationHours = data.durationHours;
    this.startHour = data.startHour;
    this.date = data.date;
    this.medicID = data.medicID;
    this.doctor = data.doctor;
}

function Medic(data) {
    console.log(data);
    this.id = data.medicID;
    this.nameFull = data.nameFull;
}

function MedicListViewModel() {
    var self = this;
    self.medics = ko.observableArray([]);
    $.getJSON("/api/medicsweb", function (allData) {
        var mappedTasks = $.map(allData.$values, function (item) {
            return new Medic(item)
        });
        self.medics(mappedTasks);
    });
}

ko.applyBindings(new MedicListViewModel());
