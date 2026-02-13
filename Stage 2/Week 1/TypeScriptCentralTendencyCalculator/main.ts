let numArray: number[] = [];
let modes: number[] = [];

function validateDisplayAndAddNumsToArray(){
    let minValue: number = Number((document.getElementById("minValue") as HTMLInputElement).value);
    let maxValue: number = Number((document.getElementById("maxValue") as HTMLInputElement).value);
    let numInput: number = Number((document.getElementById("numInput") as HTMLInputElement).value);

    if(numInput < minValue){
        alert("You must enter a number greater than the minimum value provided.")
    }
    else if(numInput > maxValue){
        alert("You must enter a number less than the maximum value provided.")
    }
    else if(numInput == ""){
        alert("Please enter a number between the minimum and maximum value.")
    }
    else{
        //Add number to array and display the numbers entered to the user.
        numArray.push(numInput);
        (document.getElementById("enteredNums") as HTMLSpanElement).innerHTML += numInput + " ";
    }
}

function calculateMean(){
    let sum: number = numArray.reduce((acc, num) => acc + num, 0);
    let mean: number = sum / numArray.length;
    (document.getElementById("displayMean") as HTMLSpanElement).innerHTML = mean.toString();
}

function calculateMedian(){
    let median: number;
    let orderedArray: number[] = numArray.sort((a, b) => a - b);
    let middleOfArray: number = Math.floor(orderedArray.length / 2);
    
    if(orderedArray.length % 2 == 0){
        median = (orderedArray[middleOfArray - 1] + orderedArray[middleOfArray]) / 2;
    }
    else{
        median = orderedArray[middleOfArray];
    }
    (document.getElementById("displayMedian") as HTMLSpanElement).innerHTML = median.toString();
}

function calculateMode(){
    let maxCount: number = 0;
    
    for (let i: number = 0; i < numArray.length; i++){
        let count: number = 0;
        for (let j: number = 0; j < numArray.length; j++){
            if (numArray[j] === numArray[i]){
                count++;
            }
        }
        
        if (count > maxCount){
            maxCount = count;
            modes.length = 0;
            modes.push(numArray[i]);
        } else if(count === maxCount && !modes.includes(numArray[i])){
            modes.push(numArray[i])
        }
    }
    (document.getElementById("displayMode") as HTMLSpanElement).innerHTML = modes.join(" ")
}

function clearNums(){
    numArray = [];
    modes = [];
    (document.getElementById("minValue") as HTMLInputElement).value = "";
    (document.getElementById("maxValue") as HTMLInputElement).value = "";
    (document.getElementById("numInput") as HTMLInputElement).value = "";
    (document.getElementById("enteredNums") as HTMLSpanElement).innerHTML = "";
    (document.getElementById("displayMean") as HTMLSpanElement).innerHTML = "";
    (document.getElementById("displayMedian") as HTMLSpanElement).innerHTML = "";
    (document.getElementById("displayMode") as HTMLSpanElement).innerHTML = "";
}