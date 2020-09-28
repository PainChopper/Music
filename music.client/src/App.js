import React from 'react';
import './App.css';
import TracksGrid from './TracksGrid';
import GetTracks from './GetTracks'
import Tracks from './Tracks'

function App() {

  const tracks = GetTracks(3);

  return (
    <div> 
      <TracksGrid albumId = {1}/>
      <TracksGrid albumId = {3}/>
    </div>      
  );
}

export default App;
