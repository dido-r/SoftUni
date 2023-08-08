const { expect, assert } = require('chai');
const { chooseYourCar } = require('./chooseYourCar');

describe("Tests …", function () {

    describe("choosingType", function () {

        it("Year under 1900", function () {

            assert.throws(() => { chooseYourCar.choosingType('combi', 'red', 1898) }, Error, 'Invalid Year!');
        });

        it("Year over 2022", function () {

            assert.throws(() => { chooseYourCar.choosingType('combi', 'red', 2044) }, Error, 'Invalid Year!');
        });

        it("Not e sedan", function () {

            assert.throws(() => { chooseYourCar.choosingType('combi', 'red', 2010) }, Error, 'This type of car is not what you are looking for.');
        });

        it("Sedan over 2010", function () {

            expect(chooseYourCar.choosingType('Sedan', 'red', 2018)).to.equal('This red Sedan meets the requirements, that you have.');
        });

        it("Sedan 2010", function () {

            expect(chooseYourCar.choosingType('Sedan', 'red', 2010)).to.equal('This red Sedan meets the requirements, that you have.');
        });

        it("Sedan under 2010", function () {

            expect(chooseYourCar.choosingType('Sedan', 'red', 2009)).to.equal('This Sedan is too old for you, especially with that red color.');
        });
    });

    describe("brandName", function () {

        it("Brands is not an array", function () {

            assert.throws(() => { chooseYourCar.brandName('not an array', 2) }, Error, 'Invalid Information!');
        });

        it("Index is not a number", function () {

            assert.throws(() => { chooseYourCar.brandName(['Ford', 'Audi'], 'not a number') }, Error, 'Invalid Information!');
        });

        it("Index is not an integer", function () {

            assert.throws(() => { chooseYourCar.brandName(['Ford', 'Audi', 'BMW'], 1.5) }, Error, 'Invalid Information!');
        });

        it("Index is negative", function () {

            assert.throws(() => { chooseYourCar.brandName(['Ford', 'Audi', 'BMW'], -7) }, Error, 'Invalid Information!');
        });

        it("Index is too big", function () {

            assert.throws(() => { chooseYourCar.brandName(['Ford', 'Audi', 'BMW'], 7) }, Error, 'Invalid Information!');
        });

        it("Index is equal to arr length", function () {

            assert.throws(() => { chooseYourCar.brandName(['Ford', 'Audi', 'BMW'], 3) }, Error, 'Invalid Information!');
        });

        it("Valid Index", function () {

            assert.equal(chooseYourCar.brandName(['Ford', 'Audi', 'BMW'], 1), 'Ford, BMW');
        });
    });

    describe("carFuelConsumption", function () {

        it("Distance is not a number", function () {

            assert.throws(() => { chooseYourCar.carFuelConsumption('not a number', 2) }, Error, 'Invalid Information!');
        });

        it("Distance is negative", function () {

            assert.throws(() => { chooseYourCar.carFuelConsumption(-6, 2) }, Error, 'Invalid Information!');
        });

        it("Distance is zero", function () {

            assert.throws(() => { chooseYourCar.carFuelConsumption(0, 2) }, Error, 'Invalid Information!');
        });

        it("Consumptuion is not a number", function () {

            assert.throws(() => { chooseYourCar.carFuelConsumption(5, 'not a number') }, Error, 'Invalid Information!');
        });

        it("Consumptuion is negative", function () {

            assert.throws(() => { chooseYourCar.carFuelConsumption(5, -2) }, Error, 'Invalid Information!');
        });

        it("Consumptuion is zero", function () {

            assert.throws(() => { chooseYourCar.carFuelConsumption(5, 0) }, Error, 'Invalid Information!');
        });

        it("litersPerHundredKm over 7", function () {

            expect(chooseYourCar.carFuelConsumption(20, 2)).to.equal('The car burns too much fuel - 10.00 liters!');
        });

        it("litersPerHundredKm under 7", function () {

            expect(chooseYourCar.carFuelConsumption(100, 2)).to.equal('The car is efficient enough, it burns 2.00 liters/100 km.');
        });

        it("litersPerHundredKm is 7", function () {

            expect(chooseYourCar.carFuelConsumption(100, 7)).to.equal('The car is efficient enough, it burns 7.00 liters/100 km.');
        });
    });
});
