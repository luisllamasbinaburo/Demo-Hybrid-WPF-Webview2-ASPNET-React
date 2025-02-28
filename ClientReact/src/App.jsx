import { useEffect, useState } from 'react'
   
function App() {
  const [data, setData] = useState(null)
  const [forecasts, setForecasts] = useState();
  const [files, setFiles] = useState();

  const contents = forecasts === undefined && files === undefined
  ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
  : <>
    <table>
      <thead>
          <tr>
              <th>Date</th>
              <th>Temp. (C)</th>
              <th>Temp. (F)</th>
              <th>Summary</th>
          </tr>
      </thead>
      <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.date}>
                  <td>{forecast.date}</td>
                  <td>{forecast.temperatureC}</td>
                  <td>{forecast.temperatureF}</td>
                  <td>{forecast.summary}</td>
              </tr>
          )}
      </tbody>
  </table>
  <ul>
    {files.map(file => <li key={file}>{file}</li>)}
  </ul> 
 </>
  ;

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/api/demo`)
      .then(res => res.json())
      .then(data => setData(data))
  }, [])

  useEffect(() => {
    populateWeatherData();
}, []);

useEffect(() => {
    getFiles();
}, []);

  return <>
  <h1>
    {data?.message || "Cargando..."}
    </h1>
    <ul>
    {contents}
    </ul>
    </>
  

async function populateWeatherData() {
  const response = await fetch(`${import.meta.env.VITE_API_URL}/weatherforecast`);
  if (response.ok) {
      const data = await response.json();
      setForecasts(data);
  }
}

async function getFiles() {
    const response = await fetch(`${import.meta.env.VITE_API_URL}/files`);
    if (response.ok) {
        const data = await response.json();
        setFiles(data);
    }
  }
}



export default App