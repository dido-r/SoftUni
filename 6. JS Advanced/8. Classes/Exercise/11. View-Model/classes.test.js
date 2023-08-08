const { PaymentPackage } = require('../task12');
const { expect } = require('chai');
const { assert } = require('chai');

describe("name", () => {

    it("Is type string", () => {
        
        assert.throws(() => {new PaymentPackage(123, 100)}, Error, "Name must be a non-empty string");
    });

    it("Is type string - test with bool", () => {
        
        assert.throws(() => {new PaymentPackage(false, 100)}, Error, "Name must be a non-empty string");
    });

    it("Is lenght greater than 0", () => {
        
        assert.throws(() => {new PaymentPackage('', 100)}, Error, "Name must be a non-empty string");
    });
    
    it("Test with valid name", () => {
        
        let test = new PaymentPackage('SomeMoreTest', 100)
        expect(test.name).to.be.equal('SomeMoreTest');
    });   
});


describe("value", () => {

    it("Is type number", () => {
        
        assert.throws(() => {new PaymentPackage('TEST', 'not a number')}, Error, "Value must be a non-negative number");
    });

    it("Is value greater than 0", () => {
        
        assert.throws(() => {new PaymentPackage('TEST', -5)}, Error, "Value must be a non-negative number");
    });

    it("Test with valid value", () => {
        
        let test = new PaymentPackage('SomeMoreTest', 100)
        expect(test.value).to.be.equal(100);
    });

    it("Test with zero", () => {
        
        let test = new PaymentPackage('SomeMoreTest', 0)
        expect(test.value).to.be.equal(0);
    });

    it("Test with valid float value", () => {
        
        let test = new PaymentPackage('SomeMoreTest', 11.6)
        expect(test.value).to.be.equal(11.6);
    });
});

describe("VAT", () => {

    it("Is type number", () => {
        
        let test = new PaymentPackage('TEST', 100);
        assert.throws(() => {test.VAT = 'not a number'}, Error, "VAT must be a non-negative number");
    });

    it("Is VAT greater than 0", () => {
        
        let test = new PaymentPackage('TEST', 100);
        assert.throws(() => {test.VAT = -9}, Error, "VAT must be a non-negative number");
    });

    it("Is VAT valid when 0", () => {
        
        let test = new PaymentPackage('TEST', 100);
        test.VAT = 0;
        expect(test.VAT).to.be.equal(0);
    });

    it("Test with valid VAT", () => {
        
        let test = new PaymentPackage('SomeMoreTest', 100)
        expect(test.VAT).to.be.equal(20);
    });   
});

describe("active", () => {

    it("Is invalid type throw Error", () => {
        
        let test = new PaymentPackage('TEST', 100);
        assert.throws(() => {test.active = 'not a boolean'}, Error, "Active status must be a boolean");
    });

    it("check with valid type", () => {
        
        let test = new PaymentPackage('TEST', 100);
        expect(test.active).to.be.true;
    });

    it("Test with changing active status", () => {
        
        let test = new PaymentPackage('SomeMoreTest', 100);
        test.active = false;
        expect(test.active).to.be.false;
    });   
});

describe("toString", () => {

    it("Chech toString return value", () => {
        
        let test = new PaymentPackage('TEST', 100);
        assert.equal(test.toString(), 'Package: TEST\n- Value (excl. VAT): 100\n- Value (VAT 20%): 120')
    });

    it("Chech toString return value with inactive", () => {
        
        let test = new PaymentPackage('TEST', 100);
        test.active = false;
        assert.equal(test.toString(), 'Package: TEST (inactive)\n- Value (excl. VAT): 100\n- Value (VAT 20%): 120')
    });
});

describe("props", () => {

    it("Chech for properties", () => {
        
        let test = new PaymentPackage('TEST', 100);
        expect(test).to.haveOwnProperty('_name');
        expect(test).to.haveOwnProperty('_value');
        expect(test).to.haveOwnProperty('_VAT');
        expect(test).to.haveOwnProperty('_active');
        expect(test).to.have.property('toString');
        expect(test.toString).to.be.a('function');
   });
});