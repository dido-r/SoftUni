function extractText() {
    
    let elements = document.getElementsByTagName('li');
    let result = document.getElementById('result');

    for(let item of elements){

        result.textContent += item.textContent + '\n';
    }
}