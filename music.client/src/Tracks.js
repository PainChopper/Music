import React , { useState, useEffect } from "react";
import axios from "axios";

function GetData(props){
    const [tracks, setData] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
          const result = await axios(
            `http://localhost:62708/api/albums/${props.albumId}/tracks`,
          );
          setData(result.data);
        };
     
        fetchData();
      }, []);
    return (
      <ul>
        {tracks.map(track => (
          <li key={track.id}>
            {track.name}
          </li>
        ))}
      </ul>
    );    
}

function Tracks  () {
    return (
        <div>
            <GetData albumId = {3}/>
            <GetData albumId = {2}/>
            <GetData albumId = {1}/>            
        </div>
    );
}

export default Tracks;