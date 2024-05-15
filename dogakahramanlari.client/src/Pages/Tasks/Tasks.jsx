import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import keyImage from '../../assets/pngs/key.png';
import { KeyIcon } from '../../assets/svg/icons';
import { TasksWrapper } from './Tasks.style';

const Tasks = () => {
    const navigate = useNavigate();
    const [tasks, setTasks] = useState([]);
    const [isPopupOpen, setPopupOpen] = useState(false);
    const [modalTask, setModalTask] = useState(null)
    const [keyNumber, setKeyNumber] = useState(0);
    const userId = localStorage.getItem('userId');
    //   const [isChecked, setIsChecked] = useState(false);

    const handleDashboardClick = () => {
        const newPath = '/dashboard';
        navigate(newPath);
    };

    const handleclickLogOut = () => {
        navigate('/');
    };



    const openPopup = (task) => {
        if (task.dutyStatus === 0) {
            setPopupOpen(true);
            setModalTask(task);
        }
        else {
            setPopupOpen(false);
        }
    }

    const closePopup = () => {
        setPopupOpen(false);
    };

    const getKeyNumber = async () => {
        try {
            const response = await fetch(`http://localhost:5120/api/userKeys/${userId}`);
            if (!response.ok) {
                throw new Error('Failed to fetch data');
            }
            const data = await response.json();
            console.log(data.numberOfKeys);
            setKeyNumber(data.numberOfKeys);
        } catch (error) {
            console.error('Veri alınırken hata oluştu:', error);
        }
    };

    const updateKeyNumber = async (task) => {
        const updatedKey = { id: userId, numberOfKeys: keyNumber + (task.dateStatus === 0 ? 5 : 20) };
        console.log(task, 'task');
        console.log(updatedKey, 'up');
        try {
            const keyRes = await fetch(`http://localhost:5120/api/userKeys/${userId}`, {
                method: 'PUT',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(updatedKey)
            })
            if (keyRes.status >= 200 && keyRes.status <= 299) {
                // setKeyNumber(keyNumber + 5);
                getKeyNumber();
            }
        } catch (error) {
            console.log(error);
        }
    };

    const checkHandler = async (task) => {
        const newDutyStatus = task.dutyStatus === 0 ? 1 : 0;
        const updatedTask = { ...task, dutyStatus: newDutyStatus };
        try {
            const response = await fetch(`http://localhost:5120/api/duties/${task.id}`, {
                method: 'PUT',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify(updatedTask)
            });
            if (response.status >= 200 && response.status <= 299) {
                setTasks(prevTasks => prevTasks.map(prevTask => prevTask.id === updatedTask.id ? updatedTask : prevTask));
                updateKeyNumber(task);
            } else {
                alert('Gorev tamamlama yapilamadi.')
            }
            closePopup();
        } catch (error) {
            console.log(error)
        }
    };

    useEffect(() => {
        const getTasks = async () => {
            try {
                const response = await fetch('http://localhost:5120/api/duties', {
                    method: 'GET'
                })
                const result = await response.json();
                setTasks(result);
            } catch (error) {
                console.log(error)
            }
        };
        getTasks();
        getKeyNumber();
    }, []);

    return (
        <TasksWrapper>
            <div className="home-icon" onClick={handleDashboardClick}>
                <img className="dashboard-image" src="icon/dashboard.png" alt="mainpage" />
            </div>
            <div className='header'>

                <div className="a">

                </div>

                <div className="logout" onClick={handleclickLogOut}>
                    <img className="dashboard-image" src="icon/logout.png" alt="cagepage" />
                </div>

                <div className='button-container'>
                    <button
                        className='page-buttons'
                    >
                        Görevler
                    </button>
                    <button
                        className='page-buttons'
                        onClick={() => navigate('/cages')}
                    >
                        Hayvanlar
                    </button>
                    <button
                        className='page-buttons'
                        onClick={() => navigate('/forest')}
                    >
                        Orman
                    </button>
                </div>
                <div className='key-number'>
                    <span>{keyNumber}</span>
                    <img className='key-image' src={keyImage} alt='keyImage' />
                </div>
            </div>
            <div className='task-body'>
                <div className='task-head'>
                    <div>
                        <span>Günlük Görevler</span>
                    </div>
                    <div className='line'></div>
                    <div>
                        <span>Haftalık Görevler</span>
                    </div>
                </div>
                <div className='task-part'>
                    <div className='daily-task-container'>
                        <div>
                            {
                                tasks.sort((a, b) => (a.dutyStatus - b.dutyStatus))
                                    .map((task) => (
                                        task.dateStatus === 0
                                            ?
                                            <div
                                                onClick={() => openPopup(task)}
                                                className='task-row'
                                                key={task.id}
                                                style={task.dutyStatus === 1 ? {
                                                    color: 'grey',
                                                    backgroundColor: 'rgb(105, 113, 152, 0.2)',
                                                    border: 'solid 1px black',
                                                    borderRadius: '20px',
                                                    margin: '20px 110px 20px 0px'
                                                } : null}
                                            >
                                                <input
                                                    type='checkbox'
                                                    checked={task.dutyStatus === 1}
                                                    disabled
                                                />
                                                <div> {task.content} </div>
                                            </div>
                                            :
                                            null
                                    ))
                            }
                        </div>
                    </div>
                    <div className='weekly-task-container'>
                        <div>
                            {
                                tasks
                                    .sort((a, b) => (a.dutyStatus - b.dutyStatus))
                                    .map((task) => (
                                        task.dateStatus === 1
                                            ?
                                            <div
                                                onClick={() => openPopup(task)}
                                                className='task-row'
                                                key={task.id}
                                                style={task.dutyStatus === 1 ? {
                                                    color: 'grey',
                                                    backgroundColor: 'rgb(105, 113, 152, 0.2)',
                                                    border: 'solid 1px black',
                                                    borderRadius: '20px',
                                                    margin: '20px 60px 20px 45px'
                                                } : null}
                                            >
                                                <input
                                                    type='checkbox'
                                                    checked={task.dutyStatus === 1}
                                                    disabled
                                                />
                                                <div> {task.content} </div>
                                            </div>
                                            :
                                            null
                                    ))
                            }
                            {
                                isPopupOpen && modalTask && (
                                    <div className="modal">
                                        <div className="popup-content">
                                            <h2>{modalTask.name} </h2>
                                            <p>{modalTask.content}</p>
                                            {modalTask.dateStatus === 0
                                                ?
                                                <div className='key-number-container'>
                                                    <div className='inner-container'>
                                                        <div className='key-number-inModal'>5 Anahtar</div>
                                                        <KeyIcon width={50} />
                                                    </div>
                                                </div>
                                                :
                                                <div className='key-number-container'>
                                                    <div className='inner-container'>
                                                        <div className='key-number-inModal'>20 Anahtar</div>
                                                        <KeyIcon width={50} />
                                                    </div>
                                                </div>
                                            }
                                            <button style={{ backgroundColor: 'green', marginLeft: "5px" }} onClick={() => checkHandler(modalTask)}>
                                                Tamamla
                                            </button>
                                            <button style={{ backgroundColor: 'red', marginLeft: "5px" }} onClick={closePopup}>
                                                Kapat
                                            </button>
                                        </div>
                                    </div>
                                )
                            }
                        </div>
                    </div>
                </div>
            </div>
        </TasksWrapper>
    )
}

export default Tasks;



