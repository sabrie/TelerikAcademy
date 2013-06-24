var list = document.getElementById('todo-list');
var addButton = document.getElementById('add-btn');
var deleteButton = document.getElementById('delete-btn');
var showButton = document.getElementById('show-btn');
var hideButton = document.getElementById('hide-btn');

function add(value) {
    var listItem = document.createElement('li');

    listItem.innerHTML = value;
    list.appendChild(listItem);
}

function deleteItem(itemValue) {
    var listItems = document.getElementsByTagName('li');

    for (var i = 0; i < listItems.length; i++) {
        if (listItems[i].innerHTML === itemValue) {
            list.removeChild(listItems[i]);
        }
    }
}

function showList() {
    
    list.style.visibility = 'visible';
}

function hideList() {

    list.style.visibility = 'hidden';
}

addButton.addEventListener('click', function (e) {
    e.preventDefault();

    var inputValue = document.getElementById('input').value;

    add(inputValue);
});

deleteButton.addEventListener('click', function (e) {
    e.preventDefault();

    var inputValue = document.getElementById('input').value;

    deleteItem(inputValue);
});

showButton.addEventListener('click', function (e) {
    e.preventDefault();

    showList();
});

hideButton.addEventListener('click', function (e) {
    e.preventDefault();

    hideList();
});