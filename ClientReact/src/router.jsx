import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './views/Home';
import About from './views/About';
import Fetch from './views/Fetch';
import SignalR from './views/SignalR';
import App from './App';

function AppRouter() {
  return (
    <Router>
      <App />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/fetch" element={<Fetch />} />
        <Route path="/signalr" element={<SignalR />} />
      </Routes>
    </Router>
  );
}

export default AppRouter;
