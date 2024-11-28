import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './styles/App.css';
import CustomerForm from './components/CustomerForm';
import CustomersPage from './components/CustomersPage';
import Navigation from './components/Navigation';
import background from './assets/background.png';

const App = () => {
  return (
    <Router>
      <div className="app-container" style={{ backgroundImage: `url(${background})` }}>
        <Navigation />
          <Routes>
            <Route path="/register" element={<CustomerForm />} />
            <Route path="/customers" element={<CustomersPage />} />
          </Routes>
      </div>
    </Router>
  );
};

export default App;
