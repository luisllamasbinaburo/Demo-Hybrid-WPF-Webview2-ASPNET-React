import { useEffect, useState } from 'react'
   
function App() {
  const [data, setData] = useState(null)

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/api/demo`)
      .then(res => res.json())
      .then(data => setData(data))
  }, [])

  return <h1>{data?.message || "Cargando..."}</h1>
}

export default App