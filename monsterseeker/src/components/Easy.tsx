import * as THREE from "three";
import React from "react";

import Roboto from "../theme/Roboto.json";

const Easy = () => {

    let robot:any = Roboto
    const font = new THREE.Font(robot);
    const textOptions = {
        font,
        size: 5,
        height: 1,
    }
    
    return (
        <mesh position={[-40,0,5]} rotation={[0,Math.PI/2,0]}>
            <textGeometry attach="geometry" args={["Easy", textOptions as any]}/>
            <meshStandardMaterial color="green"/>
        </mesh>
    );
}

export default Easy;