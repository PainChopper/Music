import React, { useState, useEffect } from 'react';
import { AgGridColumn, AgGridReact } from 'ag-grid-react';
import axios from "axios";

import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';


const TracksGrid = (props) => {
    const [gridApi, setGridApi] = useState(null);
    const [gridColumnApi, setGridColumnApi] = useState(null);

    const [rowData, setRowData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
          const result = await axios(
            `http://localhost:62708/api/albums/${props.albumId}/tracks`,
          );
          setRowData(result.data);
        };
     
        fetchData();
      }, []);
    
    return (
        <div className="ag-theme-alpine" style={ { height: 300, width: 1010 } }>
            <AgGridReact
    defaultColDef={{
        filter: true,
    }}            
                rowData={rowData}>
                <AgGridColumn field="name"></AgGridColumn>
                <AgGridColumn field="duration"></AgGridColumn>
                <AgGridColumn field="isFavorite"></AgGridColumn>
                <AgGridColumn field="isListened"></AgGridColumn>                
                <AgGridColumn field="rating"></AgGridColumn>                                
            </AgGridReact>
        </div>
    );
};

export default TracksGrid