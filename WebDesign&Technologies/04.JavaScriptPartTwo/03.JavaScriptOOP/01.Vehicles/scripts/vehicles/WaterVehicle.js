var WaterVehicle = (function() {
    inherit(WaterVehicle, Vehicle);

    function WaterVehicle(propellers) {
        Vehicle.call(this, propellers);
    }

    WaterVehicle.prototype.switchSpinDirection = function() {
        this.propulsionUnits.forEach(function(propeller) {
            propeller.spinDirection = !propeller.spinDirection;
        });
    };

    return WaterVehicle;
}());
