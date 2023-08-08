function sumArray(array, startIndex, endIndex) {

    if (!Array.isArray(array) || array.find(x => typeof x !== 'number')) {

        return NaN;
    }

    if (startIndex < 0) {

        startIndex = 0;
    }

    if (endIndex > array.length - 1) {

        endIndex = array.length - 1;
    }

    return array.filter((x, i) => i >= startIndex).filter((x, i) => i <= endIndex).reduce((result, x) => result + x, 0);
}

//task 2

function factory(face, suit) {

    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const suits = ['S', 'H', 'D', 'C'];

    if (!faces.find(x => x === face) || !suits.find(x => x === suit)) {

        throw Error();
    }

    switch (suit) {

        case 'S': suit = '\u2660'; break;
        case 'H': suit = '\u2665'; break;
        case 'D': suit = '\u2666'; break;
        case 'C': suit = '\u2663'; break;
    }

    return {

        face,
        suit,
        toString: () => { return `${face}${suit}` }
    }
}

//task 3

function printDeckOfCards(deck) {

    let result = [];

    for (let item of deck) {

        let face = item.length === 2 ? item[0] : item[0] + item[1];
        let suit = item.length === 2 ? item[1] : item[2];

        try {
            let card = createCard(face, suit);
            result.push(card);
        } catch {

            return console.log(`Invalid card: ${face}${suit}`);
        }
    }

    return console.log(result.join(' '));

    function createCard(face, suit) {

        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = ['S', 'H', 'D', 'C'];

        if (!faces.find(x => x === face) || !suits.find(x => x === suit)) {

            throw Error();
        }

        switch (suit) {

            case 'S': suit = '\u2660'; break;
            case 'H': suit = '\u2665'; break;
            case 'D': suit = '\u2666'; break;
            case 'C': suit = '\u2663'; break;
        }

        return {

            face,
            suit,
            toString: () => { return `${face}${suit}` }
        }
    }
}

//task 4

function sum(arr) {
    let sum = 0;

    for (let num of arr) {

        sum += Number(num);
    }

    return sum;
}

//module.exports = { sum };

//task 5

function isSymmetric(arr) {

    if (!Array.isArray(arr)) {

        return false; // Non-arrays are non-symmetric
    }

    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));

    return equal;
}

//module.exports = { isSymmetric };

//task 6

function rgbToHexColor(red, green, blue) {

    if (!Number.isInteger(red) || (red < 0) || (red > 255)) {
        return undefined; // Red value is invalid
    }

    if (!Number.isInteger(green) || (green < 0) || (green > 255)) {
        return undefined; // Green value is invalid
    }

    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255)) {
        return undefined; // Blue value is invalid
    }

    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

//module.exports = { rgbToHexColor };

//task 7

function createCalculator() {
    
    let value = 0;
    
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

module.exports = { sum, isSymmetric, rgbToHexColor, createCalculator };

console.log(typeof true)