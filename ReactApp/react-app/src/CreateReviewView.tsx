import React from "react";
import axios from "axios";
import MovieHeader from "./MovieHeader";

let SubmitReview = event => {
    event.preventDefault();
    
    var title = (document.getElementById('title') as HTMLInputElement).value;
    var body = (document.getElementById('body') as HTMLInputElement).value;
    var rating = (document.getElementById('rating') as HTMLInputElement).value;
    var movieId = (document.getElementById('movieId') as HTMLInputElement).value;

    const headers = {
        'Content-Type': 'application/json'
    }
    axios.post("http://192.168.2.13:5000/Review", {
            'title': title,
            'body': body,
            'rating': rating,
            'movieId': movieId
        }, {
            headers: headers
        }
    ).then(function(){
        alert("Review created");
    }).catch(function (error) {
        // handle error
        alert("Failed to create Review" + error);
    })
}

function CreateReviewView(props) {
    return (
        <div>
            <MovieHeader/>
            <form onSubmit={SubmitReview}>
                <label>
                    Title:<br/>
                    <input type="text" id="title" name="title"/><br/><br/>
                </label>
                <label>
                    Description:<br/>
                    <input type="text" id="body" name="body"/><br/><br/>
                </label>
                <label>
                    Rating:<br/>
                    <input type="text" id="rating" name="rating"/><br/><br/>
                </label>
                <label hidden={true}>
                    Rating:<br/>
                    <input hidden={true} value={props.movieId} type="text" id="movieId" name="movieId"/><br/><br/>
                </label>
                <input type={"submit"} value="Submit"/>
            </form>
        </div>
    )
}

export default CreateReviewView;