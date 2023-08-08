//task 1

function fruit (fruitType, weight, pricePerKg){

    let weightInKg = weight / 1000;
    console.log(`I need $${(weightInKg * pricePerKg).toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruitType}.`);
}

// task 2

function GCD (num1, num2){

    let max = Math.min(num1, num2);
    let result = 0;

    for(let i = max; i >= 1; i--){

        if (num1 % i === 0 && num2 % i === 0){
            result = i;
            break;
        }
    }

    console.log(result)
}

// task 3

function sameNumber (number) {

    let isSame = true;
    var input = number.toString();
    var length = number.toString().length;
    let sum = 0;

    for(let i = 0; i < length - 1; i++){

        if (input[i] !== input[i + 1]){
            
            isSame = false;
        }
        
        sum += Number(input[i]);
    }

    sum += Number(input[length - 1]);

    if(isSame){

        console.log(true);
        console.log(sum);
    }else{
        console.log(false);
        console.log(sum);
    }
}

// task 4

function previousDay(year, month, day){

    let date = new Date(year, month - 1, day);
    date.setDate(date.getDate() - 1);
       
    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`)
}

// task 5

function walkTime(steps, footprintLength, speed){
    
    var distance = steps * footprintLength;
    let rest = Math.floor(distance / 500);
    let time = distance/ 1000 / speed + rest / 60;
    let hour = Math.floor(time);
    let minute = Math.floor(60 * time);
    let seconds = Math.round(60 * time % minute * 60);

    hour = hour < 10 ? hour.toString().padStart(2, '0') : hour;
    minute = minute < 10 ? minute.toString().padStart(2, '0') : minute;
    seconds = seconds < 10 ? seconds.toString().padStart(2, '0') : seconds;

    console.log(`${hour}:${minute}:${seconds}`);
}

// task 6

function speedLimit(speed, area){

    let limit = 0;

    switch(area){

        case 'motorway': limit = 130; break;
        case 'interstate': limit = 90; break;
        case 'city': limit = 50; break;
        case 'residential': limit = 20; break;
    }

    let difference = speed - limit;

    if(difference <= 0){

        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }else{

        let status = '';

        if(difference <= 20){

            status = 'speeding';

        }else if(difference <= 40){

            status = 'excessive speeding';

        }else{

            status = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
}

// task 7

function cooking (...params){

    let number = Number(params[0]);

    for(let i = 1; i < params.length; i++){

        switch(params[i]){
            case 'chop': number /= 2; break;
            case 'dice': number = Math.sqrt(number); break;
            case 'spice': number += 1; break;
            case 'bake': number *= 3; break;
            case 'fillet': number *= 0.8; break;
        }

        console.log(number);
    }
} 

// task 8

function isValid(x1, y1, x2, y2){

    let firstPoint = Math.sqrt(Math.pow((x1), 2) + Math.pow(y1, 2));
    let secondPoint = Math.sqrt(Math.pow((x2), 2) + Math.pow(y2, 2));
    let betwennPoints = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));

    if(Number.isInteger(firstPoint)){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(secondPoint)){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(betwennPoints)){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

// task 9

function uppercase(text){

    const pattern = /[\W\s]+/;
    let array = text.split(pattern);
    array = array.filter(x => x);
    
    
    for(let i = 0; i < array.length; i++){

        array[i] = ' ' + array[i].toUpperCase();
    }
    
    console.log(array.toString().trim());
}