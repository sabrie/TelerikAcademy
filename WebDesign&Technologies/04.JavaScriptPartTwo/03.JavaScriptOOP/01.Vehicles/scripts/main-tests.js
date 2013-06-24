console.group('Propulsion Units');
(function () {
    console.group('Wheel');
    (function () {
        var propulsionUnit = new Wheel(10);

        console.log(propulsionUnit.produceAcceleration());
    }());
    console.groupEnd();

    console.group('Propelling Nozzle');
    (function () {
        var propulsionUnit = new PropellingNozzle(10);

        console.log('Switch off:', propulsionUnit.produceAcceleration());

        propulsionUnit.switchAfterburner();
        console.log('Switch on:', propulsionUnit.produceAcceleration());
    }());
    console.groupEnd();

    console.group('Propeller');
    (function () {
        var propulsionUnit = new Propeller(10);

        console.log('Clockwise', propulsionUnit.produceAcceleration());

        propulsionUnit.changeSpinDirection();
        console.log('Counter-clockwise:', propulsionUnit.produceAcceleration());
    }());
    console.groupEnd();
}());
console.groupEnd();

console.group('Vehicles');
(function () {
    console.group('Land Vehicle');
    (function () {
        var vehicle = (function () {
            var propulsionUnit1 = new Wheel(10);
            var propulsionUnit2 = new Wheel(10);
            var propulsionUnit3 = new Wheel(10);
            var propulsionUnit4 = new Wheel(10);

            return new LandVehicle(propulsionUnit1, propulsionUnit2, propulsionUnit3, propulsionUnit4);
        }());

        console.log(vehicle.speed, vehicle.accelerate());
    }());
    console.groupEnd();

    console.group('Air Vehicle');
    (function () {
        var vehicle = (function () {
            var propulsionUnit = new PropellingNozzle(10);

            return new AirVehicle(propulsionUnit);
        }());

        console.log('Switch off:', vehicle.speed, vehicle.accelerate());

        vehicle.switchAfterburner();

        console.log('Switch on:', vehicle.speed, vehicle.accelerate());
    }());
    console.groupEnd();

    console.group('Water Vehicle');
    (function () {
        var vehicle = (function () {
            var propulsionUnits = [
                new Propeller(10),
                new Propeller(10)
            ];

            return new WaterVehicle(propulsionUnits);
        }());

        console.log('Clockwise:', vehicle.speed, vehicle.accelerate());

        vehicle.switchSpinDirection();

        console.log('Counterclockwise:', vehicle.speed, vehicle.accelerate());
    }());
    console.groupEnd();

    console.group('Amphibious Vehicle');
    (function () {
        var vehicle = (function () {
            var wheels = [
                new Wheel(10),
                new Wheel(10),
                new Wheel(10),
                new Wheel(10)
            ];

            var propellers = [
                new Propeller(10),
                new Propeller(10)
            ];

            return new AmphibiousVehicle(wheels, propellers);
        }());

        console.log('Land mode:', vehicle.speed, vehicle.accelerate());

        vehicle.switchMode();
        console.log('Water mode - Clockwise:', vehicle.speed, vehicle.accelerate());

        vehicle.switchSpinDirection();
        console.log('Water mode - Counterclockwise:', vehicle.speed, vehicle.accelerate());

        vehicle.switchMode();
        console.log('Land mode:', vehicle.speed, vehicle.accelerate());
    }());
    console.groupEnd();
}());
console.groupEnd();
