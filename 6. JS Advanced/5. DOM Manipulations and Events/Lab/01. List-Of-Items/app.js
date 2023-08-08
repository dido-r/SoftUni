function addItem() {
    
    let text = document.getElementById('newItemText');
    let li = document.createElement('li');
    li.textContent = text.value;
    document.getElementById('items').appendChild(li);
    text.value = '';
}