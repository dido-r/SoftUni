function lockedProfile() {

    let index = 1;

    fetch('http://localhost:3030/jsonstore/advanced/profiles')
        .then(res => res.json())
        .then(data => Object.values(data).map(x => {

            let div = document.createElement('div');
            div.className = 'profile';
            div.innerHTML = `
                <img src="./iconProfile2.png" class="userIcon" />
	 			<label>Lock</label>
	 			<input type="radio" name="user${index}Locked" value="lock" checked>
	 			<label>Unlock</label>
	 			<input type="radio" name="user${index}Locked" value="unlock"><br>
	 			<hr>
	 			<label>Username</label>
	 			<input type="text" name="user${index}Username" value="${x.username}" disabled readonly />
	 			<div id="User${index}HiddenFields" class="hiddenInfo">
	 				<hr>
	 				<label>Email:</label>
	 				<input type="email" name="user${index}Email" value="${x.email}" disabled readonly />
	 				<label>Age:</label>
	 				<input type="email" name="user${index}Age" value="${x.age}" disabled readonly />
	 			</div>`;
            let button = document.createElement('button');
            button.textContent = 'Show more';
            button.addEventListener('click', showHide);
            div.appendChild(button);
            document.getElementById('main').appendChild(div);
            index++;
        }))

    function showHide(event) {

        let button = event.target;
        let user = event.target.parentElement;
        let locked = user.getElementsByTagName('input')[0];

        if(locked.checked === true){

            return;
        }

        let hidden = user.getElementsByTagName('div')[0];
        button.textContent === 'Show more' ? hidden.classList.remove('hiddenInfo') : hidden.classList.add('hiddenInfo');
        button.textContent === 'Show more' ? button.textContent = 'Hide it' : button.textContent = 'Show more';       
    }
}