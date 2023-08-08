const host = 'http://localhost:3030';

async function request(method, url, obj, auth){

    let options = {

        method,
        headers: {}
    }

    if(obj !== undefined){

        options.headers['Content-type'] = 'application/json';
        options.body = JSON.stringify(obj);
    }

    if(auth){

        options.headers['X-Authorization'] = `${sessionStorage.getItem('token')}`;
    }

    try{

        let response = await fetch(host + url, options);

        if(response.status === 204){

            return response;
        }

        if(response.ok == false){

            throw new Error();
        }

        let data = await response.json();
        
        return data;

    }catch(err){

        alert(err.message);
        throw err;
    }
}

export const get = request.bind(null, 'get');
export const post = request.bind(null, 'post');
export const put = request.bind(null, 'put');
export const del = request.bind(null, 'delete');