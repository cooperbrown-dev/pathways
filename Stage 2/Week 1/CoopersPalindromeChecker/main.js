function checkIfPalindromeAndAdd(){
    var wordToCheckInput = document.forms["palindromeForm"]["wordToCheck"].value;
    var algorithimNumToUseInput = document.forms["palindromeForm"]["algorithimNumToUse"].value;
    if (wordToCheckInput == ""){
        alert("Please enter a word to check")
        return false;
    }
    else if (algorithimNumToUseInput != 1 && algorithimNumToUseInput != 2){
        alert("Please enter algorithim number 1 or 2")
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
            const reversedWord = wordToCheckInput.split("").reverse().join("");
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