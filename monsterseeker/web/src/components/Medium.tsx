import * as THREE from "three";
import React from "react";

import Roboto from "../theme/Roboto.json";

const Medium = () => {

    let robot:any = Roboto
    const font = new THREE.Font(robot);
    const textOptions = {
        font,
        size: 5,
        height: 1,
    }
    
    return (
        <mesh position={[15,13,40]} rotation={[-Math.PI/10,-Math.PI,0]}>
            <textGeometry attach="geometry" args={["Medium", textOptions as any]}/>
            <meshStandardMaterial color="grey"/>
        </mesh>
    );
}

export default Medium;