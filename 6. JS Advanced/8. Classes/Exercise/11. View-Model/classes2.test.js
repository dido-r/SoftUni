const { StringBuilder } = require('../task13');
const { expect } = require('chai');
const { assert } = require('chai');

describe("ctor", () => {

    it("Check if input is not a string", () => {

        assert.throws(() => { new StringBuilder(123) }, TypeError, "Argument must be a string");
    });

    it("Check if input is not a string with bool", () => {

        assert.throws(() => { new StringBuilder(false) }, TypeError, "Argument must be a string");
    });

    it("Check length if input is undefined", () => {

        let test = new StringBuilder(undefined)
        expect(test._stringArray).to.have.length(0);
    });

    it("Check length if input is epmpty string", () => {

        let test = new StringBuilder('')
        expect(test._stringArray).to.have.length(0);
    });

    it("Check length if input is epmpty", () => {

        let test = new StringBuilder()
        expect(test._stringArray).to.have.length(0);
    });

    it("Check index if input is undefined", () => {

        let test = new StringBuilder(undefined)
        expect(test._stringArray[2]).to.be.undefined;
    });

    it("Check length with valid input", () => {

        let test = new StringBuilder('some')
        expect(test._stringArray).to.have.length(4);
    });

    it("Check index with valid input", () => {

        let test = new StringBuilder('some')
        expect(test._stringArray[2]).to.equal('m');
    });

    it("Check class", () => {

        let test = new StringBuilder('some')
        expect(test).is.instanceof(StringBuilder);
    });
});

describe("append", () => {

    it("Check length with valid params", () => {

        let test = new StringBuilder('test');
        test.append('helix');
        expect(test._stringArray).to.have.length(9);
    });

    it("Check index with valid params", () => {

        let test = new StringBuilder('test');
        test.append('helix');
        expect(test._stringArray[8]).to.equal('x');
    });
});

describe("prepend", () => {

    it("Check length with valid params", () => {

        let test = new StringBuilder('test');
        test.prepend('lets make a ');
        expect(test._stringArray).to.have.length(16);
    });

    it("Check index with valid params", () => {

        let test = new StringBuilder('test');
        test.prepend('lets make a ');
        expect(test._stringArray[3]).to.equal('s');
    });
});

describe("insertAt", () => {

    it("Check length with valid input", () => {

        let test = new StringBuilder('test');
        test.insertAt('again', 1);
        expect(test._stringArray).to.have.length(9);
    });

    it("Check index with valid input", () => {

        let test = new StringBuilder('test');
        test.insertAt('again', 1);
        expect(test._stringArray[4]).to.equal('i');
    });
});

describe("remove", () => {

    it("Check length with valid args", () => {

        let test = new StringBuilder('some test');
        test.remove(2, 2);
        expect(test._stringArray).to.have.length(7);
    });

    it("Check index with valid args", () => {

        let test = new StringBuilder('some test');
        test.remove(2, 2);
        expect(test._stringArray[3]).to.equal('t');
    });
});

describe("toString", () => {

    it("Check return value", () => {

        let test = new StringBuilder('test');
        assert.equal(test.toString(), 'test');
    });
});

describe("props", () => {

    it("Chech for properties", () => {
        
        let test = new StringBuilder('test');
        expect(test).to.haveOwnProperty('_stringArray');
        expect(test).to.have.property('append');
        expect(test.append).to.be.a('function');
        expect(test).to.have.property('prepend');
        expect(test.prepend).to.be.a('function');
        expect(test).to.have.property('insertAt');
        expect(test.insertAt).to.be.a('function');
        expect(test).to.have.property('remove');
        expect(test.remove).to.be.a('function');
        expect(test).to.have.property('toString');
        expect(test.toString).to.be.a('function');
        expect(StringBuilder).to.have.property('_vrfyParam');
        expect(StringBuilder._vrfyParam).to.be.a('function');
   });
});