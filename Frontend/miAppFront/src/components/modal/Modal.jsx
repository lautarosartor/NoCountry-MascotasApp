import React from 'react';

const ModalComponent = ({ show, children }) => {
    const propiedades = {
        position: 'fixed',
        top: 0,
        left: '0',
        right: '0',
        bottom: '0',
        zIndex: '1000',
        backgroundColor: 'rgba(0, 0, 0, 0.9)'
    }

    if (!show) {
        return null;
    }

    return (
        <div className="d-flex justify-content-center align-items-center" style={propiedades}>
            <div className="bg-light border-rounded position-relative">
                <button className="position-absolute top-0 end-0">x</button>
                {children}
            </div>
        </div>
    );
}

export default ModalComponent;