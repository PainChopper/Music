import React from "react";
import PropTypes from "prop-types";
import axios from "axios";

 function GetData(){
    const response = axios.get(`http://localhost:62708/api/albums/3/tracks`);
    const d = response;
    console.log(d);
    // this.setState({ totalReactPackages: response.data })
    return (
        'd'
    )
}

function Tracks  () {
    return (
        <div>
            <GetData/>
        </div>
    );
}

export default Tracks;