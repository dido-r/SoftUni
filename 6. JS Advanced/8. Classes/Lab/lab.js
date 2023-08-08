//task 1

class Person {

    constructor(firstName, lastName, age, email) {

        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email
    };

    toString = () => { return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})` }
}

//task 2

function solve() {

    let result = [];
    let person = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    result.push(person);
    person = new Person('SoftUni');
    result.push(person);
    person = new Person('Stephan', 'Johnson', 25);
    result.push(person);
    person = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');
    result.push(person);

    return result;
}

//task 3

class Circle {

    constructor(radius) {

        this.radius = radius;
    }

    get diameter() {

        return this.radius * 2;
    }

    set diameter(value) {

        this.radius = value / 2;
    }

    get area() {

        return Math.PI * this.radius ** 2;
    }
}

//task 4

class Point {

    constructor(x, y) {

        this.x = x;
        this.y= y;
    }

    static distance( point1, pont2){

        return Math.sqrt((pont2.x - point1.x) ** 2 + (pont2.y - point1.y) ** 2);
    }
}