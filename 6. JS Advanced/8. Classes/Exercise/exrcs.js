//task 1

class Rectangle {

    constructor(width, height, color) {

        this.width = width;
        this.height = height;
        this.color = color;
    }

    calcArea = () => { return this.width * this.height }
}

//task 2

class Request {

    constructor(method, uri, version, message) {

        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
}

//task 3

function ticketManager(ticketData, sortingCriteria) {

    let ticketList = [];

    class Ticket {

        constructor(array) {

            this.destination = array[0];
            this.price = Number(array[1]);
            this.status = array[2];
        }
    }

    for (let item of ticketData) {

        ticketList.push(new Ticket(item.split('|')));
    }

    switch (sortingCriteria) {

        case 'destination': ticketList.sort((a, b) => a.destination.localeCompare(b.destination)); break;
        case 'price': ticketList.sort((a, b) => a - b); break;
        case 'status': ticketList.sort((a, b) => a.status.localeCompare(b.status)); break;
    }

    return ticketList;
}

//task 4

class List {

    array = [];
    size = 0;

    add(element) {

        this.array.push(element);
        this.array.sort((a, b) => a - b);
        this.size = this.array.length;
    }

    remove(index) {

        if (index >= 0 & index < this.array.length) {

            this.array = this.array.filter((x, i) => i !== index)
        }

        this.size = this.array.length;
    };

    get(index) {

        if (index >= 0 & index < this.array.length) {

            return this.array[index];
        }
    };
}

//task 5

class Stringer {

    constructor(innerString, innerLength) {

        this.innerString = innerString;
        this.innerLength = innerLength;
        this.compareString = innerString;
    }

    increase(index) {

        if (index < 0) {

            index = 0;
        }

        this.innerLength += index;
        this.innerString = this.compareString.slice(0, this.innerLength);
    };

    decrease(index) {

        if (index < 0) {

            index = 0;
        }

        this.innerLength -= index;

        if (this.innerLength < 0) {

            this.innerLength = 0;
        }

        this.innerString = this.innerString.slice(0, this.innerLength);
    };

    toString = () => { return this.innerString === this.compareString ? this.innerString : this.innerString + '...' }
}