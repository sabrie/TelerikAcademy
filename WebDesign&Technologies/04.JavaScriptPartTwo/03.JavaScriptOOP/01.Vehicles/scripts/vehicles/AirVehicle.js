var AirVehicle = (function() {
    inherit(AirVehicle, Vehicle);

    function AirVehicle(propellingNozzle) {
        var propellers = [propellingNozzle];

        Vehicle.call(this, propellers);
    }

    AirVehicle.prototype.switchAfterburner = function() {
        this.propulsionUnits.forEach(function(propellingNozzle) {
            propellingNozzle.afterBurner = !propellingNozzle.afterBurner;
        });
    };

    return AirVehicle;
}());
