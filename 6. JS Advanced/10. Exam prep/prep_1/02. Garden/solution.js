class Garden {

    constructor(spaceAvailable) {

        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant = (plantName, spaceRequired) => {

        if (spaceRequired > this.spaceAvailable) {

            throw new Error('Not enough space in the garden.');
        }

        this.plants.push({
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        });

        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant = (plantName, quantity) => {

        let currentPlant = this.plants.find(x => x.plantName === plantName);

        if (currentPlant == undefined) {

            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (currentPlant.ripe) {

            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {

            throw new Error('The quantity cannot be zero or negative.');
        }

        currentPlant.ripe = true;
        currentPlant.quantity += quantity;

        return quantity === 1 ? `${quantity} ${plantName} has successfully ripened.` : `${quantity} ${plantName}s have successfully ripened.`;
    }

    harvestPlant = (plantName) => {

        let currentPlant = this.plants.find(x => x.plantName === plantName);

        if (currentPlant == undefined) {

            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (!currentPlant.ripe) {

            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.spaceAvailable += currentPlant.spaceRequired;
        this.plants = this.plants.filter(x => x.plantName !== plantName);
        this.storage.push({
            plantName,
            quantity: currentPlant.quantity
        });

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport = () => {

        let result = `The garden has ${this.spaceAvailable} free space left.\n`;
        result += `Plants in the garden: ${this.plants.map(x => x.plantName).sort((a, b) => a.localeCompare(b)).join(', ')}\n`;

        if (this.storage.length === 0) {

            result += 'Plants in storage: The storage is empty.';
        } else {

            result += 'Plants in storage: ';

            for (let plant of this.storage) {

                result += `${plant.plantName} (${plant.quantity}), `;
            }

            result = result.slice(0, result.length - 2);
        }

        return result;
    }
}