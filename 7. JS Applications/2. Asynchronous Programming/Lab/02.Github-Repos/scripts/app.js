function loadRepos() {

	const user = document.getElementById('username').value;
	const repos = document.getElementById('repos');
	repos.innerHTML = '';

	fetch(`https://api.github.com/users/${user}/repos`)
		.then(res => res.json())
		.then(data => data.map(x => {

			let li = document.createElement('li');
			let a = document.createElement('a');
			a.href = x.html_url;
			a.textContent = x.full_name;
			li.appendChild(a);
			repos.appendChild(li);
		}))
		.catch(err => {
			repos.textContent = 'Not Found';
		});
}