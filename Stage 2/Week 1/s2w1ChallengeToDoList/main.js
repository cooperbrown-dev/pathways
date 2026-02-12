function addToToDoList(){
    let newListItem = document.getElementById("newListItem").value;
    
    if (newListItem == ""){
        alert("Please enter a new list item")
    }
    else{
        let myListTable = document.getElementById("myList");

        let row = myListTable.insertRow(myListTable.rows.length);
        let cell1 = row.insertCell();
        let cell2 = row.insertCell();
        let cell3 = row.insertCell();

        let checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        checkbox.name = "completed";
        checkbox.addEventListener("click", function(){
            cell2.classList.toggle("strikethrough");
        });
        cell1.appendChild(checkbox);

        cell2.innerHTML = newListItem;

        let deleteButton = document.createElement("button");
        deleteButton.textContent = "Delete";
        deleteButton.value = "Delete";
        deleteButton.addEventListener("click", function(){
            row.remove();
        });
        cell3.appendChild(deleteButton);

        //add due date?
        //cell4

        document.getElementById("newListItem").value = "";
    }
}

function clearToDoList(){
    let myListTable = document.getElementById("myList");
    myListTable.innerHTML = " ";
}