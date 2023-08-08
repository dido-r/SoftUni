import { put } from "../api.js";

export async function editItem(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { make, model, year, description, price, img, material } = Object.fromEntries(form);
    
    if(!checkInputs(event)){

        return;
    }

    let obj = {
        make, 
        model, 
        year, 
        description, 
        price, 
        img, 
        material
    }
    
    let id = event.target.id;
    
    try{

        await put(`data/catalog/${id}`, obj, true);
        window.location.href = "/";

    } catch(err){

        alert(err.message);
        return;
    }
}

function checkInputs(event) {

    clearClass(event);
    let isValid = true;
    let makeInput = event.target.querySelector('[name="make"]');
    let modelInput = event.target.querySelector('[name="model"]');
    let yearInput = event.target.querySelector('[name="year"]');
    let descriptionInput = event.target.querySelector('[name="description"]');
    let priceInput = event.target.querySelector('[name="price"]');
    let imgInput = event.target.querySelector('[name="img"]');

    if (makeInput.value.length < 4) {

        makeInput.classList.add('is-invalid');
        isValid = false;
    } else {

        makeInput.classList.add('is-valid');
    }

    if (modelInput.value.length < 4) {

        modelInput.classList.add('is-invalid');
        isValid = false;
    } else {

        modelInput.classList.add('is-valid');
    }

    if (Number(yearInput.value) < 1950 || Number(yearInput.value) > 2050) {

        yearInput.classList.add('is-invalid');
        isValid = false;
    } else {

        yearInput.classList.add('is-valid');
    }

    if (descriptionInput.value.length < 10) {

        descriptionInput.classList.add('is-invalid');
        isValid = false;
    } else {

        descriptionInput.classList.add('is-valid');
    }

    if (Number(priceInput.value) <= 0 || priceInput.value === '') {

        priceInput.classList.add('is-invalid');
        isValid = false;
    } else {

        priceInput.classList.add('is-valid');
    }

    if (imgInput.value === '') {

        imgInput.classList.add('is-invalid');
        isValid = false;
    } else {

        imgInput.classList.add('is-valid');
    }

    return isValid;
}

function clearClass(event) {

    [...event.target.getElementsByClassName('form-control')].forEach(x => x.className = 'form-control');
}