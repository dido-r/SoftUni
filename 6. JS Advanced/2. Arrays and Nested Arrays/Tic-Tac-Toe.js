function ticTacToe(moves) {

    let matrix = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    function checkRows(array) {

        let isRowSame = true;

        for (let i = 0; i < array.length; i++) {

            for (let j = 0; j < array[i].length - 1; j++) {

                if (array[i][j] !== array[i][j + 1]) {

                    isRowSame = false;
                }
            }

            if (isRowSame && array[i][i] !== false) {

                return true;
            }
        }

        return false;
    }

    function checkCols(array) {

        let isColSame = true;

        for (let i = 0; i < array.length; i++) {

            for (let j = 0; j < array.length - 1; j++) {

                if (array[j][i] !== array[j + 1][i]) {

                    isColSame = false;
                }
            }

            if (isColSame && array[i][i] !== false) {

                return true;
            }
        }

        return false;
    }

    function checkFirstDiagonal(array) {

        let isDiagonalSame = true;

        for (let i = 0; i < array.length - 1; i++) {

            if (array[i][i] !== array[i + 1][i + 1]) {

                isDiagonalSame = false;
            }
        }

        if (isDiagonalSame && array[0][0] !== false) {

            return true;
        }

        return false;
    }

    function checkSecondDiagonal(array) {

        let isSame = true;

        for (let i = 0; i < array.length - 1; i++) {

            if (array[i][array.length - 1 - i] !== array[i + 1][array.length - 2 - i]) {

                isSame = false;
            }
        }

        if (isSame && array[0][array.length - 1] !== false) {

            return true;
        }

        return false;
    }

    function isFull(array) {

        for (let i = 0; i < array.length; i++) {

            for (let j = 0; j < array.length; j++) {

                if (array[i][j] === false) {
                    
                    return false;
                }
            }
        }

        return true;
    }

    function print(array) {

        for (let i = 0; i < array.length; i++) {

            console.log(array[i].join('\t'))
        }
    }

    let firstPlayerTurn = true;
    let winner = 0;

    for (let move of moves) {

        
        let row = move[0];
        let col = move[2];

        if (matrix[row][col] !== false) {

            console.log('This place is already taken. Please choose another!');
        } else {

            if (firstPlayerTurn) {

                matrix[row][col] = 'X';
                firstPlayerTurn = false;
            } else {

                matrix[row][col] = 'O';
                firstPlayerTurn = true;
            }
        }

        if (checkRows(matrix) || checkCols(matrix) || checkFirstDiagonal(matrix) || checkSecondDiagonal(matrix)) {

            if (firstPlayerTurn === false) {

                winner = 'X';
            } else {

                winner = 'O';
            }

            console.log(`Player ${winner} wins!`);
            print(matrix);
            return;
        }

        if(isFull(matrix)){
            
            console.log('The game ended! Nobody wins :(');
            print(matrix);
            return;
        }
    }

    console.log('The game ended! Nobody wins :(');
    print(matrix);
}