import React from 'react';
import { Link } from 'react-router-dom';
import '../styles/Navigation.css'; 

const Navigation = () => {
  return (
    <div className="navbar">
      <ul className="navbar-list">
        <li className="navbar-item">
          <Link to="/register" className="navbar-link">Register</Link>
        </li>
        <li className="navbar-item">
          <Link to="/customers" className="navbar-link">Customers</Link>
        </li>
      </ul>
    </div>
  );
};

export default Navigation;
