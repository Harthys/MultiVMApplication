import React from "react";
import {Header} from "semantic-ui-react";
import ReactDOM from "react-dom";
import App from "./App";

function MovieHeader() {
    function Home() {
        return function (p1: React.MouseEvent<HTMLAnchorElement>) {
            ReactDOM.render(
                <App/>,
                document.getElementById('root')
            );
        };
    }

    return (<Header as="h2" icon="film" content="Movies" onClick={Home()}/>)
}

export default MovieHeader;