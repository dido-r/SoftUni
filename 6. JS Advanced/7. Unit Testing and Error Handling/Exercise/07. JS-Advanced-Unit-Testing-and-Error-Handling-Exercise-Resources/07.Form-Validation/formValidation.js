function validate() {

    document.getElementById('submit').addEventListener('click', validateAll);

    let company = document.getElementById('company');
    company.addEventListener('change', showMore);

    function showMore() {

        let companyInfo = document.getElementById('companyInfo');
        companyInfo.style.display = company.checked ? 'block' : 'none';
    }

    function validateAll(event) {

        event.preventDefault();
        let isInputCorrect = true;
        let username = document.getElementById('username');
        let password = document.getElementById('password');
        let passConfirm = document.getElementById('confirm-password');
        let email = document.getElementById('email');
        let companyNumber = document.getElementById('companyNumber');

        if (username.value.match(/^[a-zA-Z0-9]{3,20}$/g) === null) {

            username.style.borderStyle = 'solid';
            username.style.borderColor = 'red';
            isInputCorrect = false;

        } else {

            username.style.border = 'none';
        }

        if (password.value.match(/^[a-zA-Z0-9_]{5,15}$/g) === null || passConfirm.value !== password.value) {

            password.style.borderStyle = 'solid';
            password.style.borderColor = 'red';
            isInputCorrect = false;

        } else {

            password.style.border = 'none';
        }

        if (passConfirm.value.match(/^[a-zA-Z0-9_]{5,15}$/g) === null || passConfirm.value !== password.value) {

            passConfirm.style.borderStyle = 'solid';
            passConfirm.style.borderColor = 'red';
            isInputCorrect = false;

        } else {

            passConfirm.style.border = 'none';
        }

        if (email.value.match(/^[^@.]+@[^@]*\.[^@]*$/g) === null) {

            email.style.borderStyle = 'solid';
            email.style.borderColor = 'red';
            isInputCorrect = false;

        } else {

            email.style.border = 'none';
        }

        if (company.checked) {

            if (companyNumber.value < 1000 || companyNumber.value > 9999) {

                companyNumber.style.borderStyle = 'solid';
                companyNumber.style.borderColor = 'red';
                isInputCorrect = false;

            } else {

                companyNumber.style.border = 'none';
            }
        }

        document.getElementById('valid').style.display = isInputCorrect ? 'block' : 'none';
    }
}