"use strict";
let numArray = [];
let modes = [];
function validateDisplayAndAddNumsToArray() {
    let minValue = Number(document.getElementById("minValue").value);
    let maxValue = Number(document.getElementById("maxValue").value);
    let numInput = Number(document.getElementById("numInput").value);
    if (numInput < minValue) {
        alert("You must enter a number greater than the minimum value provided.");
    }
    else if (numInput > maxValue) {
        alert("You must enter a number less than the maximum value provided.");
    }
    else if (numInput == "") {
        alert("Please enter a number between the minimum and maximum value.");
    }
    else {
        //Add number to array and display the numbers entered to the user.
        numArray.push(numInput);
        document.getElementById("enteredNums").innerHTML += numInput + " ";
    }
}
function calculateMean() {
    let sum = numArray.reduce((acc, num) => acc + num, 0);
    let mean = sum / numArray.length;
    document.getElementById("displayMean").innerHTML = mean.toString();
}
function calculateMedian() {
    let median;
    let orderedArray = numArray.sort((a, b) => a - b);
    let middleOfArray = Math.floor(orderedArray.length / 2);
    if (orderedArray.length % 2 == 0) {
        median = (orderedArray[middleOfArray - 1] + orderedArray[middleOfArray]) / 2;
    }
    else {
        median = orderedArray[middleOfArray];
    }
    document.getElementById("displayMedian").innerHTML = median.toString();
}
function calculateMode() {
    let maxCount = 0;
    for (let i = 0; i < numArray.length; i++) {
        let count = 0;
        for (let j = 0; j < numArray.length; j++) {
            if (numArray[j] === numArray[i]) {
                count++;
            }
        }
        if (count > maxCount) {
            maxCount = count;
            modes.length = 0;
            modes.push(numArray[i]);
        }
        else if (count === maxCount && !modes.includes(numArray[i])) {
            modes.push(numArray[i]);
        }
    }
    document.getElementById("displayMode").innerHTML = modes.join(" ");
}
function clearNums() {
    numArray = [];
    modes = [];
    document.getElementById("minValue").value = "";
    document.getElementById("maxValue").value = "";
    document.getElementById("numInput").value = "";
    document.getElementById("enteredNums").innerHTML = "";
    document.getElementById("displayMean").innerHTML = "";
    document.getElementById("displayMedian").innerHTML = "";
    document.getElementById("displayMode").innerHTML = "";
}
