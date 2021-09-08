import React, {useEffect, useState} from 'react';
import './App.css';
import axios from "axios";
import {Header, List, Card, CardProps} from 'semantic-ui-react'
import MovieDetails from "./MovieDetails";
import ReactDOM from "react-dom";
import MovieHeader from "./MovieHeader";
import CreateMovieView from "./CreateMovieView";

function App() {
    const [movieSummaries, setSummaries] = useState([]);
    useEffect(() => {
        axios.get('http://192.168.2.13:5000/Movie').then(response => {
            setSummaries(response.data);
        })
    }, [])

    function RenderMovieDetails(id) {
        return function (p1: React.MouseEvent<HTMLAnchorElement>, p2: CardProps) {
            ReactDOM.render(
                <MovieDetails movieId={id}/>,
                document.getElementById('root')
            );
        };
    }

    function CreateMovie() {
        return function (p1: React.MouseEvent<HTMLAnchorElement>, p2: CardProps) {
            ReactDOM.render(
                <CreateMovieView/>,
                document.getElementById('root')
            );
        };
    }

    return (
        <div>
            <MovieHeader/>
            <List>
                <Card onClick={CreateMovie()}>
                    <Card.Content>
                        <Card.Header>Create Movie</Card.Header>
                        <Card.Description><p>Create a new movie</p></Card.Description>
                    </Card.Content>
                </Card>
                {movieSummaries.map((movieSummary: any) => (
                    <Card id={movieSummary.id} onClick={RenderMovieDetails(movieSummary.id)}>
                        <Card.Content>
                            <Card.Header>{movieSummary.title}</Card.Header>
                            <Card.Description><p>{movieSummary.descriptionBody}</p></Card.Description>
                            <br/>
                            <Card.Content><i>Average Rating: {movieSummary.averageRating}</i></Card.Content>
                        </Card.Content>
                    </Card>
                ))}
            </List>
        </div>
    );
}

export default App;
