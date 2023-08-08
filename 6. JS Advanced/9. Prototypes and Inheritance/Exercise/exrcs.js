//task 1

(function solve() {

    Array.prototype.last = function () {

        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {

        let result = [];

        for (let i = n; i < this.length; i++) {

            result.push(this[i]);
        }

        return result;
    }

    Array.prototype.take = function (n) {

        let result = [];

        for (let i = 0; i < n; i++) {

            result.push(this[i])
        }

        return result;
    }

    Array.prototype.sum = function () {

        return this.reduce((result, current) => result + current, 0);
    }

    Array.prototype.average = function () {

        return this.reduce((result, current) => result + current, 0) / this.length;
    }
})();

//task 2

(function solve() {

    String.prototype.ensureStart = function (str) {

        if (this.startsWith(str)) {

            return this.toString();;
        } else {

            return str + this;
        }
    }

    String.prototype.ensureEnd = function (str) {

        if (this.endsWith(str)) {

            return this.toString();;
        } else {

            return this + str;
        }
    }

    String.prototype.isEmpty = function () {

        return this == '' ? true : false
    }

    String.prototype.truncate = function (n) {

        if (this.length <= n) {

            return this.toString();
        }

        if (n < 4) {

            let result = '';

            for (let i = 0; i < n; i++) {

                result += '.';
            }
            return result;
        }

        let current = this.slice(0, n);
        let sliced = current.split(' ');
        let result = '';

        if (sliced.length === 1) {

            result = current.slice(0, current.length - 3)

            for (let i = 0; i < 3; i++) {

                result += '.';
            }

            return result;
        }

        for (let i = 0; i < sliced.length - 1; i++) {

            result += sliced[i] + ' ';
        }

        result = result.trimEnd();

        if (result.length + 3 <= n) {

            for (let i = 0; i < 3; i++) {

                result += '.';
            }
        }
        else {

            result = result.slice(0, current.length - 3);
            result = result.trimEnd();

            for (let i = 0; i < 3; i++) {

                result += '.';
            }
        }

        return result;
    }

    String.format = function (string, ...params) {

        let index = 0;

        for (let param of params) {

            string = string.replace(`{${index++}}`, param)
        }

        return string;
    }
})();

//task 3

function extensibleObject() {

    return {

        __proto__: {},

        extend: function (obj) {

            for (let prop in obj) {

                if (typeof obj[prop] !== 'function') {

                    Object.defineProperty(this, prop, { value: obj[prop] })
                } else {

                    this.__proto__[prop] = obj[prop];
                }
            }
        }
    }
}

//task 4

function balloons() {

    class Balloon {

        constructor(color, hasWeight) {

            this.color = color;
            this.hasWeight = hasWeight;
        }
    }

    class PartyBalloon extends Balloon {

        constructor(color, hasWeight, ribbonColor, ribbonLength) {

            super(color, hasWeight);
            this._ribbon = {

                color: ribbonColor,
                length: ribbonLength
            }
        }

        get ribbon() { return this._ribbon }
    }

    class BirthdayBalloon extends PartyBalloon {

        constructor(color, hasWeight, ribbonColor, ribbonLength, text) {

            super(color, hasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() { return this._text }
    }

    return {

        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon
    }
}

//task 5

function solution() {

    class Employee {

        constructor(name, age) {

            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {

            console.log(this.tasks[0]);
            let current = this.tasks.shift();
            this.tasks.push(current);
        }

        collectSalary() {

            let amount = this.dividend ? this.salary + this.dividend : this.salary;
            console.log(`${this.name} received ${amount} this month.`);
        }
    }

    class Junior extends Employee {

        constructor(name, age) {

            super(name, age);
            this.tasks = [`${this.name} is working on a simple task.`];
        }
    }

    class Senior extends Employee {

        constructor(name, age) {

            super(name, age)
            this.tasks = [`${this.name} is working on a complicated task.`, `${this.name} is taking time off work.`, `${this.name} is supervising junior workers.`]
        }
    }

    class Manager extends Employee {

        constructor(name, age) {

            super(name, age);
            this.tasks = [`${this.name} scheduled a meeting.`, `${this.name} is preparing a quarterly report.`];
            this.dividend = 0;
        }
    }

    return { Employee, Junior, Senior, Manager }
}

//task 6

function postSolution() {

    class Post {

        constructor(title, content) {

            this.title = title;
            this.content = content;
        }

        toString = function () {

            return `Post: ${this.title}\nContent: ${this.content}`
        }
    }

    class SocialMediaPost extends Post {

        constructor(title, content, likes, dislikes) {

            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment = function (com) {

            this.comments.push(com);
        }

        toString = function () {

            let result = `Post: ${this.title}\nContent: ${this.content}\nRating: ${this.likes - this.dislikes}`;

            if (this.comments.length > 0) {

                result += '\nComments:\n';

                for (let com of this.comments) {

                    result += ` * ${com}\n`;
                }
            }
            return result.trim();
        }
    }

    class BlogPost extends Post {

        constructor(tittle, content, views) {

            super(tittle, content);
            this.views = views;
        }

        view = function () {

            this.views++;
            return this;
        }

        toString = function () {

            return `Post: ${this.title}\nContent: ${this.content}\nViews: ${this.views}`
        }
    }

    return { Post, SocialMediaPost, BlogPost }
}

//task 7

function createComputerHierarchy() {

    class Keyboard {

        constructor(manufacturer, responseTime) {

            this.manufacturer = manufacturer;
            this.responseTime = responseTime;
        }
    }

    class Monitor {

        constructor(manufacturer, width, height) {

            this.manufacturer = manufacturer;
            this.width = width;
            this.height = height;
        }
    }

    class Battery {

        constructor(manufacturer, expectedLife) {

            this.manufacturer = manufacturer;
            this.expectedLife = expectedLife;
        }
    }

    class Computer {

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {

            this.manufacturer = manufacturer;
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;

            if (this.constructor == Computer) {

                throw new Error();
            }
        }
    }

    class Laptop extends Computer {

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery,) {

            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery() { return this._battery }
        set battery(value) {

            if (!(value instanceof Battery)) {

                throw new TypeError();
            }

            this._battery = value;
        }
    }

    class Desktop extends Computer {

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {

            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard() { return this._keyboard }
        set keyboard(value) {

            if (!(value instanceof Keyboard)) {

                throw new TypeError();
            }

            this._keyboard = value;
        }

        get monitor() { return this._monitor }
        set monitor(value) {

            if (!(value instanceof Monitor)) {

                throw new TypeError();
            }

            this._monitor = value;
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    }
}