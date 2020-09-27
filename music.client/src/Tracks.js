import React , { useState, useEffect } from "react";
import axios from "axios";

import ReactDataGrid from 'react-data-grid';

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



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// class TrackList extends React.Component {
//     state = {
//       tracks: []
//     }
  
//     componentDidMount() {
//       axios.get(`http://localhost:62708/api/albums/3/tracks`)
//         .then(res => {
//           const tracks = res.data;
//           this.setState({ tracks });
//         })
//     }
  
//     render() {
//       return (
//         <ul>
//           {this.state.tracks.map(track => <li key={track.id}>{track.name}</li>)}
//         </ul>
//       )
//     }
//   }

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