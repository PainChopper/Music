import React , { useState, useEffect } from "react";
import axios from "axios";

export default function GetTracks(props){
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
      console.log(props.albumId);
      console.log(tracks);
    return tracks;
}
