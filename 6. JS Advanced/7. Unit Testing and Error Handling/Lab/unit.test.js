const { expect } = require('chai');
const { sum, isSymmetric, rgbToHexColor, createCalculator } = require('./unitTesting');

//task 4

describe('sum', () => {

    it('Array is not Array', () => {

        let result = sum('text');
        expect(result).to.be.NaN;
    });

    it('Is result valid', () => {

        let result = sum([1, 2, 3, 4, 5]);
        expect(result).to.be.equal(15);
    });
});

//task 5

describe('isSymmetric', () => {

    it('String input should be false', () => {

        let array = 'test';
        let result = isSymmetric(array);
        expect(result).to.be.false;
    });

    it('Number input should be false', () => {

        let array = 3;
        let result = isSymmetric(array);
        expect(result).to.be.false;
    });

    it('Is result valid with odd length', () => {

        let array = ['1', '2', '3', '2', '1'];
        let result = isSymmetric(array);
        expect(result).to.be.true;
    });

    it('Is result valid with even length', () => {

        let array = ['1', '2', '3', '4', '4', '3', '2', '1'];
        let result = isSymmetric(array);
        expect(result).to.be.true;
    });

    it('Is result inValid', () => {

        let array = [1, 2, 2, 3];
        let result = isSymmetric(array);
        expect(result).to.be.false;
    });
});

//task 6

describe('rgbToHexColor', () => {

    it('Is blue an integer', () => {

        let result = rgbToHexColor('text', 10, 10);
        expect(result).to.be.undefined;
    });

    it('Is blue over min range', () => {

        let result = rgbToHexColor(-3, 10, 10);
        expect(result).to.be.undefined;
    });

    it('Is blue under max range', () => {

        let result = rgbToHexColor(300, 10, 10);
        expect(result).to.be.undefined;
    });

    it('Is green an integer', () => {

        let result = rgbToHexColor(10, 'text', 10);
        expect(result).to.be.undefined;
    });

    it('Is green over min range', () => {

        let result = rgbToHexColor(10, -9, 10);
        expect(result).to.be.undefined;
    });

    it('Is green under max range', () => {

        let result = rgbToHexColor(30, 1000, 10);
        expect(result).to.be.undefined;
    });

    it('Is red an integer', () => {

        let result = rgbToHexColor(10, 10, 'text');
        expect(result).to.be.undefined;
    });

    it('Is red over min range', () => {

        let result = rgbToHexColor(10, 10, -9);
        expect(result).to.be.undefined;
    });

    it('Is red under max range', () => {

        let result = rgbToHexColor(30, 5, 510);
        expect(result).to.be.undefined;
    });

    it('Validate result', () => {

        let result = rgbToHexColor(20, 17, 39);
        expect(result).to.equal('#141127');
    });
});

//task 7

describe('calculator', () => {

    it('Is result object', () => {

        let result = createCalculator();
        expect(typeof result).to.equal('object');
    });

    it('Is add defined', () => {

        let result = createCalculator();
        expect(result).to.haveOwnProperty('add');
    });

    it('Is substract defined', () => {

        let result = createCalculator();
        expect(result).to.haveOwnProperty('subtract');
    });

    it('Is get defined', () => {

        let result = createCalculator();
        expect(result).to.haveOwnProperty('get');
    });

    it('Check result', () => {

        let calc = createCalculator();
        calc.add(10);
        calc.subtract(7);
        let result = calc.get();
        expect(result).to.equal(3);
    });

    it('Check result type', () => {

        let calc = createCalculator();
        calc.add(10);
        calc.subtract(7);
        let result = calc.get();
        expect(typeof result).to.equal('number');
    });
});