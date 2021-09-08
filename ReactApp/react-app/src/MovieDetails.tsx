import React, {useEffect, useState} from 'react';
import './App.css';
import axios from "axios";
import {Header, List, Card, CardProps} from 'semantic-ui-react'
import MovieHeader from "./MovieHeader";
import ReactDOM from "react-dom";
import CreateReviewView from "./CreateReviewView";

function MovieDetails(props) {
    const [movieDetails, setDetails] = useState(Object);
    useEffect(() => {
        axios.get('http://192.168.2.13:5000/Movie/' + props.movieId).then(response => {
            setDetails(response.data);
        })
    }, [])

    function CreateReview(movieId) {
        return function (p1: React.MouseEvent<HTMLAnchorElement>, p2: CardProps) {
            ReactDOM.render(
                <CreateReviewView movieId={movieId}/>,
                document.getElementById('root')
            );
        };
    }

    return (
        <div>
            <MovieHeader/>
            <div className={"movieContainer"}>
                <br/>
                <h2>Title: {movieDetails.title}</h2>
                <p>Description: {movieDetails.descriptionBody}</p>

                <br/>
                <i>Average Rating: {movieDetails.averageRating}</i>
                <br/>
                <br/>
                <h3>Reviews</h3>
                <List>
                    <Card onClick={CreateReview(props.movieId)}>
                        <Card.Content>
                            <Header>Create Review</Header>
                            <Card.Description><p>Write review for {movieDetails.title}</p></Card.Description>
                        </Card.Content>
                    </Card>
                    {movieDetails.reviews && movieDetails.reviews.map((movieReview: any) => (
                        <Card>
                            <Card.Content>
                                <Header>{movieReview.title}</Header>
                                <Card.Description><p>{movieReview.body}</p>
                                </Card.Description>
                                <br/>
                                <Card.Content><i>Rating: {movieReview.rating}</i></Card.Content>
                            </Card.Content>
                        </Card>))}
                </List>
            </div>
        </div>
    );
}

export default MovieDetails;
