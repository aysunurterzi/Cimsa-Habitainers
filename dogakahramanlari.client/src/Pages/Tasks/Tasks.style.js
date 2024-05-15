import styled from "@emotion/styled";

export const TasksWrapper = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 30px;

    .home-icon {
        background-color: transparent;
        position: absolute;
        left: 20px;
    }


    .header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        gap: 50px;

        .button-container {
            display: flex;
            gap: 50px;
            .page-buttons {
                background-color: rgb(255, 254, 196);
                color: black;
                width: 280px;
                height: 100px;
                border-radius: 45%;
                font-size: 25px;
                font-weight: bold;
            }

            .page-buttons:hover {
                background-color: rgb(255, 254, 196, 0.8);
                color: black;
                width: 280px;
                height: 100px;
                border-radius: 45%;
                font-size: 25px;
                font-weight: bold;
                font-style: italic;
            }

        }
        .key-number {
            background-color: #B2EA70;
            display: flex;
            align-items: center;
            border-radius: 10px;
            padding: 5px 15px;
            font-size: 28px;
            font-weight: bold;
            gap: 15px;
            .key-image {
                width: 45px;
            }
        }
    }
    .task-body {
        background-color: #FFFEC4;
        width: 1200px;
        border-radius: 15px;
        height: 500px;
        font-weight: bold;
        .task-head {
            display: flex;
            justify-content: center;
            border-bottom: 1px solid #000000;
            font-size: 28px;
            color: #1D647E;
            gap: 400px;
            padding: 30px;
            .line {
                position: absolute;
                border-left: 1px solid #000000;
                height: 550px;
            }
        }
        .task-part {
            display: flex;
            justify-content: center;
            font-size: 20px;
            color: #1D4A7E;
            width: 1100px;
            padding: 10px 90px;
            font-weight: 400;
            font-style: italic;
            .daily-task-container {
                flex:1;
                .task-row {
                    display: flex;
                    align-items: start;
                    gap: 10px;
                    padding: 15px;
                    color: green;
                    background-color: rgb(178, 233, 112, 0.5);
                    border: solid 1px black;
                    border-radius: 20px;
                    margin: 20px 110px 20px 0px;
                }
            }
            .weekly-task-container {
                flex:1;
                .task-row {
                    display: flex;
                    align-items: start;
                    gap: 10px;
                    padding: 15px;
                    color: green;
                    background-color: rgb(178, 233, 112, 0.5);
                    border: solid 1px black;
                    border-radius: 20px;
                    margin: 20px 60px 20px 45px;
                }
                .modal {
                    position: fixed;
                    top: 50%;
                    left: 50%;
                    transform: translate(-50%, -50%);
                    padding: 20px;
                    width:500px;
                    height: 350px;
                    background: #fffec4;
                    border-radius: 8px;
                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
                    z-index: 1000;
                    text-align: center;
                    display: flex;
                    flex: column;
                    justify-content: center;
                    .key-number-container {
                        display: flex;
                        align-items: center;
                        justify-content: center;
                        margin-bottom: 20px;
                        .inner-container {
                            background-color: #B2EA70;
                            border-radius: 20px;
                            height: 70px;
                            display: flex;
                            align-items: center;
                            justify-content: center;
                            padding: 0 20px;
                            .key-number-inModal {
                                font-weight: bold;
                                display: flex;
                                align-items: center;
                             }
                        }
                    }
                }
            }
        }

    }
`;