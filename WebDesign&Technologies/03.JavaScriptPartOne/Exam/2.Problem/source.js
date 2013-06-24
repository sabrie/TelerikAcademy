//"use strict";
function isInRange(currRow, currCol, rows, cols) {

    if (currRow >= 0 && currRow < rows &&
        currCol >= 0 && currCol < cols) {
        return true;
    }
    return false;
}

function Solve(args) {

    var i, rows, cols; // loop counter

    // INPUT

    // rows and cols
    var dimensions = args[0].split(" ").map(function (number) {
        return +number;
    });

    var n = dimensions[0];
    var m = dimensions[1];


    // start position
    var startPoint = args[1].split(" ").map(function (number) {
        return +number;
    });

    var startRow = startPoint[0];
    var startCol = startPoint[1];

    // string of all directions
    var directionsString = "";

    for (i = 2; i < n + 2; i++) {
        directionsString += args[i];
    }


    // matrix of numbers  ---- from 1 to n*m
    var numbers = [];
    var number = 1;
    for (rows = 0; rows < n; rows++) {
        for (cols = 0; cols < m; cols++) {
            numbers[[rows, cols]] = number;
            number++;
        }
    }

    // matrix of directions --- n*m
    var directions = [];
    var counter = 0;
    for (rows = 0; rows < n; rows++) {
        for (cols = 0; cols < m; cols++) {
            directions[[rows, cols]] = directionsString[counter++];
            number++;
        }
    }

    // ALGORITHM

    var visited = [];
    var sum = 0;
    var result = "";
    var numberOfVisited = 0;

    sum += numbers[[startRow, startCol]];
    visited[[startRow, startCol]] = true;

    while (isInRange(startRow, startCol, n, m)) {

        // LEFT
        if (directions[[startRow, startCol]] === "l") {
            startCol = startCol - 1;
            numberOfVisited++;
            if (visited[[startRow, startCol]] == true) {
                result = "lost " + numberOfVisited;
                break;
            }
            else if (isInRange(startRow, startCol, n, m)) {
                sum += numbers[[startRow, startCol]];
            }
            else {
                result = "out " + sum;
                break;
            }

            visited[[startRow, startCol]] = true;
        }

        // RIGHT
        if (directions[[startRow, startCol]] === "r") {
            startCol = startCol + 1;
            numberOfVisited++;

            if (visited[[startRow, startCol]] == true) {
                result = "lost " + numberOfVisited;
                break;
            }
            else if (isInRange(startRow, startCol, n, m)) {
                sum += numbers[[startRow, startCol]];
            }
            else {
                result = "out " + sum;
                break;
            }
            visited[[startRow, startCol]] = true;
        }

        // UP
        if (directions[[startRow, startCol]] === "u") {
            startRow = startRow - 1;
            numberOfVisited++;

            if (visited[[startRow, startCol]] == true) {
                result = "lost " + numberOfVisited;
                break;
            }
            else if (isInRange(startRow, startCol, n, m)) {
                sum += numbers[[startRow, startCol]];
            }
            else {
                result = "out " + sum;
                break;
            }
            visited[[startRow, startCol]] = true;
        }

        // DOWN
        if (directions[[startRow, startCol]] === "d") {
            startRow = startRow + 1;
            numberOfVisited++;

            if (visited[[startRow, startCol]] == true) {
                result = "lost " + numberOfVisited;
                break;
            }
            else if (isInRange(startRow, startCol, n, m)) {
                sum += numbers[[startRow, startCol]];
            }
            else {
                result = "out " + sum;
                break;
            }
            visited[[startRow, startCol]] = true;
        }
    }

    // TESTS
    //console.log(startPoint);
    //console.log(directionsString);
    //console.log(numbers);
    //console.log(numbers[[2,3]]);
    //console.log(directions);

    return result;
}