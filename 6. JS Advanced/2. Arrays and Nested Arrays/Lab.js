// task 1

function evenPosition(array){

    console.log(array
        .filter((x , i) => i % 2 === 0 )
        .join(' '));
}

// task 2

function numbersSequence(n, k){
    
    let array = [1];
    let current = [1];
    
    for(let i = 1; i < n; i++){

        if(i <= k){

            current = array.slice(0, i + 1)
        }else{
            current = array.slice(i - k, i);
        };

        let sum = 0;
        
        for (let number of current){

            sum += number;
        };

        array[i] = sum;
    }
    
    return array;
}

// task 3

function sumFirstLast(array){

    return Number(array.shift()) + Number(array.pop());
}

// task 4

function sort(array){

    let result = [];

    for(let i = 0; i < array.length; i++){

        if(array[i] >= 0){

            result.push(array[i]);
        }else{

            result.unshift(array[i]);
        }
    }

    console.log(result.join('\n'));
}

// task 5

function smallest(array){

    let result = array
        .sort((a, b) => a - b)
        .slice(0, 2);

    console.log(result.join(' '));
}

//task 6

function biggerHalf(array){

    let result = array
        .sort((a, b) => a - b)
        .slice(array.length / 2, array.length);

    return result;
}

//task 7

function pie(array, flavour1, flavour2){
    
    return array.slice(array.indexOf(flavour1), array.indexOf(flavour2) + 1);
}

// task 8

function odd(array){

    return array.filter((n , i) => i % 2 !== 0)
                .map(x => x * 2)
                .reverse();
}

// task 9

function biggestElement(array){

    let result = Number.MIN_SAFE_INTEGER;

    for (let arr of array){
        
        for (let number of arr){
            
            if(number > result){
                result = number;
            }
        }
    }

    return result;
}

// task 10

function diagonalSum(array){

    let sum1 = 0;
    let sum2 = 0;

    for (let i = 0; i < array.length; i++){

        sum1 += array[i][i];
        sum2 += array[i][array.length - 1 - i];
    }

    console.log(sum1 + ' ' + sum2);
}

//task 11

function equal(array){

    let sumOfPairs = 0;

    function inRange(row, col){

        return row >= 0 && row < array.length && col >= 0 && col < array[row].length;
    }

    for (let i = 0; i < array.length; i++){

        for (let j = 0; j < array[i].length; j++){

           if(inRange(i, j + 1)){
            
                if(array[i][j] === array[i][j + 1]){

                    sumOfPairs++;
                }
            }
            if(inRange(i + 1, j)){
            
                if(array[i][j] === array[i + 1][j]){

                    sumOfPairs++;
                }
            }
        }
    }

    return sumOfPairs;
}