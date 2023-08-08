function deleteByEmail() {
    
    let emailTodelete = document.getElementsByName('email')[0].value;
    let emails = document.getElementsByTagName('td');
    
    for(let i = 1; i < emails.length; i += 2){

        if(emails[i].textContent ===emailTodelete){

            emails[i].parentElement.remove();
            document.getElementById('result').textContent = 'Deleted.'
            return;
        }
    }

    document.getElementById('result').textContent = 'Not found.'
}