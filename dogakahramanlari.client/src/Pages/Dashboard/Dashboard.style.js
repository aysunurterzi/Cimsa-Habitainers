import styled from '@emotion/styled';

export const DashboardWrapper = styled.div`
    background-image: url("../../assets/jpgs/forest_background_transparency.jpg");
    padding: 40px;

    .logout1{
        position: absolute;
        top: 10px;
        right: 10px;
    }

    .homepage1{
        position: absolute;
        top: 10px;
        left: 10px;
    }


    .dashboard {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50% , -50%);
        display: flex;
        flex-direction: column;
        gap: 40px;
        margin: 30px;
        .dashboard-header {
            position: absolute;
            top: 30px;
            left: 50%;
            transform: translate(-50% , -150px);
            white-space: nowrap;
            font-family: "Seymour One", sans-serif;
            font-style: bold;
            font-size: 20px;
            line-height: normal;
            text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
            color: white;
            display: flex;
            align-items: center;
        }
        .dashboard-container {
            background: rgba(160, 174, 242, 0.56);
            box-shadow: 0px 4px 4px 0px rgba(0, 0, 0, 0.25);
            padding: 20px 40px;
            border-radius: 10px;
            color: rgba(48, 2, 8, 0.94);
            font-style: italic;
            font-size: 28px;
            font-style: Ultra Bold;
            width: 1000px;
            margin-top: 30px;
            position: relative;
            .animal-container {
                position: absolute;
                right: -160px;
                top: 320px;
            }
        }



        .white{
            color: rgba(48, 92, 4, 0.94);
            position: absolute;
            top:-10px;
            right: 7px;
            
        }

        .yazı{
            font-style: normal;
            font-weight: Medium;
            font-size: 25px;
            color: black;
        }
        .button-container {
            background-color: transparent;
            display: flex;
            justify-content: center;
            gap: 100px;
            .dashboard-button {
                width: 220px;
                border-radius: 50%;
                padding: 22px 40px 80px;
                background-color: #7F5539;
                font-weight: bold;
                font-size: 26px;
                
            }

            .dashboard-button:hover{
                background-color: rgb(127, 85, 57, 0.8);
                color: black;
                font-style: italic;
            }

            .homepageicon{
                position: absolute;
                margin: 0px;
                left: 190px;
                padding: 0px;
            }
            
            .taskpage {
                position: absolute;
                margin: 0px;
                left: 190px;
                padding: 0px;
            }

            .cagepage {
                position: absolute;
                margin: 0px;
                left: 505px;
            }
            
            .forestpage {
                position: absolute;
                margin: 0px;
                left: 825px;
            }
            
            .dashboard-image {
                width: 50px;
                background: none;
                
            }
            
            .dashboard-image {
                cursor: pointer;
            }


        }
    }

`;