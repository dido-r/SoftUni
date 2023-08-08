//task 1

function printWithDelimiter(array, delimiter) {

    console.log(array.join(delimiter));
}

//task 2

function solve(array, number) {

    let result = [];

    for (let i = 0; i < array.length; i += number) {

        result.push(array[i]);
    }

    return result;
}

// task 3

function addRemove(commands) {

    let result = [];

    for (let i = 0; i < commands.length; i++) {

        switch (commands[i]) {

            case 'add':
                result.push(i + 1);
                break;
            case 'remove':
                result.pop();
                break;
        }
    }

    if (result.length === 0) {

        console.log('Empty');
    } else {

        console.log(result.join('\n'));
    }
}

//task 4

function rotate(array, number) {

    for (let i = 0; i < number; i++) {

        let current = array[array.length - 1];

        for (let j = array.length - 1; j > 0; j--) {

            array[j] = array[j - 1];
        }

        array[0] = current;
    }

    console.log(array.join(' '))
}

//task 5

function substract(array) {

    let result = [array[0]];

    for (let i = 1; i < array.length; i++) {

        if (array[i] >= result[result.length - 1]) {

            result.push(array[i]);
        }
    }

    return result;
}

// task 6

function sorting(array) {

    array.sort((a, b) => a.localeCompare(b));

    for (let i = 0; i < array.length; i++) {

        console.log(`${i + 1}.${array[i]}`);
    }
}

//task 7

function sortingNumbers(array) {

    array.sort((a, b) => a - b);
    let result = [];
    let size = array.length;

    for (let i = 0; i < size; i++) {

        if (i % 2 === 0) {

            result.push(array.shift());
        } else {

            result.push(array.pop());
        }
    }

    return result;
}

//task 8

function sortByCriteria(array) {

    array.sort((a, b) => {
        if (a.length > b.length) {

            return 1;
        } else if (a.length < b.length) {

            return -1;
        } else {
            if (a.localeCompare(b) === 1) {
                return 1;
            } else {
                return -1;
            };
        }
    })

    console.log(array.join('\n'));
}

//task 9

function magicMatrix(matrix) {

    let isMagical = true;
    let rowSum = 0;
    let colSum = 0;

    for (let i = 0; i < matrix.length; i++) {

        let currentRowSum = 0;
        let currentColSum = 0;

        for (let j = 0; j < matrix[i].length; j++) {

            currentRowSum += matrix[i][j];
        }

        for (let k = 0; k < matrix.length; k++) {

            currentColSum += matrix[k][i];
        }

        if (rowSum === 0) {

            rowSum = currentRowSum;
        } else {

            if (rowSum !== currentRowSum) {
                isMagical = false;
                break;
            }
        }

        if (colSum === 0) {

            colSum = currentColSum;
        } else {

            if (colSum !== currentColSum) {
                isMagical = false;
                break;
            }
        }
    }

    return isMagical;
}