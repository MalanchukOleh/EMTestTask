import React, { useState } from 'react';
import '../styles/CustomerPage.css';
const CustomersPage = () => {
  const [customers, setCustomers] = useState([]);
  
  const handleGetCustomers = async () => {
    try {
      const response = await fetch('http://13.60.250.91:5000/api/Customers');
      if (!response.ok) {
        throw new Error('Failed to fetch customers');
      }
      const data = await response.json();
      setCustomers(data);
    } catch (error) {
      console.error('Error:', error);
      alert('Помилка при завантаженні даних клієнтів');
    }
  };

  return (
    <div>
      {customers.length > 0 && (
        <div className="customer-list">
          <div className="customers">
            {customers.map((customer) => (
              <div className="customer-item" key={customer.id}>
                <p><strong>First Name:</strong> {customer.firstName}</p>
                <p><strong>Second Name:</strong> {customer.secondName}</p>
                <p><strong>Email:</strong> {customer.email}</p>
                <p><strong>Phone Number:</strong> {customer.phoneNumber}</p>
                <p><strong>Address:</strong> {customer.address}</p>
              </div>
            ))}
          </div>
        </div>
      )}
      <button 
        type="button" 
        className="submit-btn"
        onClick={handleGetCustomers}
      >
        Get all customers
      </button>
    </div>
  );
};

export default CustomersPage;
