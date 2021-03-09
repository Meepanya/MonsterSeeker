import { useRef } from "react";
import { useFrame, useLoader } from "react-three-fiber";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";

import Medium from "./Medium";

const HalfDeadPlanet = ({history}: any) => {

    const gltf = useLoader(GLTFLoader, "/halfdeadPlanet/scene.gltf");
    const mesh: any = useRef(null);
    useFrame(() => (
        mesh.current.rotation.y += 0.001     
   ));

   const scale: any = [25,25,25]
    return (
        <mesh 
        ref={mesh} 
        onClick={() => { history.push("/medium"); window.location.reload()}}
        >
            <Medium/>
            <group position={[-15,-15, 40]} rotation={[0, Math.PI/2.6, 0]} scale={scale}>
                {gltf ? <primitive object={gltf.scene} dispose={null}/> : null}
            </group>
        </mesh>
    );
};

export default HalfDeadPlanet;