//task 1

function createPerson(first, last) {

    let result = {

        firstName: first,
        lastName: last,
    }

    Object.defineProperty(result, 'fullName', {

        get() { return (this.firstName + ' ' + this.lastName) },
        set(value) {

            if (value.split(' ').length === 2) {

                result.firstName = value.split(' ')[0];
                result.lastName = value.split(' ')[1];
                this._fullName = value;
            }
        }
    });

    return result;
}

//task 2

function personAndTeacher() {

    class Person {

        constructor(name, email) {

            this.name = name;
            this.email = email
        }
    }

    class Teacher extends Person {

        constructor(name, email, subject) {

            super(name, email);
            this.subject = subject
        }
    }

    return {
        Person,
        Teacher
    }
}

//task 3

function toStringExtension() {

    class Person {

        constructor(name, email) {

            this.name = name;
            this.email = email;
            this.toString = () => { return `${this.constructor.name} (name: ${this.name}, email: ${this.email})` }
        }
    }

    class Teacher extends Person {

        constructor(name, email, subject) {

            super(name, email);
            this.subject = subject;
            this.toString = () => `Teacher (name: ${this.name}, email: ${this.email}, subject: ${this.subject})`;
        }
    }

    class Student extends Person {

        constructor(name, email, course) {

            super(name, email);
            this.course = course;
            this.toString = () => { return `Student (name: ${this.name}, email: ${this.email}, course: ${this.course})` }
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

//task 4
function extendProrotype(classToExtend) {

    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () { return `I am a ${this.species}. ${this.toString()}` };
}

//task 5
function solve() {

    class Figure {

        constructor(units = 'cm') {

            this.units = units;
            this.area;
            this.changeUnits = (u) => {

                if (this.units !== u) {
                    if (this instanceof Circle) {

                        switch (u) {

                            case 'mm': this.radius *= 10; this.area *= 100; break;
                            case 'm': this.radius /= 100; this.area /= 1000; break;
                            case 'cm':
                                if (this.units === 'mm') this.radius /= 10; this.area /= 100;
                                if (this.units === 'm') this.radius *= 100; this.area *= 10000;
                                break;
                        }

                    } else if (this instanceof Rectangle) {

                        switch (u) {

                            case 'mm': this.width *= 10; this.height *= 10; this.area *= 100; break;
                            case 'm': this.width /= 100; this.height /= 100; this.area /= 1000; break;
                            case 'cm':
                                if (this.units === 'mm') { this.width /= 10; this.height /= 10; this.area /= 100; }
                                else if (this.units === 'm') { this.width *= 100; this.height *= 100; this.area *= 10000; }
                                break;
                        }
                    }

                    this.units = u
                }
            }
        }

        toString = () => { return `Figures units: ${this.units}` }
    }

    class Circle extends Figure {

        constructor(r) {

            super();
            this.radius = r;
            this.area = Math.PI * this.radius * this.radius;
        }

        toString = () => { return `Figures units: ${this.units} Area: ${this.area} - radius: ${this.radius}` }
    }

    class Rectangle extends Figure {

        constructor(width, height, units) {

            super(units);
            this.isInit = true;
            this.width = width;
            this.height = height;
            this.area = this.width * this.height;
        }

        get width() { return this._width }
        set width(value) {

            if (this.isInit) {

                switch (this.units) {
                    case 'mm': value *= 10; break;
                    case 'm': value /= 10; break;
                }
            }

            this._width = value;
        }

        get height() { return this._height }
        set height(value) {

            if (this.isInit) {

                switch (this.units) {
                    case 'mm': value *= 10; break;
                    case 'm': value /= 10; break;
                }

                this.isInit = false;
            }
            this._height = value;
        }

        toString = () => { return `Figures units: ${this.units} Area: ${this.area} - width: ${this.width}, height: ${this.height}` }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}