import { useEffect, useState } from 'react'

function App() {
  const [data, setData] = useState(null)
  const [forecasts, setForecasts] = useState()
  const [files, setFiles] = useState()


  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/api/demo`)
      .then(res => res.json())
      .then(data => setData(data))
  }, [])

  useEffect(() => {
    populateWeatherData()
    getFiles()
  }, [])

  async function populateWeatherData() {
    const response = await fetch(`${import.meta.env.VITE_API_URL}/weatherforecast`)
    if (response.ok) {
      const data = await response.json()
      setForecasts(data)
    }
  }
  
  async function getFiles() {
    const response = await fetch(`${import.meta.env.VITE_API_URL}/files`)
    if (response.ok) {
      const data = await response.json()
      setFiles(data)
    }
  }

  const contents = forecasts === undefined || files === undefined
  ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
  : <>
    <ul>
      {files.map(file => <li key={file}>{file}</li>)}
    </ul>
  </>

  return (
    <>
      <h1>{data?.message || "Cargando..."}</h1>
      <ul>
        {contents}
      </ul>
    </>
  )
}

export default App
