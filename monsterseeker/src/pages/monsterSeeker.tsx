import { Stars, OrbitControls} from "@react-three/drei";
import React, { Suspense } from "react";
import { withRouter } from "react-router-dom";
import { Canvas } from "react-three-fiber";

import DeadPlanet from "../components/DeadPlanet";
import Earth from "../components/Earth";
import HalfDeadPlanet from "../components/HalfDeadPlanet";
import GlobalStyle from "../globalStyle";

function MonsterSeeker({history}: any) {

    return(
        <Canvas colorManagement camera={{ position: [-5, 2, 10], fov: 40 }}>
            <Suspense fallback={null}>
                <GlobalStyle/>
                <OrbitControls/>
                <Stars/>
                <Earth history={history}/>
                <HalfDeadPlanet history={history}/>
                <DeadPlanet history={history}/>
                <ambientLight intensity={1.5}></ambientLight>
                <spotLight position={[10, 15, 10]} angle={0.3} intensity={1.5}/>
            </Suspense>
        </Canvas>
    )
}

export default withRouter(MonsterSeeker);