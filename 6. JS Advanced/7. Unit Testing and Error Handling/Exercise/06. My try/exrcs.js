//task 1

function requestValidator(object) {

    if (object['method'] === undefined || object.method !== 'GET' && object.method !== 'POST' && object.method !== 'DELETE' && object.method !== 'CONNECT') {

        throw Error(`Invalid request header: Invalid Method`);
    }

    if (object['uri'] === undefined || object.uri.match(/^[\w.]+$/g) === null) {

        throw Error(`Invalid request header: Invalid URI`);
    }

    if (object['version'] === undefined || object.version !== 'HTTP/0.9' && object.version !== 'HTTP/1.0' && object.version !== 'HTTP/1.1' && object.version !== 'HTTP/2.0') {

        throw Error(`Invalid request header: Invalid Version`);
    }

    if (object['message'] === undefined || object.message.match(/^([^<>\\&'"]+)$|(^$)/g) === null) {

        throw Error(`Invalid request header: Invalid Message`);
    }

    return object;
}

//task 2

function isOddOrEven(string) {

    if (typeof (string) !== 'string') {
        return undefined;
    }

    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

//task 3

function lookupChar(string, index) {

    if (typeof (string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }

    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

//task4
let mathEnforcer = {

    addFive: function (num) {

        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },

    subtractTen: function (num) {

        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },

    sum: function (num1, num2) {

        if (typeof (num1) !== 'number' || typeof (num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

module.exports = { isOddOrEven, lookupChar, mathEnforcer };