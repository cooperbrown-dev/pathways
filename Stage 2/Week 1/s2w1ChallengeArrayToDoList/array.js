let toDoListArray = [];

// When add to list button is clicked, create a new object and add it to the to do list array
document.getElementById("addButton").addEventListener("click", function(){
    let input = document.getElementById("newListItem");
    let dueDateTime = document.getElementById("dueDateTime").value;

    if (!input.value) {
        alert("Please enter a to do item.");
        return;
    }

    let newToDo = {
        id: Date.now(),
        text: input.value,
        completed: false
    };

    if (dueDateTime) {
        newToDo.timeAndDateDue = dueDateTime
    }

    toDoListArray.push(newToDo);

    input.value = ""; // clear the to do input box
    document.getElementById("dueDateTime").value = ""; // clear the due date time picker
    renderToDoList();
});

function renderToDoList(){
    let list = document.getElementById("myList");
    list.innerHTML = "";

    toDoListArray.forEach(todo => {
        let li = document.createElement("li");
        li.className = "todo-item";

        li.innerHTML = `
            <input type="checkbox" ${todo.completed ? "checked" : ""}>
            <span class="${todo.completed ? "strikethrough" : ""}">${todo.text}</span>
            <span class="todo-due-date">${todo.timeAndDateDue ? formatDate(todo.timeAndDateDue) : ""}</span>
            <button class="deleteButton">❌</button>
            `;

        // Toggle completed and add strikethrough
        li.querySelector("input[type='checkbox']").addEventListener("click", function(){
            todo.completed = !todo.completed;
            renderToDoList();
        });

        // Delete button
        li.querySelector(".deleteButton").addEventListener("click", function(){
            let index = toDoListArray.findIndex(t => t.id === todo.id);
            if (index > -1) toDoListArray.splice(index, 1);
            renderToDoList();
        });

        list.appendChild(li);
    });
}

function formatDate(dateTime){
    let date = new Date(dateTime);
    return `${date.toLocaleDateString()} ${date.toLocaleTimeString()}`;
}

function clearToDoList(){
    toDoListArray = [];
    renderToDoList();
}

renderToDoList();