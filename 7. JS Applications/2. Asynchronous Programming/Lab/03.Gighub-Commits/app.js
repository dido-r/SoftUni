async function loadCommits() {

    const user = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const commits = document.getElementById('commits');
    commits.innerHTML = '';

    try {

        let p = await fetch(`https://api.github.com/repos/${user}/${repo}/commits`);

        if (p.ok == false) {

            throw new Error(`Error: ${p.status} (Not Found)`);
        }

        p.json().then(data => {
                
                if (data === undefined) {

                    throw new Error(`Error: ${p.status} (Not Found)`);
                }

                data.map(x => {
                let li = document.createElement('li');
                let a = document.createElement('a');
                a.textContent = `${x.commit.author.name}: ${x.commit.message}`;
                li.appendChild(a);
                commits.appendChild(li);
            })});

    } catch (err) {

        let li = document.createElement('li');
        let a = document.createElement('a');
        a.textContent = err.message;
        li.appendChild(a);
        commits.appendChild(li);
    }
}