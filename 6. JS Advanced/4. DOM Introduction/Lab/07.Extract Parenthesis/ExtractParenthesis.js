function extract(content) {

    let element = document.getElementById(content).textContent;
    let matches = element.match(/[(]{1}[a-z,A-Z,\s]+[)]{1}/g);
    let array = Array.from(matches);
    let result = [];

    for (let item of array) {

        result.push(item.replace('(', '').replace(')', ''));
    }

    return document.getElementById(content).textContent = result.join('; ');
}