var LandVehicle = (function() {
    inherit(LandVehicle, Vehicle);

    function LandVehicle(wheel1, wheel2, wheel3, wheel4) {
        var wheels = [wheel1, wheel2, wheel3, wheel4];

        Vehicle.call(this, wheels);
    }

    return LandVehicle;
}());
