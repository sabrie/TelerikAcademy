"use strict";

function Solve(args) {
    var i;
    var n = parseInt(args[0]);

    var numbers = [];

    for (i = 0; i < n; i++) {
        numbers.push(parseInt(args[i + 1]));
    }   
    
    var currentSum = numbers[0];
    var maxSum = currentSum;

    for (i = 1; i < numbers.length; i++) {
        currentSum = currentSum + numbers[i];

        if (currentSum > maxSum) {
            maxSum = currentSum;            
        }
    }

    return maxSum;
}