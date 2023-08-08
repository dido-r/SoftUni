function solve() {

    document.getElementById('submit').addEventListener('click', submit);
    const form = document.getElementById('form');
    form.addEventListener('submit', createStudent);

    async function createStudent(event) {

        event.preventDefault();
        const data = new FormData(form);

        let student = {

            firstName: data.get('firstName'),
            lastName: data.get('lastName'),
            facultyNumber: data.get('facultyNumber'),
            grade: data.get('grade')
        }

        if (student.firstName === '' || student.lastName === '' || student.facultyNumber === '' || student.grade === '' || isNaN(student.grade) || isNaN(student.facultyNumber)) {

            return;
        }

        await fetch('http://localhost:3030/jsonstore/collections/students', {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(student)
        })

        let response = await fetch('http://localhost:3030/jsonstore/collections/students');
        let result = await response.json();
        const tbody = document.getElementById('results').querySelector('tbody');
        tbody.innerHTML = '';
        
        Object.values(result).map(x => {
            
            let tr = document.createElement('tr');
            tr.innerHTML = `
        <td>${x.firstName}</td>
        <td>${x.lastName}</td>
        <td>${x.facultyNumber}</td>
        <td>${x.grade}</td>`;
            tbody.appendChild(tr);
        });

        let inputs = document.getElementsByTagName('input');
        inputs[0].value = '';
        inputs[1].value = '';
        inputs[2].value = '';
        inputs[3].value = '';
    }
}

solve()