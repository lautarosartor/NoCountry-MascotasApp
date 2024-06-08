import React from 'react';
import Header from './components/header/Header';
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'

import HomeComponent from './pages/home/Home';
import RegisterComponent from './pages/auth/Register';
import LoginComponent from './pages/auth/Login';
import RefugioComponent from './pages/dashboard/RefugioDashboard';
import ClienteComponent from './pages/dashboard/ClienteDashboard';
import { useAuth } from './context/AuthContext';

function App() {
  const {authStatus, currentUser} = useAuth();
  console.log("Usuario: " + authStatus + " ", currentUser);

  return (
    <BrowserRouter>
      <Header/>

      <main>
        <Routes>
          <Route path="*" element={<>NOT FOUND</>}></Route>
          <Route index element={<HomeComponent/>} />
          <Route path="/login" element={authStatus === "noAuthenticated" ? <LoginComponent/> : <Navigate to="/" />} />
          <Route path="/register" element={authStatus === "noAuthenticated" ? <RegisterComponent/> : <Navigate to="/" />} />
          <Route path="/dashboard"
            element={
              authStatus === "authenticated" ?
              (
                currentUser.role === "Refugio" ? ( <RefugioComponent /> ) :
                currentUser.role === "Cliente" ? ( <ClienteComponent /> ) :
                ( <Navigate to="/" /> )
              ) : ( <Navigate to="/" /> )
            }/>
        </Routes>
      </main>
    </BrowserRouter>
  );
}

export default App;
