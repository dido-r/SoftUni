function solve() {

  let text = document.getElementById('input').value.split('.').filter(x => x.length > 0);
  let result = [];

  for (let i = 0; i < text.length; i++) {

    result.push(text[i]);

    if (result.length % 3 === 0) {

      document.getElementById('output').innerHTML += `<p>${result.join('. ') + '.'}</p>`;
      result = [];
    }
  }

  if (result.length > 0) {
    document.getElementById('output').innerHTML += `<p>${result.join('. ') + '.'}</p>`;
  }
}