function solve(input) {

    let result = [];

    class Juice {
        
        constructor(name, quantity) {

            this.name = name;
            this.quantity = quantity
        }
    }

    let index = 1;

    for(let item of input){

        let juiceInfo = item.split(' => ');
        let juice = new Juice(juiceInfo[0], Number(juiceInfo[1]))
        let current = result.find(x => x.name === juice.name);

        if(current === undefined){

            juice.rank = juice.quantity >= 1000 ? index++ : 0;
            result.push(juice);
        }else{

            current.quantity += juice.quantity;
            current.rank = current.quantity >= 1000 && current.rank === 0 ? index++ : current.rank;
        }
    }

    result.forEach(x => x.bottle = Math.floor(x.quantity / 1000));
    result = result.filter(x => x.bottle !== 0).sort((a, b) => a.rank - b.rank);
    result.forEach(x => console.log(`${x.name} => ${x.bottle}`));
}