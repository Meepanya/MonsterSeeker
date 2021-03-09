import * as THREE from "three";
import React from "react";

import Roboto from "../theme/Roboto.json";

const Hard = () => {

    let robot:any = Roboto
    const font = new THREE.Font(robot);
    const textOptions = {
        font,
        size: 5,
        height: 1,
    }
    
    return (
        <mesh position={[20,-7,-30]} rotation={[0,-Math.PI/3,0]}>
            <textGeometry attach="geometry" args={["Hard", textOptions as any]}/>
            <meshStandardMaterial color="softred"/>
        </mesh>
    );
}

export default Hard;