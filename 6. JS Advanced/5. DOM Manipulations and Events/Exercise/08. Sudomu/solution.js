function solve() {

    let buttons = document.getElementsByTagName('button');
    buttons[0].addEventListener('click', validate);
    buttons[1].addEventListener('click', clear);
    let rows = document.querySelectorAll('tbody tr td');
    let table = document.getElementsByTagName('table')[0];

    function validate() {

        let isRight = true;
        
        for (let i = 0; i < rows.length; i += 3) {

            let validator = [1, 2, 3];
            let number1 = Number(rows[i].getElementsByTagName('input')[0].value);
            validator = validator.filter(x => x !== number1);
            let number2 = Number(rows[i + 1].getElementsByTagName('input')[0].value);
            validator = validator.filter(x => x !== number2);
            let number3 = Number(rows[i + 2].getElementsByTagName('input')[0].value);
            validator = validator.filter(x => x !== number3);

            if (validator.length > 0) {

                isRight = false;
                break;
            }
        }

        for (let i = 0; i < 3; i++) {

            let validator = [1, 2, 3];

            let firstCell = Number(rows[0].getElementsByTagName('input')[0].value);
            let secondCell = Number(rows[1].getElementsByTagName('input')[0].value);
            let thirdCell = Number(rows[2].getElementsByTagName('input')[0].value);
            validator = validator.filter(x => x !== firstCell);
            validator = validator.filter(x => x !== secondCell);
            validator = validator.filter(x => x !== thirdCell);

            if (validator.length > 0) {

                isRight = false;
                break;
            }
        }
                
        let text = document.getElementById('check').getElementsByTagName('p')[0];

        if (isRight) {

            text.textContent = 'You solve it! Congratulations!';
            text.style.color = 'green';
            table.style.border = '2px solid green';

        } else {

            text.textContent = 'NOP! You are not done yet...';
            text.style.color = 'red';
            table.style.border = '2px solid red';
        }
    }

    function clear() {
        
        for (let row of rows) {

            row.getElementsByTagName('input')[0].value = '';
        }

        table.style.border = 'none';
        document.getElementById('check').getElementsByTagName('p')[0].textContent = '';
    }
}