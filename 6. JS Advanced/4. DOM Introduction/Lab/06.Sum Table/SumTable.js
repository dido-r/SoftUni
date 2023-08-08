function sumTable() {

    let elements = document.getElementsByTagName('td');
    let result = 0;

    for(let i = 1; i < elements.length - 1; i += 2){

        result += Number(elements[i].textContent);
    }

    document.getElementById('sum').textContent = result;
}