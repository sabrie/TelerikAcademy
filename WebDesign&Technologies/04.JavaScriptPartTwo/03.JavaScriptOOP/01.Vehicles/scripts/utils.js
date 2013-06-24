function inherit(Child, Parent) {
    Child.prototype = Object.create(Parent.prototype);
    Child.prototype.constructor = Child;
}

function mixin(Child, Obj) {
    var prop;

    for (prop in Obj.prototype) {
        if (Obj.prototype.hasOwnProperty(prop)) {
            if (prop !== 'constructor') {
                Child.prototype[prop] = Obj.prototype[prop];
            }
        }
    }

    return Child;
}
