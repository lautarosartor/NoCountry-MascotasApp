import { environment } from '../enviroment';

const url = environment.apiUrl;

export const Get = async (endpoint) => {
    try {
        const response = await fetch(`${url}/${endpoint}`);

        if (!response.ok) {
            //throw new Error('Error al procesar la solicitud.');
            //Esto muestra el error textual establecido en el backend
            let errorMessage = await response.text();
            
            throw new Error(errorMessage);
        }

        const data = await response.json();
        return data;
    }
    catch (error) {
        console.error('ERROR: ', error);
    }
}

export const Post = async (endpoint, body) => {
    try {
        const response = await fetch(`${url}/${endpoint}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            //Esto muestra el error textual establecido en el backend
            let errorMessage = await response.text();
            
            throw new Error(errorMessage);
        }

        //console.log(response, body);
        
        if (endpoint === "Account/login" || endpoint === "Account/register") {
            //Para poder acceder al token
            const data = await response.json();
            return data;
        }
    }
    catch (error) {
        console.error(error);
    }
}

export const Put = async (endpoint, body) => {
    try {
        const response = await fetch(`${url}/${endpoint}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            let errorMessage = await response.text();
            
            throw new Error(errorMessage);
        }
    }
    catch (error) {
        console.error(error);
    }
}

export const Delete = async (endpoint) => {
    try {
        const response = await fetch(`${url}/${endpoint}`, {
            method: 'DELETE'
        });

        if (!response.ok) {
            let errorMessage = await response.text();
            
            throw new Error(errorMessage);
        }
    }
    catch (error) {
        console.error(error)
    }
}