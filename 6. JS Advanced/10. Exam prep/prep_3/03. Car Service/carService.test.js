const { expect, assert } = require('chai');
const { carService } = require('./03. Car Service_Resources');

describe("Tests …", function () {

    describe("isItExpensive", function () {

        it("If issue is Engine", function () {

            expect(carService.isItExpensive('Engine')).to.equal('The issue with the car is more severe and it will cost more money');
        });

        it("If issue is Transmission", function () {

            expect(carService.isItExpensive('Transmission')).to.equal('The issue with the car is more severe and it will cost more money');
        });

        it("If issue is other", function () {

            expect(carService.isItExpensive('Brakes')).to.equal('The overall price will be a bit cheaper');
        });
    });

    describe("discount", function () {

        it("If numberOfParts is not a number", function () {

            assert.throws(() => { carService.discount('not a number', 100) }, Error, 'Invalid input');
        });

        it("If totalAmount is not a number", function () {

            assert.throws(() => { carService.discount(4, 'not a number') }, Error, 'Invalid input');
        });

        it("If both params are not a number", function () {

            assert.throws(() => { carService.discount('not a number', 'also not a number') }, Error, 'Invalid input');
        });

        it("If numberOfParts is under 2", function () {

            expect(carService.discount(1, 10)).to.equal('You cannot apply a discount');
        });

        it("If numberOfParts is 2", function () {

            expect(carService.discount(2, 10)).to.equal('You cannot apply a discount');
        });

        it("If numberOfParts is greater than 2 but smaller than 7", function () {

            expect(carService.discount(6, 10)).to.equal('Discount applied! You saved 1.5$');
        });

        it("If numberOfParts is 7", function () {

            expect(carService.discount(7, 10)).to.equal('Discount applied! You saved 1.5$');
        });

        it("If numberOfParts is greater than 7", function () {

            expect(carService.discount(9, 10)).to.equal('Discount applied! You saved 3$');
        });
    });

    describe("partsToBuy", function () {

        it("Array is not array first param", function () {

            assert.throws(() => { carService.partsToBuy('not an array', ["blowoff valve", "injectors"]) }, Error, 'Invalid input');
        });

        it("Array is not array second param", function () {

            assert.throws(() => { carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }], 'not an array') }, Error, 'Invalid input');
        });

        it("Array is not array both param", function () {

            assert.throws(() => { carService.partsToBuy('not an array', 'not an array') }, Error, 'Invalid input');
        });

        it("If first param is empty array", function () {

            assert.equal(carService.partsToBuy([], ["blowoff valve", "injectors"]), 0);
        });

        it("If second param is empty array", function () {

            assert.equal(carService.partsToBuy([{ part: "blowoff valve", price: 145 }], []), 0);
        });

        it("Valid params with match in params", function () {

            assert.equal(carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "injectors", price: 230 }], ["blowoff valve", "injectors"]), 375);
        });

        it("Valid params but no match in params", function () {

            assert.equal(carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "injectors", price: 230 }], ["coil springs", "breaks"]), 0);
        });
    });
});