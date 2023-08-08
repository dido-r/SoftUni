function solve(input){

    let result = [];

    class Brand{

        constructor(brand){

            this.brand = brand;
            this.carList = [];
        }
    }

    class Car{

        constructor(carBrand, carModel, producedCars){

            this.carBrand = carBrand;
            this.carModel = carModel;
            this.producedCars = producedCars
        }
    }

    for(let item of input){

        let data = item.split(' | ');
        let car = new Car(data[0], data[1], Number(data[2]));
        let currentBrand = result.find(x => x.brand === car.carBrand)

        if(currentBrand === undefined){

            result.push( new Brand(car.carBrand));
            result[result.length - 1].carList.push(car);
        }else{

            let currentModel = currentBrand.carList.find(x => x.carModel === car.carModel);

            if(currentModel === undefined){

                currentBrand.carList.push(car);
            }else{

                currentModel.producedCars += car.producedCars;
            }
        }
    }

    for(let item of result){

        console.log(`${item.brand}`)

        for(let mod of item.carList){

            console.log(`###${mod.carModel} -> ${mod.producedCars}`);
        }
    }
}