function addToToDoList(){
    let newListItem = document.getElementById("newListItem").value;
    
    if (newListItem === ""){
        alert("Please enter a new list item")
    }
    else{
        let myListTable = document.getElementById("myList");

        let row = myListTable.insertRow(myListTable.rows.length);
        let cell1 = row.insertCell();
        let cell2 = row.insertCell();
        let cell3 = row.insertCell();
        let cell4 = row.insertCell();

        // add a checkbox and strikethrough when checkbox is checked
        let checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        checkbox.name = "completed";
        checkbox.addEventListener("click", function(){
            cell2.classList.toggle("strikethrough");
        });
        cell1.appendChild(checkbox);

        // add the task to do
        cell2.innerHTML = newListItem;

        // add a due date/time for when the task is to be completed
        let dateAndTimeDue = document.createElement("input");
        dateAndTimeDue.type = "datetime-local";
        cell3.appendChild(dateAndTimeDue);
        
        // add a delete button to delete that row
        let deleteButton = document.createElement("button");
        deleteButton.textContent = "Delete";
        deleteButton.value = "Delete";
        deleteButton.addEventListener("click", function(){
            row.remove();
        });
        cell4.appendChild(deleteButton);

        // reset the input box
        document.getElementById("newListItem").value = "";
    }
}

function clearToDoList(){
    let myListTable = document.getElementById("myList");
    myListTable.innerHTML = " ";
}