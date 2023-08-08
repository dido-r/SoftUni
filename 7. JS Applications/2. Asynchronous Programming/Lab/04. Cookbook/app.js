async function solve() {
    
    const main = document.querySelector('body main');

    await fetch('http://localhost:3030/jsonstore/cookbook/recipes')
        .then(res => res.json())
        .then(data => Object.values(data).map(x => {

            let article = document.createElement('article');
            article.className = 'preview';
            article.innerHTML = `<div class="title">
            <h2>${x.name}</h2>
            </div>
            <div class="small">
            <img src=${x.img}>
            </div>`;
            article.addEventListener("click", showMore);
            main.appendChild(article);
        }));

}

async function showMore(event) {
    
    let current = event.target;
    let currentName = current.getElementsByTagName('h2')[0].textContent;
    let id = currentName[currentName.length - 1];

    current.innerHTML = `<h2>${currentName}</h2>
    <div class="band">
        <div class="thumb">
            <img src=${event.target.getElementsByTagName('img')[0].src}>
        </div>
    </div>`;

    await fetch(`http://localhost:3030/jsonstore/cookbook/details/0${id}`)
    .then(res => res.json())
    .then(data => {

        let div = document.createElement('div');
        div.className = 'ingredients';
        let h3 = document.createElement('h3');
        h3.textContent = 'Ingredients:';
        let ul = document.createElement('ul');
        data.ingredients.map(z => {

            let li = document.createElement('li');
            li.textContent = z;
            ul.appendChild(li);
        })

        div.appendChild(h3);
        div.appendChild(ul)
        current.querySelector('div').appendChild(div);

        let divPrep = document.createElement('div');
        divPrep.className = 'description';
        let h = document.createElement('h3');
        h.textContent = 'Preparation:';
        divPrep.appendChild(h);
        data.steps.map(z => {

            let p = document.createElement('p');
            p.textContent = z;
            divPrep.appendChild(p);
        })
        current.appendChild(divPrep);   
    });
}
