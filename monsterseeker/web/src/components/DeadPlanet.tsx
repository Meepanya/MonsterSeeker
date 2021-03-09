import { useRef } from "react";
import { useFrame, useLoader } from "react-three-fiber";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";

import Hard from "./Hard";

const DeadPlanet = ({history}: any) => {

    const mesh: any = useRef(null);
    useFrame(() => (
        mesh.current.rotation.y += 0.001
    ));

    const gltf = useLoader(GLTFLoader, "/deadPlanet/scene.gltf");
    console.log(gltf);

    const scale: any = [25,25,25]

    return (
        <mesh 
        ref={mesh} 
        onClick={() => { history.push("/hard"); window.location.reload()}}
        >
            <Hard/>
            <group position={[20,-15,0]} scale={scale}>
                {gltf ? <primitive object={gltf.scene} dispose={null}/> : null}
            </group>
        </mesh>
    );
};

export default DeadPlanet;