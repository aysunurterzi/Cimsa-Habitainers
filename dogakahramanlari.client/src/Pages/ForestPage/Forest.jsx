import React, { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';
import "./ForestStyle.css";



const Forest = () => {
    const [animals, setAnimals] = useState([]);

    const navigate = useNavigate();

    const handleDashboardClick = () => {
        navigate('/dashboard');
    };

    const handleTaskPageClick = () => {
        navigate('/tasks');
    };

    const handleCagePageClick = () => {
        navigate('/cages');
    };

    const handleclickLogOut = () => {
        navigate('/');
    };


    useEffect(() => {
        fetch("http://localhost:5120/api/animals")
            .then(response => response.json())
            .then(data => {
                const updatedAnimals = data.map(animal => ({
                    ...animal,
                    imagesNormal: `/black-animals/black-${animal.name.toLowerCase()}.png`,
                    imagesStatus1: `/animals/${animal.name.toLowerCase()}.png`
                }));
                setAnimals(updatedAnimals);
            })
            .catch(error => console.error("Error fetching data: ", error));
    }, []);

    return (

        <>
            <div className="homepage" onClick={handleDashboardClick}>
                <img className="dashboard-image" src="icon/dashboard.png" alt="mainpage" />
            </div>

            <div className="taskpage" onClick={handleTaskPageClick}>
                <img className="dashboard-image" src="icon/task.png" alt="taskpage" />
            </div>

            <div className="cagepage" onClick={handleCagePageClick}>
                <img className="dashboard-image" src="icon/cage.png" alt="cagepage" />
            </div>

            <div className="logout" onClick={handleclickLogOut}>
                <img className="dashboard-image" src="icon/logout.png" alt="cagepage" />
            </div>

            <div className="forest-wrapper">
                <div className="forest-header-container">
                    <div className="forest-header">
                        <h1>ORMAN</h1>
                    </div>
                    <div className="forest-header2">
                        <h1>ORMAN</h1>
                    </div>
                </div>
                <div id="forest-animal-container">
                    {animals.map(animal => (
                        <div className={`animal-${animal.id}`} key={animal.id}>
                            <img
                                className={`animal-${animal.id}`}
                                src={animal.status === 1 ? animal.imagesStatus1 : animal.imagesNormal}
                                alt={animal.name}
                            />
                        </div>
                    ))}
                </div>
            </div>
        </>
    );
};

export default Forest;