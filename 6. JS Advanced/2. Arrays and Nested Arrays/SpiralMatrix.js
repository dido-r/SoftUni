function solve(height, width) {

    let matrix = new Array(height);

    for (let i = 0; i < matrix.length; i++) {

        matrix[i] = new Array(width);

        for (let j = 0; j < matrix[i].length; j++) {

            matrix[i][j] = false;
        }
    }

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

    let number = 2;
    let row = 0;
    let col = 0;
    matrix[0][0] = 1;

    while (!isFull(matrix)) {

        for (let i = col + 1; i < width; i++) {

            if (matrix[row][i] !== false) {

                break;
            }

            matrix[row][i] = number++;
            col = i;
        }

        for (let j = row + 1; j < height; j++) {

            if (matrix[j][col] !== false) {

                break;
            }

            matrix[j][col] = number++;
            row = j;
        }

        for (let k = col - 1; k >= 0; k--) {

            if (matrix[row][k] !== false) {

                break;
            }

            matrix[row][k] = number++;
            col = k;
        }

        for (let l = row - 1; l >= 0; l--) {

            if (matrix[l][col] !== false) {

                break;
            }

            matrix[l][col] = number++;
            row = l;
        }
    }

    for (let i = 0; i < matrix.length; i++) {

        console.log(matrix[i].join(' '));
    }
}