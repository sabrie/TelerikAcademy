var Vehicle = (function() {
    function Vehicle(propulsionUnits) {
        this.speed = 0;

        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function() {
        var self = this;

        this.propulsionUnits.forEach(function(propeller) {
            self.speed += propeller.produceAcceleration();
        });

        return this.speed;
    };

    return Vehicle;
}());
