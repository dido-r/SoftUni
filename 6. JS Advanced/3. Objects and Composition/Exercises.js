//task 1

function calorieObject(input) {

    let result = {};

    for (let i = 0; i < input.length; i += 2) {

        result[input[i]] = Number(input[i + 1]);
    }

    console.log(result);
}

//task 2

function constructionCrew(worker) {

    if (worker.dizziness === true) {

        worker.levelOfHydrated += worker.weight * 0.1 * worker.experience;
        worker.dizziness = false;
    }

    return worker;
}

//task 3

function carFactory(car) {

    if (car.power <= 90) {

        car.engine = {

            power: 90,
            volume: 1800
        }
    } else if (car.power <= 120) {

        car.engine = {

            power: 120,
            volume: 2400
        }
    } else if (car.power <= 200) {

        car.engine = {

            power: 200,
            volume: 3500
        }
    }

    switch (car.carriage) {

        case 'hatchback': car.carriage = {

            type: 'hatchback',
            color: car.color
        }; break;
        case 'coupe': car.carriage = {

            type: 'coupe',
            color: car.color
        }; break;
    }

    let weelSize = car.wheelsize;

    if (car.wheelsize % 2 === 0) {

        weelSize = 2 * Math.floor(car.wheelsize / 2) - 1
    }

    car.wheels = [weelSize, weelSize, weelSize, weelSize];

    delete car.power;
    delete car.color;
    delete car.wheelsize;

    return car;
}

//task 4

function heroRegistry(heroes) {

    let result = [];

    for (let hero of heroes) {

        let data = hero.split(' / ');

        result.push({

            name: data[0],
            level: Number(data[1]),
            items: data[2] !== undefined ? data[2].split(', ') : []
        });
    }

    console.log(JSON.stringify(result))
}

//task 5

function lowestPrice(input) {

    let result = [];

    for (let product of input) {

        let data = product.split(' | ');

        if (!result.some(x => x.name === data[1])) {

            result.push({
                name: data[1],
                price: Number(data[2]),
                town: data[0]
            });
        } else {
            let current = result.find(x => x.name === data[1])

            if (Number(data[2]) < current.price) {

                current.price = Number(data[2]);
                current.town = data[0];
            }
        }
    }

    result.forEach(x => console.log(`${x.name} -> ${x.price} (${x.town})`));
}

// task 6

function storeCatalogue(products) {

    let result = [];

    for (let product of products) {

        let productInfo = product.split(' : ');

        result.push({

            name: productInfo[0],
            price: productInfo[1]
        })
    }

    result.sort((a, b) => a.name.localeCompare(b.name));
    let firstLetter = 'No Letter';

    for (let item of result) {

        if (item.name[0] !== firstLetter) {

            firstLetter = item.name[0];
            console.log(firstLetter);
        }

        console.log(`  ${item.name}: ${item.price}`);
    }
}

//task 7

function townsJson(towns) {

    let result = [];

    for (let i = 1; i < towns.length; i++) {

        let data = towns[i].split(' | ');
        console.log()

        result.push({

            Town: data[0].replace('| ', ''),
            Latitude: Number(Number(data[1]).toFixed(2)),
            Longitude: Number(Number(data[2].replace(' |', '')).toFixed(2)),
        });
    }

    console.log(JSON.stringify(result));
}

//task 8

function rectangle(width, height, color) {

    return {

        width,
        height,
        color: color.replace(color[0], color[0].toUpperCase()),
        calcArea() {

            return width * height;
        }
    }
}

//task 9

function createSortedList() {

    let sortedList = [];

    return {

        sortedList,

        add(element) {

            sortedList.push(element);
            sortedList.sort((a, b) => a - b);
            this.size = sortedList.length;
        },

        remove(index) {

            if (index >= 0 && index < sortedList.length) {

                delete sortedList[index];
                sortedList = sortedList.filter(x => x !== undefined);
                this.size = sortedList.length;
            }
        },

        get(index) {

            if (index >= 0 && index < sortedList.length) {

                return sortedList[index];
            }
        },

        size: 0
    }
}

//task 10

function solve() {

    return {

        mage(nameOFfMage) {

            return {

                name: nameOFfMage,
                health: 100,
                mana: 100,
                cast(spell) {

                    this.mana--;
                    console.log(`${this.name} cast ${spell}`);
                }
            }
        },

        fighter(nameOfFighter) {

            return {

                name: nameOfFighter,
                health: 100,
                stamina: 100,
                fight() {

                    this.stamina--;
                    console.log(`${this.name} slashes at the foe!`);
                }
            }
        }
    }
}

//task 11

function operation(input) {

    let numbers = [];
    let result = 0;

    for (let item of input) {

        if (typeof item === 'number') {

            numbers.push(item);
        } else {

            if (numbers.length < 2) {

                return console.log('Error: not enough operands!');
            }

            result = numbers.pop();

            switch (item) {
                case '+': result = numbers.pop() + result; break;
                case '-': result = numbers.pop() - result; break;
                case '*': result = numbers.pop() * result; break;
                case '/': result = numbers.pop() / result; break;
            }

            numbers.push(result);
        }
    }

    if (numbers.length > 1) {

        return console.log('Error: too many operands!');
    }

    console.log(result);
}