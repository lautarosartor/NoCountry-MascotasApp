import { Button, IconButton, Menu, MenuItem } from '@mui/material';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import PetsIcon from '@mui/icons-material/Pets';

import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { AuthStatus, useAuth } from '../../context/AuthContext';

const Header = () => {const [anchorEl, setAnchorEl] = useState(null);
  const { logout, authStatus, currentUser } = useAuth();  // Funcion de AuthContext.js

  const handleMenu = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleLogout = () => {
    handleClose();
    logout();
  }

  return (
    <AppBar position="sticky" className="top-0" style={{height: '4rem', backgroundColor: '#011936'}}>
      <Toolbar className="h-100">
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          <Link className="text-white" to="/" style={{textShadow: '0 0 10px black'}}>
            <PetsIcon style={{height: '100%', width: '3rem'}}/>
          </Link>
        </Typography>

        <Button size="small" variant="outlined" className="me-3">
          <Link className="text-white text-decoration-none" to="/">
            Home
          </Link>
        </Button>

        {authStatus === AuthStatus.authenticated ? (
          <div className="d-flex gap-3">
            <Button size ="small" variant="outlined" color="secondary">
              <Link className="text-white text-decoration-none" to="/dashboard">
                Dashboard
              </Link>
            </Button>

            <IconButton className="bg-info" style={{height: '2rem', width: '2rem'}}
              aria-label="cuenta"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleMenu}>
              <AccountCircleIcon className="text-dark" style={{height: '2rem', width: '2rem'}}/>
            </IconButton>
            
            <Menu id="menu-appbar"
              anchorEl={anchorEl}
              anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorEl)}
              onClose={handleClose}>
              <MenuItem onClick={handleClose} disabled>{currentUser.name}</MenuItem>
              <MenuItem onClick={handleClose}>Configuración</MenuItem>
              <MenuItem onClick={handleLogout}>Cerrar Sesión</MenuItem>
            </Menu>
          </div>
        ) : (
          <div>
            <Button size="small" variant="contained" className="bg-secondary me-3">
              <Link className="text-white text-decoration-none" to="/login">LOG IN</Link>
            </Button>

            <Button size="small" variant="contained" className="bg-dark me-3">
              <Link className="text-white text-decoration-none" to="/register">SING UP</Link>
            </Button>
          </div>
        )}
      </Toolbar>
    </AppBar>
  );
};

export default Header;

