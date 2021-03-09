import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";
import { useFrame, useLoader } from "react-three-fiber";
import { useRef} from "react";

import Easy from "./Easy";

const Earth = ({history}:any) => {
    
    const mesh: any = useRef(null);
    useFrame(() => (
        mesh.current.rotation.y += 0.001     
    ));
    const gltf = useLoader(GLTFLoader, "/Earth/scene.gltf")

    const scale: any = [25,25,25]
    return (
        <mesh ref={mesh}
        onClick={() => { history.push("/easy"); window.location.reload()}}
        >
            <Easy/>
            <group position={[-20,-15,-15]} scale={scale}>
                {gltf ? <primitive object={gltf.scene} dispose={null}/> : null}
            </group>
        </mesh>
    );
};

export default Earth;