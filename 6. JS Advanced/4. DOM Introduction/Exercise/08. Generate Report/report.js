function generateReport() {

    let indexes = [];
    let names = [];
    let current = 0;

    for (let item of document.querySelectorAll('thead tr th')) {

        if (item.querySelectorAll('input')[0].checked) {

            indexes.push(current);
        }
        
        names.push(item.querySelectorAll('input')[0].name);
        current++;
    }

    let result = [];

    for (let item of document.querySelectorAll('tbody tr')) {

        let row = item.querySelectorAll('td');
        let object = {};

        for (let index of indexes) {

            object[names[index]] = row[index].textContent;
        }

        result.push(object);
    }

    document.getElementById('output').textContent = JSON.stringify(result, null, "\t");
}