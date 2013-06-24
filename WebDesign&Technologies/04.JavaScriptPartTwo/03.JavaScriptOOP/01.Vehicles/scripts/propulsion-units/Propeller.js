var Propeller = (function () {
    inherit(Propeller, PropulsionUnit);

    function Propeller(numberOfFins) {
        PropulsionUnit.call(this);

        this.numberOfFins = numberOfFins;

        this.spinDirection = spinDirection.CLOCKWISE;
    }

    Propeller.prototype.changeSpinDirection = function () {
        if (this.spinDirection === spinDirection.CLOCKWISE) {
            this.spinDirection = spinDirection.COUNTERCLOCKWISE;
        }
        else {
            this.spinDirection = spinDirection.CLOCKWISE;
        }

        return this;
    };

    Propeller.prototype.produceAcceleration = function () {
        if (this.spinDirection === spinDirection.CLOCKWISE) {
            return this.numberOfFins;
        } else {
            return -1 * this.numberOfFins;
        }
    };

    return Propeller;
}());
