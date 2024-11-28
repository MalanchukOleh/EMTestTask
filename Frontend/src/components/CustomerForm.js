
import React, { useState } from 'react';
import '../styles/CustomerForm.css';

const CustomerForm = () => {
  const [formData, setFormData] = useState({
    FirstName: '',
    SecondName: '',
    Email: '',
    PhoneNumber: '',
    Address: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('http://13.60.250.91:5000/api/Customers', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
      });
      if (!response.ok) {
        const errorData = await response.json();
        alert(errorData.message);
      }
      const data = await response.json();
      alert('Дані надіслано!');
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className="form-container">
    <h1 style={{ textAlign: 'center', color: '#333' }}>Customer form</h1>
    <form onSubmit={handleSubmit}>
      <div className="form-group">
        <label>First name*</label>
        <input
          type="text"
          name="FirstName"
          value={formData.FirstName}
          onChange={handleChange}
        />
      </div>
      <div className="form-group">
        <label>Second name*</label>
        <input
          type="text"
          name="SecondName"
          value={formData.SecondName}
          onChange={handleChange}
        />
      </div>
      <div className="form-group">
        <label>Email*</label>
        <input
          type="email"
          name="Email"
          value={formData.Email}
          onChange={handleChange}
        />
      </div>
      <div className="form-group">
        <label>Phone number*(Without +, е.g. 380999999999)</label>
        <input
          type="tel"
          name="PhoneNumber"
          value={formData.PhoneNumber}
          onChange={handleChange}
        />
      </div>
      <div className="form-group">
        <label>Address(Not required)</label>
        <input
          type="text"
          name="Address"
          value={formData.Address}
          onChange={handleChange}
        />
      </div>
      <button type="submit" className="submit-btn">Submit</button>
    </form>
    </div>
  );
};

export default CustomerForm;
