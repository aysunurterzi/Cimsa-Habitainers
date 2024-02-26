import styled from '@emotion/styled';

export const BackgroundWrapper = styled.div`
    .background {
        width:100vw;
        height: 100vh;
        position: relative;
        &.blur {
            filter: blur(4px)
        }
    }
`;

export const LoginWrapper = styled.div`
    .login-container {
        background-color: rgba(216, 100, 169, 0.59);
        padding: 20px 30px;
        border-radius: 10px;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50% , -50%);
        .input-container {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
           .header {
                background-color: #A1C298;
                color: #F3FDE8;
                padding: 10px;
                width: 300px;
                margin-top: 20px;
                border-radius: 10px 10px 0 0;
                font-weight: bold;
                font-size: 22px;
           }
           .input-part {
                background-color: #C6EBC5;
                display: flex;
                flex-direction: column;
                flex-direction: center;
                width: 300px;
                padding: 10px;
                border-radius: 0 0 10px 10px;
                .input-area {
                    display: flex;
                    align-items: center;
                    gap: 10px;
                    .input {
                        background-color: #F3FDE8;
                        border: none;
                        border-radius: 7px;
                        padding: 10px 30px;
                        color: #757575;
;
                    }
                }
           }
        }
    }
`;