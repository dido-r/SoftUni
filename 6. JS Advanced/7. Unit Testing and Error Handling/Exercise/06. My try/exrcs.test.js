const { isOddOrEven, lookupChar, mathEnforcer } = require('./exrcs');
const { expect } = require('chai');
const { assert } = require('chai');

//task 2
describe('isOddOrEven', () => {

    it('is input valid', () => {

        expect(isOddOrEven([1, 2, 3])).to.be.undefined;
    });

    it('is result even', () => {

        expect(isOddOrEven('Imeven')).to.equal('even');
    });

    it('is result odd', () => {

        expect(isOddOrEven('Imodd')).to.equal('odd');
    });
});

//task3

describe('lookupChar', () => {

    it('is input string valid', () => {

        expect(lookupChar([1, 2, 3], 2)).to.be.undefined;
    });

    it('is input number valid', () => {

        expect(lookupChar('test', 'im not an integer')).to.be.undefined;
    });

    it('is input number not a float', () => {

        expect(lookupChar('test and more test', 4.99)).to.be.undefined;
    });

    it('is index over start index', () => {

        assert.equal(lookupChar('test', -2), 'Incorrect index');
    });

    it('is index under last index', () => {

        assert.equal(lookupChar('test', 9), 'Incorrect index');
    });

    it('is result correct', () => {

        assert.equal(lookupChar('Lets have some correct input', 6), 'a');
    });
});

//task4
describe('mathEnforcer', () => {

    it('Test addFive func with non-number input', () => {

        assert.equal(mathEnforcer.addFive('im not a number'), undefined);
    });

    it('Test addFive func with positive number input', () => {

        assert.equal(mathEnforcer.addFive(11), 16);
    });

    it('Test addFive func with negative number input', () => {

        assert.equal(mathEnforcer.addFive(-7), -2);
    });

    it('Test addFive func with float number input', () => {

        let result = mathEnforcer.addFive(11.2);
        expect(result).to.be.closeTo(16.2, 0.00001);
    });

    it('Test subtractTen func with non-number input', () => {

        assert.equal(mathEnforcer.subtractTen('im not a number'), undefined);
    });

    it('Test subtractTen func with positive number input', () => {

        assert.equal(mathEnforcer.subtractTen(11), 1);
    });

    it('Test subtractTen func with negative number input', () => {

        assert.equal(mathEnforcer.subtractTen(-7), -17);
    });

    it('Test subtractTen func with float number input', () => {

        let result = mathEnforcer.subtractTen(11.28);
        expect(result).to.be.closeTo(1.28, 0.00001);
    });

    it('Test sum func with non-number first input', () => {

        assert.equal(mathEnforcer.sum('im not a number', 10), undefined);
    });

    it('Test sum func with non-number second input', () => {

        assert.equal(mathEnforcer.sum(10, 'im not a number'), undefined);
    });

    it('Test sum func with non-number both input', () => {

        assert.equal(mathEnforcer.sum('im not a number', 'im not a number too'), undefined);
    });

    it('Test sum func with positive number input', () => {

        assert.equal(mathEnforcer.sum(11, 20), 31);
    });

    it('Test sum func with negative number input', () => {

        assert.equal(mathEnforcer.sum(-7, -9), -16);
    });

    it('Test sum func with float number input', () => {

        let result = mathEnforcer.sum(11.28, 3.41);
        expect(result).to.be.closeTo(14.69, 0.00001);
    });
});