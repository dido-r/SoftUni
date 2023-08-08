function solution() {

    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    return function (input) {

        let command = input.split(' ');
        let firstFailed = 'none';

        if (command[0] === 'restock') {

            switch (command[1]) {

                case 'protein': ingredients.protein += Number(command[2]); break;
                case 'carbohydrate': ingredients.carbohydrate += Number(command[2]); break;
                case 'fat': ingredients.fat += Number(command[2]); break;
                case 'flavour': ingredients.flavour += Number(command[2]); break;
            }

            return 'Success';

        } else if (command[0] === 'prepare') {

            if (checkIngredients(command[1], Number(command[2]))) {

                reduceIngredients(command[1], Number(command[2]))
                return 'Success';

            } else {

                return `Error: not enough ${firstFailed} in stock`;
            }
        } else if (command[0] === 'report') {

            return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`;
        }

        function checkIngredients(food, quantity) {

            if (food === 'apple') {

                if (ingredients.carbohydrate < 1 * quantity) { firstFailed = 'carbohydrate'; return false; }
                if (ingredients.flavour < 2 * quantity) { firstFailed = 'flavour'; return false; }
                return true;

            } else if (food === 'lemonade') {

                if (ingredients.carbohydrate < 10 * quantity) { firstFailed = 'carbohydrate'; return false; }
                if (ingredients.flavour < 20 * quantity) { firstFailed = 'flavour'; return false; }
                return true;

            } else if (food === 'burger') {

                if (ingredients.carbohydrate < 5 * quantity) { firstFailed = 'carbohydrate'; return false; }
                if (ingredients.fat < 7 * quantity) { firstFailed = 'fat'; return false; }
                if (ingredients.flavour < 3 * quantity) { firstFailed = 'flavour'; return false; }
                return true;

            } else if (food === 'eggs') {

                if (ingredients.protein < 5 * quantity) { firstFailed = 'protein'; return false; }
                if (ingredients.fat < 1 * quantity) { firstFailed = 'fat'; return false; }
                if (ingredients.flavour < 1 * quantity) { firstFailed = 'flavour'; return false; }
                return true;

            } else if (food === 'turkey') {

                if (ingredients.protein < 10 * quantity) { firstFailed = 'protein'; return false; }
                if (ingredients.carbohydrate < 10 * quantity) { firstFailed = 'carbohydrate'; return false; }
                if (ingredients.fat < 10 * quantity) { firstFailed = 'fat'; return false; }
                if (ingredients.flavour < 10 * quantity) { firstFailed = 'flavour'; return false; }
                return true;
            }
        }

        function reduceIngredients(food, quantity) {

            if (food === 'apple') {

                ingredients.carbohydrate -= (1 * quantity);
                ingredients.flavour -= (2 * quantity);

            } else if (food === 'lemonade') {

                ingredients.carbohydrate -= (10 * quantity);
                ingredients.flavour -= (20 * quantity);

            } else if (food === 'burger') {

                ingredients.carbohydrate -= (5 * quantity);
                ingredients.fat -= (7 * quantity);
                ingredients.flavour -= (3 * quantity);

            } else if (food === 'eggs') {

                ingredients.protein -= (5 * quantity);
                ingredients.fat -= (1 * quantity);
                ingredients.flavour -= (1 * quantity);

            } else if (food === 'turkey') {

                ingredients.protein -= (10 * quantity);
                ingredients.carbohydrate -= (10 * quantity);
                ingredients.fat -= (10 * quantity);
                ingredients.flavour -= (10 * quantity);
            }
        }
    }
}