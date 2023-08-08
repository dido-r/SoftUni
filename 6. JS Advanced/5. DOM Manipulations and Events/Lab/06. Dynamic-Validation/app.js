function validate() {

    let input = document.getElementById('email')
    input.addEventListener('change', verify);

    let regex = '^([a-z]+)(@)([a-z]+)(.[a-z]+)$';
    input.pattern = regex;

    function verify(event) {

        if (!input.checkValidity()) {

            event.target.classList.add('error');

        } else {

            event.target.classList.remove('error');
        }
    }
}