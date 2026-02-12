function checkAlgorithimAndAdd(){
    var wordToCheckInput = document.forms["palindromeForm"]["wordToCheck"].value;
    var algorithimNumToUseInput = document.forms["palindromeForm"]["algorithimNumToUse"].value;
    if (wordToCheckInput == ""){
        alert("Please enter a word to check")
        return false;
    }
    else if (algorithimNumToUseInput != 1 && algorithimNumToUseInput != 2 && algorithimNumToUseInput != 3){
        alert("Please enter algorithim number 1, 2 or 3")
        document.forms["palindromeForm"]["algorithimNumToUse"].value = "";
        return false;
    }
    else {
        if (algorithimNumToUseInput == 1){
            const reversedWord = wordToCheckInput.split("").reverse().join("");
            const tableRef = document.getElementById("algorithim1List");

            if (reversedWord == wordToCheckInput){
                (tableRef.insertRow(tableRef.rows.length)).innerHTML = wordToCheckInput + ": true";
            }
            else{
                (tableRef.insertRow(tableRef.rows.length)).innerHTML = wordToCheckInput + ": false";
            }
            document.forms["palindromeForm"]["wordToCheck"].value = "";
            document.forms["palindromeForm"]["algorithimNumToUse"].value = "";
        }

        else if (algorithimNumToUseInput == 2){
            var reversedWord = wordToCheckInput.split("").reverse().join("");
            var testWord = wordToCheckInput.split("");
            console.log(testWord);
            testWord = testWord.reverse();
            console.log(wordToCheckInput.split(""));
            const tableRef = document.getElementById("algorithim2List");

            if (reversedWord.toLowerCase() == wordToCheckInput.toLowerCase()){
                (tableRef.insertRow(tableRef.rows.length)).innerHTML = wordToCheckInput + ": true";
            }
            else{
                (tableRef.insertRow(tableRef.rows.length)).innerHTML = wordToCheckInput + ": false";
            }
            document.forms["palindromeForm"]["wordToCheck"].value = "";
            document.forms["palindromeForm"]["algorithimNumToUse"].value = "";
        }

        else if (algorithimNumToUseInput == 3){
            const tableRef = document.getElementById("algorithim3List")
            const vowels = 'aeiou';
            let count = 0;

            for (let char of wordToCheckInput.toLowerCase()){
                if (vowels.includes(char)){
                    count++;
                }
            }

            (tableRef.insertRow(tableRef.rows.length)).innerHTML = wordToCheckInput + " has " + count + " vowel(s)."

            document.forms["palindromeForm"]["wordToCheck"].value = "";
            document.forms["palindromeForm"]["algorithimNumToUse"].value = "";

        }
        else{
            alert("Error, try again.")
        }
    }

}

function clearList1(){
    const tableRef = document.getElementById("algorithim1List");
    tableRef.innerHTML = " ";
}

function clearList2(){
    const tableRef = document.getElementById("algorithim2List");
    tableRef.innerHTML = " ";
}

function clearList3(){
    const tableRef = document.getElementById("algorithim3List");
    tableRef.innerHTML = " ";
}