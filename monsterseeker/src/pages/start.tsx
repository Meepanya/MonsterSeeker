import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import { BackGround, StartButton, Title } from "../theme/start";

export default function Start() {
    
    return(
        <Fragment>
            <BackGround>
                <Title>Monster Seeker</Title>
                <Link to="/MonsterSeeker">
                    <StartButton>Play Now!</StartButton>
                </Link>
            </BackGround>
        </Fragment>
    );
};