import styled from "styled-components";
import img from "./alienBackground.jpg";

export const BackGround = styled.div`
    background-image: url(${img});
    height: 100vh;
    background-position: center;
    backgroun-repeat: no-repeat;
    background-size: cover;
    font-family: Verdana;
`;

export const Title = styled.div`
    font-size: 4em;
    text-align: center;
    color: #fcfbfe;
`;

export const StartButton = styled.button`
    font-size: 2em;
    margin-left: 50%;
    margin-top: 20%;
    padding: 0.5em;
    color: white;
    background: #305c79;
    border: 2px solid black;
    justifyContent: center;
    alignItems: center;
    border-radius: 10px;
    font-family: Verdana;

    &:hover {
        color: #bfff00;
        box-shadow: 0 12px 16px 0 rgba(0,0,0,2), 0 17px 50px 0 rgba(0,0,0,0.5);
    }
`;