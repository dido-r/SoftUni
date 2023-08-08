class VegetableStore {

    constructor(owner, location) {

        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables = (vegetables) => {

        let resultString = [];

        for (let plant of vegetables) {

            let plantInfo = plant.split(' ');
            let type = plantInfo[0];
            let quantity = Number(plantInfo[1]);
            let price = Number(plantInfo[2]);

            let current = this.availableProducts.find(x => x.type === type);

            if (current == undefined) {

                this.availableProducts.push({
                    type,
                    quantity,
                    price
                });

                resultString.push(type);

            } else {

                current.quantity += quantity;
                current.price = current.price < price ? price : current.price;
            }
        }

        return `Successfully added ${resultString.join(', ')}`;
    }

    buyingVegetables = (selectedProducts) => {

        let totalPrice = 0;

        for (let plant of selectedProducts) {

            let plantInfo = plant.split(' ');
            let type = plantInfo[0];
            let quantity = Number(plantInfo[1]);
            let current = this.availableProducts.find(x => x.type === type);

            if (current == undefined) {

                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            if (current.quantity < quantity) {

                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            totalPrice += quantity * current.price;
            current.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable = (type, quantity) => {

        let current = this.availableProducts.find(x => x.type === type);

        if (current == undefined) {

            throw new Error(`${type} is not available in the store.`);
        }

        if (current.quantity < quantity) {

            current.quantity = 0;

            return `The entire quantity of the ${type} has been removed.`
        }

        current.quantity -= quantity;

        return `Some quantity of the ${type} has been removed.`
    }

    revision = () => {

        let result = 'Available vegetables:\n';

        for (let plant of this.availableProducts.sort((a, b) => a.price - b.price)) {

            result += `${plant.type}-${plant.quantity}-$${plant.price}\n`
        }

        result += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;

        return result;
    }
}