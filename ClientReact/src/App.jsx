import { Link } from 'react-router-dom';

function App() {
  return (
    <div>
      <nav>
        <Link to="/">Inicio</Link>
        <Link to="/about">Acerca de</Link>
        <Link to="/fetch">Fetch</Link>
        <Link to="/signalr">SignalR</Link>
      </nav>
    </div>
  );
}

export default App;
