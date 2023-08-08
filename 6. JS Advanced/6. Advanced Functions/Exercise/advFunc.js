//task 1

function sorting(array, criteria) {

    if (criteria === 'asc') {

        return array.sort((a, b) => a - b);
    } else if (criteria === 'desc') {

        return array.sort((a, b) => b - a);
    }
}

//task 2

function argumentsSummary(...arguments) {

    let types = [];

    for (let item of arguments) {

        let current = types.find(x => x.type === typeof item);

        if (current === undefined) {

            types.push({
                type: typeof item,
                count: 1
            });
        } else {

            current.count++;
        }

        print(item, ':');
    }

    types.sort((a, b) => b.count - a.count).forEach(x => typeCount(x))

    function print(value) {

        return console.log(`${typeof value}: ${value}`);
    }

    function typeCount(object) {

        return console.log(`${object.type} = ${object.count}`);
    }
}

//task 3

function getFibonator() {

    let firstNum = 0;
    let secontNum = 1;
    let isFirst = true;

    return function () {

        let result = firstNum + secontNum;

        if (isFirst) {

            isFirst = false;
            return result;
        }

        firstNum = secontNum;
        secontNum = result;
        return result;
    }
}