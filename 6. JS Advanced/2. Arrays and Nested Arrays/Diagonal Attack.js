function diagonalAttack(input) {

    let matrix = [];

    for (let i = 0; i < input.length; i++) {

        let row = input[i].split(' ');
        matrix[i] = row;

        for (let j = 0; j < row.length; j++) {

            matrix[i][j] = Number(row[j]);
        }
    }

    let sum1 = 0;
    let sum2 = 0;
    let firstDiagonal = [];
    let secondDiagonal = [];

    for (let i = 0; i < matrix.length; i++) {

        sum1 += matrix[i][i];
        firstDiagonal[i] = matrix[i][i];
        sum2 += matrix[i][matrix.length - 1 - i];
        secondDiagonal[i] = matrix[i][matrix.length - 1 - i];
    }

    if (sum1 === sum2) {

        for (let i = 0; i < matrix.length; i++) {

            for (let j = 0; j < matrix[i].length; j++) {

                matrix[i][j] = sum1;
            }

            matrix[i][i] = firstDiagonal[i];
            matrix[i][matrix.length - 1 - i] =  secondDiagonal[i];
        }
    }

    for (let i = 0; i < matrix.length; i++) {

        console.log(matrix[i].join(' '));
    }
}