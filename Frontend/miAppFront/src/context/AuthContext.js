import { useState, useEffect, createContext, useContext } from 'react';

// Estados de autenticacion
export const AuthStatus = {
  authenticated: 'authenticated',
  checking: 'checking',
  noAuthenticated: 'noAuthenticated'
}

const AuthContext = createContext();

export const AuthService = ({ children }) => {

  const [currentUser, setCurrentUser] = useState(undefined);
  const [authStatus, setAuthStatus] = useState(AuthStatus.checking);

  // Funcion que se ejecuta cuando se renderiza el componente
  useEffect(() => {
    // Verificamos que no haya sesion iniciada
    const token = localStorage.getItem('accessToken');
    
    // En caso de que haya token (sesion iniciada)
    if (token) {
      // Almacenamos los datos que retorna nuestra funcion que decodifica el token
      const { name, email, role, exp } = decodificarToken(token);
      
      // Ver datos del token:
      console.log('Nombre:', name);
      console.log('Email:', email);
      console.log('Rol:', role);
      console.log('Expiración:', new Date(exp * 1000));

      // Autenticamos el usuario pasando los datos del token
      setCurrentUser({ name, email, role, exp });
      setAuthStatus(AuthStatus.authenticated);  // Establecemos el estado en autenticado
    }
    else {
      // En caso de que no haya sesion iniciada el estado del usuario es no autenticado
      setAuthStatus(AuthStatus.noAuthenticated);
    }
  }, []);

  // Funcion para decodificar el token
  const decodificarToken = (jwtToken) => {
    // Decodificamos el token para obtener los datos del usuario
    const [header, payload, signature] = jwtToken.split('.');

    // Decodificar el payload (cuerpo) del token
    const tokenDecodificado = JSON.parse(atob(payload));

    // Acceder a los datos del payload decodificado
    return tokenDecodificado; //devuelve -> name, role, exp
  }

  // Funcion para iniciar sesion -> recibe el token
  const login = (token) => {
    // Almacenamos el token JWT en el local storage
    localStorage.setItem('accessToken', token);

    // Almacenamos los datos que retorna nuestra funcion que decodifica el token
    const { name, email, role, exp } = decodificarToken(token);

    // Ver datos del token:
    console.log('Nombre:', name);
    console.log('Email:', email);
    console.log('Rol:', role);
    console.log('Expiración:', new Date(exp * 1000));

    setCurrentUser({ name, email, role, exp });
    setAuthStatus(AuthStatus.authenticated);
  }

  // Funcion para cerrar sesion -> eliminar el token del local storage
  const logout = () => {
    if (localStorage.getItem('accessToken')) {
      localStorage.removeItem('accessToken');
      
      setCurrentUser(undefined);
      setAuthStatus(AuthStatus.noAuthenticated);
    }
    else {
      console.log("Primero debe iniciar sesión");
    }
  }

  return (
    <AuthContext.Provider value={{ currentUser, authStatus, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => useContext(AuthContext);