import React, { useEffect, useState } from 'react';
import { Get } from './http';

const Example = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const data = await Get('Usuarios');

                setUsers(data);

                console.log(data);
            }
            catch (error) {
                console.error('ERROR: ', error);
            }
        };

        fetchUsers();
    }, []);

    return (
        <div className="table-responsive">
            <table className="table table-primary">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Provincia</th>
                        <th scope="col">Localidad</th>
                        <th scope="col" className="text-center">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    {users && users.length > 0 ? (
                    users.map(user => (
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.nombre} {user.apellido}</td>
                            <td>{user.provincia}</td>
                            <td>{user.localidad}</td>
                            <td  className="d-flex justify-content-center gap-2">
                                <a href="/" className="btn btn-primary p-0">Modificar</a>
                                <a href="/" className="btn btn-danger p-0">Eliminar</a>
                            </td>
                        </tr>
                    ))
                    ) : (
                    <tr>
                        <td colSpan="5">No users found</td>
                    </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
};

export default Example;