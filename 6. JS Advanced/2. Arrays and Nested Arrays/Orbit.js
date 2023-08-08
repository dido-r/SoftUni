function solve(input) {

    let matrix = [];

    for (let i = 0; i < input[1]; i++) {

        matrix[i] = [];

        for (let j = 0; j < input[0]; j++) {

            matrix[i][j] = false;
        }
    }

    matrix[input[2]][input[3]] = 1;

    function isFull(array) {

        for (let i = 0; i < array.length; i++) {

            for (let j = 0; j < array[i].length; j++) {

                if (array[i][j] === false) {

                    return false;
                }
            }
        }

        return true;
    }

    function inRange(row, col, array) {

        return row >= 0 && row < array.length && col >= 0 && col < array[row].length;
    }
    let number = 1;

    while (!isFull(matrix)) {

        for (let i = 0; i < matrix.length; i++) {

            for (let j = 0; j < matrix[i].length; j++) {

                if (matrix[i][j] === number) {

                    if (inRange(i - 1, j - 1, matrix) && matrix[i - 1][j - 1] === false) {

                        matrix[i - 1][j - 1] = number + 1;
                    }
                    if (inRange(i - 1, j, matrix) && matrix[i - 1][j] === false) {

                        matrix[i - 1][j] = number + 1;
                    }
                    if (inRange(i - 1, j + 1, matrix) && matrix[i - 1][j + 1] === false) {

                        matrix[i - 1][j + 1] = number + 1;
                    }
                    if (inRange(i, j - 1, matrix) && matrix[i][j - 1] === false) {

                        matrix[i][j - 1] = number + 1;
                    }
                    if (inRange(i, j + 1, matrix) && matrix[i][j + 1] === false) {

                        matrix[i][j + 1] = number + 1;
                    }
                    if (inRange(i + 1, j - 1, matrix) && matrix[i + 1][j - 1] === false) {

                        matrix[i + 1][j - 1] = number + 1;
                    }
                    if (inRange(i + 1, j, matrix) && matrix[i + 1][j] === false) {

                        matrix[i + 1][j] = number + 1;
                    }
                    if (inRange(i + 1, j + 1, matrix) && matrix[i + 1][j + 1] === false) {

                        matrix[i + 1][j + 1] = number + 1;
                    }
                }
            }
        }

        number++;
    }

    for (let i = 0; i < matrix.length; i++) {

        console.log(matrix[i].join(' '));
    }
}