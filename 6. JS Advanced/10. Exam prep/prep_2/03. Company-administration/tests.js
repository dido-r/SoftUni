const { expect, assert } = require('chai');
const { companyAdministration } = require('./companyAdministration');

describe("Tests …", function () {

    describe("hiringEmployee", function () {

        it("Not a programmer", function () {

            assert.throws(() => { companyAdministration.hiringEmployee('Dido', 'tiradjiq', 3) }, Error, 'We are not looking for workers for this position.');
        });

        it("Not enough exp", function () {

            expect(companyAdministration.hiringEmployee('Dido', 'Programmer', 1)).to.equal('Dido is not approved for this position.');
        });

        it("Have enough exp", function () {

            expect(companyAdministration.hiringEmployee('Dido', 'Programmer', 4)).to.equal('Dido was successfully hired for the position Programmer.');
        });

        it("Have enough exp - float", function () {

            expect(companyAdministration.hiringEmployee('Dido', 'Programmer', 4.5)).to.equal('Dido was successfully hired for the position Programmer.');
        });

        it("Have equal exp", function () {

            expect(companyAdministration.hiringEmployee('Dido', 'Programmer', 3)).to.equal('Dido was successfully hired for the position Programmer.');
        });
    });

    describe("calculateSalary", function () {

        it("Hours not a number", function () {

            assert.throws(() => { companyAdministration.calculateSalary('not a number') }, Error, 'Invalid hours');
        });

        it("Negative hours", function () {

            assert.throws(() => { companyAdministration.calculateSalary(-5) }, Error, 'Invalid hours');
        });

        it("Hours greater than 160", function () {

            expect(companyAdministration.calculateSalary(210)).to.equal(4150);
        });

        it("Valid hours under 160", function () {

            expect(companyAdministration.calculateSalary(70)).to.equal(1050);
        });

        it("Hours are 160", function () {

            expect(companyAdministration.calculateSalary(160)).to.equal(2400);
        });

        it("Zero hours", function () {

            expect(companyAdministration.calculateSalary(0)).to.equal(0);
        });

        it("Float hours", function () {

            expect(companyAdministration.calculateSalary(10.5)).to.equal(157.5);
        });
    });

    describe("firedEmployee", function () {

        it("Array is no array", function () {

            assert.throws(() => { companyAdministration.firedEmployee('not an array', 10) }, Error, 'Invalid input');
        });

        it("Index is not a number", function () {

            assert.throws(() => { companyAdministration.firedEmployee(['Pesho', 'Ivo', 'Stankata'], 'not a number') }, Error, 'Invalid input');
        });

        it("Index is not an integer", function () {

            assert.throws(() => { companyAdministration.firedEmployee(['Pesho', 'Ivo', 'Stankata'], 2.5) }, Error, 'Invalid input');
        });

        it("Negative Index", function () {

            assert.throws(() => { companyAdministration.firedEmployee(['Pesho', 'Ivo', 'Stankata'], -7) }, Error, 'Invalid input');
        });

        it("Too big index", function () {

            assert.throws(() => { companyAdministration.firedEmployee(['Pesho', 'Ivo', 'Stankata'], 7) }, Error, 'Invalid input');
        });

        it("Index equal to array length", function () {

            assert.throws(() => { companyAdministration.firedEmployee(['Pesho', 'Ivo', 'Stankata'], 3) }, Error, 'Invalid input');
        });

        it("Empty array and zero index", function () {

            assert.throws(() => { companyAdministration.firedEmployee([], 0) }, Error, 'Invalid input');
        });

        it("Check result with valid params", function () {

            expect(companyAdministration.firedEmployee(['Pesho', 'Ivo', 'Stankata'], 2)).to.equal('Pesho, Ivo');
        });
    });
});