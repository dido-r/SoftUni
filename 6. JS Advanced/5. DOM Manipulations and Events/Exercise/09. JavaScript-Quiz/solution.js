function solve() {

  let pars = document.getElementsByTagName('p');

  for (let p of pars) {
    p.addEventListener('click', chooseAnswer);
  }

  let sections = document.getElementsByTagName('section');
  let rightAnswers = 0;

  function chooseAnswer(event) {

    let section = event.target.parentElement.parentElement.parentElement.parentElement;

    if (event.target.nodeName === 'P') {

      if (section.getElementsByTagName('h2')[0].textContent === 'Question #1: Which event occurs when the user clicks on an HTML element?') {

        if (event.target.textContent === 'onclick') {

          rightAnswers++;
        }

        sections[0].style.display = 'none';
        sections[1].style.display = 'block';

      } else if (section.getElementsByTagName('h2')[0].textContent === 'Question #2: Which function converting JSON to string?') {

        if (event.target.textContent === 'JSON.stringify()') {

          rightAnswers++;
        }

        sections[1].style.display = 'none';
        sections[2].style.display = 'block';
      }
      else if (section.getElementsByTagName('h2')[0].textContent === 'Question #3: What is DOM?') {

        if (event.target.textContent === 'A programming API for HTML and XML documents') {

          rightAnswers++;
        }

        sections[2].style.display = 'none';
        let result = document.getElementById('results');
        result.getElementsByTagName('h1')[0].textContent = rightAnswers === 3 ? 'You are recognized as top JavaScript fan!' : `You have ${rightAnswers} right answers`;
        result.style.display = 'block';
      }
    }
  }
}
