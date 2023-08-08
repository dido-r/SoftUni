//task 1

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, input) {

    let coordinates = JSON.parse(input);
    let result = [];

    for (let item of coordinates) {

        result.push({

            area: area.call(item),
            volume: vol.call(item)
        });
    }

    return result;
}

//task 2

function solution(num1) {

    return function sum(num2) {

        return num1 + num2;
    }
}

//task 3

function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2, 2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function createFormatter(separator, symbol, symbolFirst, func) {

    return function (amount) {

        return func(separator, symbol, symbolFirst, amount);
    }
}

//task4

function filterEmployees(data, criteria) {

    let employees = JSON.parse(data);
    let key = criteria.split('-')[0];
    let value = criteria.split('-')[1];
    let result = '';
    let count = 0;

    if (criteria === 'all') {

        employees.forEach(x => result += format(count++, x));
        return console.log(result.trim());;
    }

    employees.filter(x => x[key] === value).forEach(x => result += format(count++, x));
    console.log(result.trim());

    function format(number, person) {

        return `${number}. ${person['first_name']} ${person['last_name']} - ${person['email']}\n`;
    }
}

// task 5

function commandProcessor() {

    let string = '';

    return {

        append: (text) => string += text,
        removeStart: (n) => string = string.slice(n),
        removeEnd: (n) => string = string.slice(0, string.length - n),
        print: () => console.log(string)
    }
}

//task 6

function listProcessor(input) {

    let result = [];
    input.forEach(x => inner(x.split(' ')[0], x.split(' ')[1]))

    function inner(command, element) {

        switch (command) {

            case 'add': result.push(element); break;
            case 'remove': result = result.filter(x => x !== element); break;
            case 'print': console.log(result.join(',')); break;
        }
    }
}

//task 7

function carProcessor(input) {

    let result = [];
    let parentList = [];
    input.forEach(x => inner(x));

    function inner(command) {

        let dataComamnt = command.split(' ');

        if (dataComamnt[0] === 'create') {

            let object = { name: dataComamnt[1] };

            if (dataComamnt.length === 4) {

                parentList.push({
                    parent: dataComamnt[3],
                    child: dataComamnt[1]
                });
            }

            result.push(object);
        }
        else if (dataComamnt[0] === 'set') {

            let currentCar = result.find(x => x.name === dataComamnt[1]);
            currentCar[dataComamnt[2]] = dataComamnt[3];
        }
        else if (dataComamnt[0] === 'print') {

            for (let pair of parentList) {

                let parentCar = result.find(x => x.name === pair.parent);
                let childCar = result.find(x => x.name === pair.child);

                for (let item in parentCar) {

                    if (item !== 'name') {

                        childCar[item] = parentCar[item];
                    }
                }
            }

            let currentCar = result.find(x => x.name === dataComamnt[1]);
            let printed = [];

            for (let item in currentCar) {

                if (item !== 'name') {

                    printed.push(`${item}:${currentCar[item]}`);
                }
            }

            console.log(printed.join(','))
        }
    }
}