function solve() {
    
    document.querySelector('body div button').addEventListener('click', onClick);

    function onClick() {

        let decimal = Number(document.getElementById('input').value);
        let type = document.getElementById('selectMenuTo').value;
        let result = [];

        if (type === 'hexadecimal') {

            while (decimal > 0) {

                if (decimal % 16 < 10) {

                    result.unshift(decimal % 16);
                } else {

                    if (decimal % 16 === 10) result.unshift('A');
                    else if (decimal % 16 === 11) result.unshift('B');
                    else if (decimal % 16 === 12) result.unshift('C');
                    else if (decimal % 16 === 13) result.unshift('D');
                    else if (decimal % 16 === 14) result.unshift('E');
                    else if (decimal % 16 === 15) result.unshift('F');
                }

                decimal = Math.floor(decimal / 16);
            }

        } else if (type === 'binary') {

            while (decimal > 0) {

                result.unshift(decimal % 2);
                decimal = Math.floor(decimal / 2);
            }
        }

        document.getElementById('result').value = result.join('');
    }
}