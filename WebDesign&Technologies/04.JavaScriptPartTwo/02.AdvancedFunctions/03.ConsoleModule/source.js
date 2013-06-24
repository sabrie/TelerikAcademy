/*
Create a module to work with the console object.Implement functionality for:
    Writing a line to the console 
    Writing a line to the console using a format
    Writing to the console should call toString() to each element
    Writing errors and warnings to the console with and without format

    Example:
    var specialConsole = …
    specialConsole.writeLine("Message: hello"); // logs to the console - Message: hello
    specialConsole.writeLine("Message: {0}, {1}!", "Hello", "Pesho"); // logs to the console - Message: Hello, Pesho!
    specialConsole.writeError("Error: {0}", "Something happened"); // logs to the console - Error: Something happened
    specialConsole.writeWarning("Warning: {0}", "A warning"); // logs to the console - Warning: A warning
*/

var specialConsole = (function () {

    function _format(str /*, params */) {

        var selfArguments = arguments;

        return str.replace(/\{(\d+)\}/g, function (match, p1) {

            return selfArguments[+p1 + 1];
        });
    }
    
    return {
        writeLine: function () {

            console.log(_format.apply(null, arguments));
        },

        writeError: function () {

            console.error(_format.apply(null, arguments));
        },

        writeWarning: function () {

            console.warn(_format.apply(null, arguments));
        }
    };
}());

specialConsole.writeLine("Message: hello"); // Message: hello
specialConsole.writeLine("Message: {0}, {1}!", "Hello", "Pesho"); // Message: Hello, Pesho!
specialConsole.writeError("Error: {0}", "Something happened"); // Error: Something happened
specialConsole.writeWarning("Warning: {0}", "A warning"); // Warning: A warning

