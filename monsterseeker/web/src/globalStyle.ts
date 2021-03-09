import { createGlobalStyle } from "styled-components";

const GlobalStyle = createGlobalStyle`
    html, body, #root {
        margin: 0;
        padding: 0;
        font-family: Verdana;
        background: darkblue;
        width: 100%;
        height: 100%;
    }
`;

export default GlobalStyle;