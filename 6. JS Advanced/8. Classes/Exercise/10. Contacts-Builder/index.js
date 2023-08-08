class Contact {

    constructor(firstName, lastName, phone, email) {

        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
    }

    get online () {
		return this._online
	}

    set online(value){

        this._online = value;

        if(this._online){

            this.divTitle.classList.add('online');
        }else{

            this.divTitle.classList.remove('online');
        }
    }

    render = (id) => {

        this.spanPhone = document.createElement('span');
        this.spanPhone.textContent = `\u260E ${this.phone}`;
        this.spanEmail = document.createElement('span');
        this.spanEmail.textContent = `\u2709 ${this.email}`;
        this.divInfo = document.createElement('div');
        this.divInfo.classList.add('info');
        this.divInfo.appendChild(this.spanPhone);
        this.divInfo.appendChild(this.spanEmail);
        this.divInfo.style.display = 'none';
        this.divTitle = document.createElement('div');
        this.divTitle.classList.add('title');
        this.divTitle.textContent = `${this.firstName} ${this.lastName}`;
        this.button = document.createElement('button');
        this.button.textContent = '\u2139';
        this.divTitle.appendChild(this.button);
        this.button.addEventListener('click', (event) => {

            let section = event.target.parentElement.parentElement.getElementsByTagName('div')[1];
            section.style.display = section.style.display === 'none' ? 'block' : 'none';
        });
        this.article = document.createElement('article');
        this.article.appendChild(this.divTitle);
        this.article.appendChild(this.divInfo);
        document.getElementById(id).appendChild(this.article);
    }
}