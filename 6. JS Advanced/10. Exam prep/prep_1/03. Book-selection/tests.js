const { expect, assert } = require('chai');
const { bookSelection } = require('./solution');

describe("Tests …", function () {

    describe("isGenreSuitable", function () {

        it("Check with Thriller and underage", function () {

            expect(bookSelection.isGenreSuitable('Thriller', 8)).to.equal('Books with Thriller genre are not suitable for kids at 8 age');
        });

        it("Check with Horror and underage", function () {

            expect(bookSelection.isGenreSuitable('Horror', 9)).to.equal('Books with Horror genre are not suitable for kids at 9 age');
        });

        it("Check with Thriller and over required age", function () {

            expect(bookSelection.isGenreSuitable('Thriller', 14)).to.equal('Those books are suitable');
        });

        it("Check with Horror and over required age", function () {

            expect(bookSelection.isGenreSuitable('Horror', 21)).to.equal('Those books are suitable');
        });
    });

    describe("isItAffordable", function () {

        it("Invalid price", function () {

            assert.throws(() => { bookSelection.isItAffordable('not a number', 50) }, Error, "Invalid input");
        });

        it("Invalid budget", function () {

            assert.throws(() => { bookSelection.isItAffordable(22, 'not a number') }, Error, "Invalid input");
        });

        it("Not enough money", function () {

            expect(bookSelection.isItAffordable(22, 19)).to.equal("You don't have enough money");
        });

        it("More money than budget", function () {

            expect(bookSelection.isItAffordable(22, 50)).to.equal("Book bought. You have 28$ left");
        });

        it("Money equal to budget", function () {

            expect(bookSelection.isItAffordable(50, 50)).to.equal("Book bought. You have 0$ left");
        });
    });

    describe("suitableTitles", function () {

        it("Array not array", function () {

            assert.throws(() => { bookSelection.suitableTitles('not an array', 'this book') }, Error, "Invalid input");
        });

        it("wantedGenre not a string", function () {

            assert.throws(() => { bookSelection.suitableTitles([{ title: "The Da Vinci Code", genre: "Thriller" }], 666) }, Error, "Invalid input");
        });

        it("chech with valid params", function () {

            let array = [
                { title: "The Da Vinci Code", genre: "Thriller" },
                { title: "Necronomicon", genre: "Horror" },
                { title: "test tittle", genre: "some genre" },
            ];
            expect(bookSelection.suitableTitles(array, 'Thriller')).to.have.length(1);
        });
    });
});
