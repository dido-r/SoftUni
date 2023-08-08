function encodeAndDecodeMessages() {

    let buttons = document.querySelectorAll('main div button');
    let textAreas = document.getElementsByTagName('textarea');
    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function encode() {

        let encodedText = '';

        for (let i = 0; i < textAreas[0].value.length; i++) {

            encodedText += String.fromCharCode(textAreas[0].value[i].charCodeAt() + 1);
        }

        textAreas[1].value = encodedText;
        textAreas[0].value = '';
    }

    function decode() {

        let decodedText = '';

        for (let i = 0; i < textAreas[1].value.length; i++) {

            decodedText += String.fromCharCode(textAreas[1].value[i].charCodeAt() - 1);
        }

        textAreas[1].value = decodedText;
    }
}