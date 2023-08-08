function validate() {
    
    let input = document.getElementById('email');
    input.addEventListener('change', verify);

    function verify(){

        if(input.value.match(/^[a-z]+@[a-z]+.[a-z]+$/g) === null){
            
            input.classList.add('error');
        }else{

            input.classList.remove('error');
        }
    }
}