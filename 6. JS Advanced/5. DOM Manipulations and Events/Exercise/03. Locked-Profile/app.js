function lockedProfile() {

    document.getElementById('main').addEventListener('click', showMore);
    document.querySelectorAll

    function showMore(event) {

        if (event.target.nodeName === 'BUTTON') {

            let parent = event.target.parentElement;
            let inputs = parent.querySelectorAll('input[type="radio"]');

            if (inputs[1].checked) {

                let hidden = parent.querySelector('div div');

                if (event.target.textContent === 'Show more') {
                                        
                    hidden.style.display = 'block';
                    event.target.textContent = 'Hide it';
                    
                }else{

                    hidden.style.display = 'none';
                    event.target.textContent = 'Show more';
                }
            }
        }
    }
}