function focused() {

    let list = document.getElementsByTagName('input');

    for (let item of list) {

        item.addEventListener('focus', onFocus);
        item.addEventListener('blur', focusOut);
    }

    function onFocus(event) {

        event.target.parentElement.classList.add('focused');
    }

    function focusOut(event) {

        event.target.parentElement.classList.remove('focused');
    }
}

//first code, wich Judge didn't approve, but work in Chrome
function focused() {

    document.querySelector('body div').addEventListener('focusin', onFocus);
    document.querySelector('body div').addEventListener('focusout', focusOut);

    function onFocus(event) {

        if (event.target.nodeName === 'INPUT') {

            event.target.parentElement.classList.add('focused');
        }
    }

    function focusOut(event) {
        
        event.target.parentElement.classList.remove('focused');
    }
}