var AmphibiousVehicle = (function() {
    inherit(AmphibiousVehicle, Vehicle);

    mixin(AmphibiousVehicle, LandVehicle);
    mixin(AmphibiousVehicle, WaterVehicle);

    function AmphibiousVehicle(wheels, propellers) {
        Vehicle.call(this, wheels);

        this.wheels = wheels;
        this.propellers = propellers;
    }

    AmphibiousVehicle.prototype.switchMode = function() {
        if (this.propulsionUnits === this.wheels) {
            this.propulsionUnits = this.propellers;
        } else {
            this.propulsionUnits = this.wheels;
        }
    };

    return AmphibiousVehicle;
}());
