function toggle() {
    
    let button = document.getElementsByClassName('button')[0].textContent;
    let more = document.getElementById('extra');

    if(button === 'More'){

        document.getElementsByClassName('button')[0].textContent = 'Less';
        more.style.display = 'block';
    }else if (button === 'Less'){

        document.getElementsByClassName('button')[0].textContent = 'More';
        more.style.display = 'none';
    }
}