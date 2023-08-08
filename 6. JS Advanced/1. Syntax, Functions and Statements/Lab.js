//task 1

function echo (input) {

    console.log(input.length)
    console.log(input)
}

//task 2

function stringLength (...params) {
    let textLength = 0;

    for (let i = 0; i < params.length; i++){
        textLength += params[i].length;
    }

    console.log(textLength)
    console.log(Math.floor(textLength/params.length))
}

// task 3

function largest (...params) {
    
    console.log(`The largest number is ${Math.max(...params)}.`)
}

// task 4

function area (input) {
    
    let result = typeof input !== "number" ? `We can not calculate the circle area, because we receive a ${typeof input}.` : (input * input * Math.PI).toFixed(2);
    console.log(result)
}

// task 5

function math (num1, num2, symbol) {
    
    let result = 0;

    if(symbol === '+'){
        result = num1 + num2
    }else if(symbol === '-'){
        result = num1 - num2
    }else if(symbol === '*'){
        result = num1 * num2
    }else if(symbol === '/'){
        result = num1 / num2
    }else if(symbol === '%'){
        result = num1 % num2
    }else if(symbol === '**'){
        result = num1 ** num2
    }

    console.log(result);
}

// task 6

function sum (x , y){

    let result = 0;

    for(let i = Number(x); i <= Number(y); i++){
        result += i;
    }

    console.log(result);
}

//task 7

function dayOfTheWeek(day){

        switch(day){
        case 'Monday': console.log(1); break;
        case 'Tuesday': console.log(2); break;
        case 'Wednesday': console.log(3); break;
        case 'Thursday': console.log(4); break;
        case 'Friday': console.log(5); break;
        case 'Saturday': console.log(6); break;
        case 'Sunday': console.log(7); break;
        default: console.log('error'); break;
    }
}

// task 8

function days(month, year){

    let date = new Date(year, month, 0);
    console.log(date.getDate());
    }

// task 9

function square(size = 5){
    
    for(let i = 0; i < size; i++){

        let row = '';
        
            for(let j = 0; j < size; j++){

                row += '*' + ' ';
            }

            console.log(row);
        }
    }

   // task 10

   function aggregate (array){

    let sum = 0;
    let inverseSum = 0;
    let string = '';

        for(let i = 0; i < array.length; i++){

                sum += array[i];
                inverseSum += 1/array[i];
                string += array[i];
        }

        console.log(sum);
        console.log(inverseSum);
        console.log(string);
   }