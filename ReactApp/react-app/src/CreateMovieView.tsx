import React from "react";
import MovieHeader from "./MovieHeader";
import axios from "axios";

let SubmitMovie = event => {
    event.preventDefault();
    
    var title = (document.getElementById('title') as HTMLInputElement).value;
    var descriptionBody = (document.getElementById('descriptionBody') as HTMLInputElement).value;

    const headers = {
        'Content-Type': 'application/json'
    }
    axios.post("http://192.168.2.13:5000/Movie", {
            'title': title,
            'descriptionBody': descriptionBody
        }, {
            headers: headers
        }
    ).then(function(){
        alert("Movie created");
    }).catch(function (error) {
        // handle error
        alert("Failed to create movie" + error);
    })
}

function CreateMovieView() {
    return (
        <div>
            <MovieHeader/>
            <form onSubmit={SubmitMovie}>
                <label>
                    Title:<br/>
                    <input type="text" id="title" name="title"/><br/><br/>
                </label>
                <label>
                    Description:<br/>
                    <input type="text" id="descriptionBody" name="descriptionBody"/><br/><br/><br/>
                </label>
                <input type={"submit"} value="Submit"/>
            </form>
        </div>
    )
}

export default CreateMovieView;