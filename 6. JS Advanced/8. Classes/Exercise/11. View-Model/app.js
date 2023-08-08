class Textbox {

    constructor(selector, regex) {

        this.selector = selector;
        this.regex = regex;
        this._value;
        this._elements = document.querySelectorAll(selector);
        this._invalidSymbols = regex;
        Array.from(this._elements).forEach(x => x.addEventListener('change', () => this.value = x.value))
    }

    get elements() { return this._elements }

    get value() { return this._elements[0].value }

    set value(currnetValue) { Array.from(this._elements).forEach(x => x.value = currnetValue) }

    isValid = () => { return !this._invalidSymbols.test(this._elements[0].value) }
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
let inputs = document.querySelectorAll('.textbox');

Array.from(inputs).forEach(x => x.addEventListener('click', function () { console.log(textbox.value); }));
