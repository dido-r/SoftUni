function addItem() {
    
    let parent = document.getElementById('items');
    let input = document.getElementById('newItemText');
    let child = document.createElement('li');
    child.textContent = input.value;
    parent.appendChild(child);
    input.value = '';
    let a = document.createElement('a');
    a.href = "#";
    a.addEventListener('click', toDelete)
    a.textContent = '[Delete]';
    child.appendChild(a);

    function toDelete(){

        child.remove();
    }
}