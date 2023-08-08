window.addEventListener("load", solve);

function solve() {

  const firstName = document.getElementById('first-name');
  const lastName = document.getElementById('last-name');
  const age = document.getElementById('age');
  const title = document.getElementById('story-title');
  const genre = document.getElementById('genre');
  const story = document.getElementById('story');
  const previewList = document.getElementById('preview-list');
  const publishButton = document.getElementById('form-btn');
  publishButton.addEventListener('click', publish);

  function publish() {

    if (firstName.value == '' || lastName.value == '' || age.value == '' || title.value == '' || story.value == '') {

      return;
    }

    let li = document.createElement('li');
    li.className = 'story-info';
    li.innerHTML = `<article>
    <h4>Name: ${firstName.value} ${lastName.value}</h4>
    <p>Age: ${age.value}</p>
    <p>Title: ${title.value}</p>
    <p>Genre: ${genre.value}</p>
    <p>${story.value}</p>
    </article>`;
    let saveButton = document.createElement('button');  
    let editButton = document.createElement('button');  
    let deleteButton = document.createElement('button');  
    saveButton.textContent = 'Save Story';
    saveButton.classList = 'save-btn';
    saveButton.addEventListener('click', save);
    editButton.textContent = 'Edit Story';
    editButton.classList = 'edit-btn';
    editButton.addEventListener('click', edit);
    deleteButton.textContent = 'Delete Story';
    deleteButton.className = 'delete-btn';
    deleteButton.addEventListener('click', deleteStory);
    li.appendChild(saveButton);
    li.appendChild(editButton);
    li.appendChild(deleteButton);
    previewList.appendChild(li);

    firstName.value = '';
    lastName.value = '';
    age.value = '';
    title.value = '';
    story.value = '';
    publishButton.disabled = true;

    function edit(event) {

      let current = event.target.parentElement;
      firstName.value = current.getElementsByTagName('h4')[0].textContent.replace('Name: ', '').split(' ')[0];
      lastName.value = current.getElementsByTagName('h4')[0].textContent.replace('Name: ', '').split(' ')[1];
      age.value = current.getElementsByTagName('p')[0].textContent.replace('Age: ', '');
      title.value = current.getElementsByTagName('p')[1].textContent.replace('Title: ', '');
      story.value = current.getElementsByTagName('p')[3].textContent;
      current.remove();
      publishButton.disabled = false;
    }

    function save() {

      let main = document.getElementById('main');
      main.innerHTML = '';
      let h = document.createElement('h1');
      h.textContent = 'Your scary story is saved!';
      main.appendChild(h);

    }

    function deleteStory(event) {

      let current = event.target.parentElement;
      current.remove();
      publishButton.disabled = false;
    }
  }
}