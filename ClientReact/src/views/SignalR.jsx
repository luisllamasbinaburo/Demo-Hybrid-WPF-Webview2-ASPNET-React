import { useEffect, useState } from 'react'
import * as signalR from '@microsoft/signalr'

function App() {
  const [data, setData] = useState(null)
  const [time, setTime] = useState("") // Nuevo estado para la hora

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/api/demo`)
      .then(res => res.json())
      .then(data => setData(data))
  }, [])

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl(`${import.meta.env.VITE_API_URL}/clockHub`) // Ruta del Hub
      .withAutomaticReconnect()
      .configureLogging(signalR.LogLevel.Information)
      .build()

    connection.start()
      .then(() => console.log("Conectado a SignalR"))
      .catch(err => console.error("Error al conectar a SignalR:", err))

    // Escuchar el evento "ReceiveTime" del hub
    connection.on("ReceiveTime", (time) => {
      console.log("Hora recibida:", time)
      setTime(time)
    })

    // Limpieza al desmontar el componente
    return () => {
      connection.stop()
    }
  }, [])

  return (
    <>
      <h1>{data?.message || "Cargando..."}</h1>
      <h2>Hora: {time || "Sin conexión"}</h2> {/* Muestra la hora en tiempo real */}
    </>
  )
}

export default App
